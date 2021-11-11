using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreROPO
{
    class Cliente
    {
        private string nifdestino;
        private string ropodestino;
        private string EntidadDestino;
        private string CorreoElectronicoDestino;
        private string TelefonoDestino;
        private string FaxDestino;
        private string DireccionDestino;
        private string CodPostalDestino;
        private string PaisDestino;
        private string ProvinciaDestino;
        private Municipio LocalidadDestino;

        public Cliente()
        { }

        public string Nifdestino { get => nifdestino; set => nifdestino = value; }
        public string Ropodestino { get => ropodestino; set => ropodestino = value; }
        public string EntidadDestino1 { get => EntidadDestino; set => EntidadDestino = value; }
        public string CorreoElectronicoDestino1 { get => CorreoElectronicoDestino; set => CorreoElectronicoDestino = value; }
        public string TelefonoDestino1 { get => TelefonoDestino; set => TelefonoDestino = value; }
        public string FaxDestino1 { get => FaxDestino; set => FaxDestino = value; }
        public string DireccionDestino1 { get => DireccionDestino; set => DireccionDestino = value; }
        public string CodPostalDestino1 { get => CodPostalDestino; set => CodPostalDestino = value; }
        public string PaisDestino1 { get => PaisDestino; set => PaisDestino = value; }
        public string ProvinciaDestino1 { get => ProvinciaDestino; set => ProvinciaDestino = value; }
        internal Municipio LocalidadDestino1 { get => LocalidadDestino; set => LocalidadDestino = value; }
    }
}
