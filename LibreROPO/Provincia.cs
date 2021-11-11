using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreROPO
{
    public class Provincia
    {
        private int ine;
        private string nombre;

        public Provincia(int ine, string nombre)
        {
            this.Ine = ine;
            this.Nombre = nombre;
        }

        public int Ine { get => ine; set => ine = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
