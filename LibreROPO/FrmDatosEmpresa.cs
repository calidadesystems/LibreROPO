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
    public partial class FrmDatosEmpresa : Form
    {
        private LibreROPOdb lrdb;

        public FrmDatosEmpresa()
        {
            InitializeComponent();
            this.lrdb = LibreROPOdb.GetInstance("");
            fillData();

        }


        private void fillData()
        {
            if (lrdb.ExistsDatosResponsable())
            {
                this.tbnif.Text = this.lrdb.getNifResponsable();
                this.tbropoempresa.Text = this.lrdb.getROPOResponsable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lrdb.ModifyDatosEmpresa(this.tbnif.Text, this.tbropoempresa.Text);
            this.Dispose();
        }
    }
}
