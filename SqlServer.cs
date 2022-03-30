using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaPluCafes
{
    internal class SqlServer
    {
        public int countPLU(String server)
        {
            int response = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = server;
                builder.UserID = "sa";
                builder.Password = "Sa@p0$d3$";
                builder.InitialCatalog = "backoff";

                using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "SELECT COUNT(plunum) FROM plu WHERE deptnum < 7000";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        Console.WriteLine($"Connected to server {server}");
                        Log.writeLog($"Connected to server {server}");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response = reader.GetInt32(0);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.writeLog(ex.Message);
                return -1;                
            }
            return response;
        }   
        
        public List<Coffe> getCoffes()
        {
            List<Coffe> list = new List<Coffe>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "10.128.10.24";
            builder.UserID = "SapPsi";
            builder.Password = "kTIX3wxO8?";
            builder.InitialCatalog = "Db_Util";

            using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "SELECT Id_Store, Desc_Store, Ip_Sap " +
                    "FROM Ctg_Store WHERE Id_Company = 4 AND Id_Store NOT IN (302,333,335,341,348,359,360,3001)";                
                using (SqlCommand command = new SqlCommand( sql, connection))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connected to server 10.128.10.24");
                        Log.writeLog("Connected to server 10.128.10.24");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Coffe()
                                {
                                    idCoffe = reader.GetInt32(0),
                                    nameCoffe = reader.GetString(1).Trim(),
                                    ipCoffe = reader.GetString(2).Trim(),
                                    countPluCoffe = countPLU(reader.GetString(2))
                                });
                            }
                        }
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.writeLog(ex.Message);
                    }                    
                }
            }
            return list;
        }
    }
}
