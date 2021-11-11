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

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
