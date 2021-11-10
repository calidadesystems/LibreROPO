using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreROPO
{
    class Municipio
    {
        private int ineprovincia;
        private int codmunicipio;
        private int dc;
        private string nombre;

        public Municipio(int ineprovincia, int codmunicipio, int dc, string nombre)
        {
            this.Ineprovincia = ineprovincia;
            this.Codmunicipio = codmunicipio;
            this.Dc = dc;
            this.Nombre = nombre;
        }

        public int Ineprovincia { get => ineprovincia; set => ineprovincia = value; }
        public int Codmunicipio { get => codmunicipio; set => codmunicipio = value; }
        public int Dc { get => dc; set => dc = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
