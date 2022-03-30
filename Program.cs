using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ValidaPluCafes
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string text = "";
            SqlServer sap = new SqlServer();

            int cuicuilco = sap.countPLU("10.4.210.200");
            if(cuicuilco >= 0)
            {
                text += "Sanborns Cafe Cuicuilco con <strong>" + cuicuilco.ToString("n0") + "</strong> Articulos<br><br>";
                Log.writeLog("Sanborns Cafe Cuicuilco con " + cuicuilco.ToString("n0") + " Articulos");
                List<Coffe> coffes = sap.getCoffes();
                foreach(Coffe coffe in coffes)
                {
                    if (coffe.countPluCoffe == cuicuilco)
                    {
                        text += coffe.coffeOK() + "<br>";
                        Log.writeLog(coffe.coffeOK());
                    }
                    else if (coffe.countPluCoffe < 0)
                    {
                        text += "<b style='Color:#B90606;'>" + coffe.coffeErrorConnection() + "</b><br>";
                        Log.writeLog(coffe.coffeErrorConnection());
                    }
                    else
                    {
                        text += "<b style='Color:#B90606;'>" + coffe.coffeDifferent() + "</b><br>";
                        Log.writeLog(coffe.coffeDifferent());
                    }
                }
            }
            else
            {
                text += "Sin conexion a Sanborns Cafe Cuicuilco, no se puede realizar la comparacion de PLU´S";
                Log.writeLog("Sin conexion a Sanborns Cafe Cuicuilco, no se puede realizar la comparacion de PLU´S");
            }
            Email email = new Email();
            email.sendEmail(text);
        }
    }
}