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
    public partial class ListarClientes : Form
    {
        private LibreROPOdb lrdb;

        public ListarClientes()
        {
            InitializeComponent();
            this.lrdb = LibreROPOdb.GetInstance("");
            refrescaLista();
        }

        private void refrescaLista()
        {
            this.dgvClientes.DataSource = this.lrdb.GetListarClientes().Tables[0];
        }
        private void ListarClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCliente frmcli = new FrmCliente();
            frmcli.ShowDialog();
            refrescaLista();
        }
    }
}
