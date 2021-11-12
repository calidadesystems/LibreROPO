using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreROPO
{
    public partial class FrmCliente : Form
    {
        private LibreROPOdb lrdb;

        public FrmCliente()
        {
            InitializeComponent();
            this.lrdb = LibreROPOdb.GetInstance("");
            rellenaPaises();
        }

        private void rellenaPaises()
        {
            List < Pais >  Lista;
            Lista = lrdb.GetPaisesCombo();
            this.cbPais.DataSource = Lista;
            this.cbPais.DisplayMember = "nombre";
            this.cbPais.ValueMember = "identificador";
        }

        private void rellenaProvincias()
        {
            List<Provincia> Lista;
            Lista = lrdb.GetProvinciaCombo();
            this.cbProvincia.DataSource = Lista;
            this.cbProvincia.DisplayMember = "nombre";
            this.cbProvincia.ValueMember = "ine";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cbProvincia_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Cambio Texto de provincia");
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Cambio Texto de PAis");
            Pais seleccionado = (Pais) this.cbPais.SelectedItem;
            Console.WriteLine(seleccionado.Nombre);
            //Si tenemos a españa cargamos provincias
            if (seleccionado.Nombre.Equals("España"))
            {
                this.rellenaProvincias();
            }
            else //sino vaciamos el combo
            {
                this.cbProvincia.DataSource = null;
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
