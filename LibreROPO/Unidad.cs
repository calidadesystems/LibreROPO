using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreROPO
{
    class Unidad
    {
        private int codigo;
        private string descripcion;

        public Unidad(int codigo, string descripcion) 
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

    }
}
