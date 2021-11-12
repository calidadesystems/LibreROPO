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
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();
            //OpenDatabase od = new OpenDatabase();
            //od.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ListarClientes lc = new ListarClientes();
            lc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDatosEmpresa fde = new FrmDatosEmpresa();
            fde.Show();
        }
    }
}
