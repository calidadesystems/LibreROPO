using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreROPO
{
    public class Pais
    {
        private string identificador;
        private string nombre;

        public Pais(string identificador, string nombre)
        {
            this.Identificador = identificador;
            this.Nombre = nombre;
        }

        public string Identificador { get => identificador; set => identificador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
