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
        private DataSet ds_clientes;
        public ListarClientes()
        {
            InitializeComponent();
            this.lrdb = LibreROPOdb.GetInstance("");
            this.dgvClientes.DataSource = this.lrdb.GetListarClientes().Tables[0];
        }

        private void ListarClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
