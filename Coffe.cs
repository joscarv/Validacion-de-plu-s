using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaPluCafes
{
    internal class Coffe
    {
        public int idCoffe { get; set; }
        public String nameCoffe { get; set; }
        public String ipCoffe { get; set; }
        public int countPluCoffe { get; set; }
        public String coffeOK()
        {
            return $"Unidad {idCoffe} CORRECTA con {countPluCoffe.ToString("n0")} Articulos";
        }
        public String coffeErrorConnection()
        {
            return $"Sin conexion a la unidad {idCoffe} {nameCoffe} con ip {ipCoffe}";
        }
        public String coffeDifferent()
        {
            return $"REVISAR Unidad {idCoffe} con {countPluCoffe.ToString("n0")} Articulos";
        }
    }
}
