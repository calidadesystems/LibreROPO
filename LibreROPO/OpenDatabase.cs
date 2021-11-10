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
    public partial class OpenDatabase : Form
    {
        String path;
        LibreROPOdb lrdb;
        public OpenDatabase()
        {
            InitializeComponent();
        }

        private void brnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQlite database| *.sqlite3";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Check if file is a database
                    this.path = ofd.FileName;
                    this.textBox1.Text = this.path;
                    this.lrdb = LibreROPOdb.GetInstance(this.path);
                   
                }
            
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                string message = "Seleccione una base de datos";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            { 
                if (this.lrdb.isValidDb())
                {
                    this.Visible = false;
                    Principal pcp = new Principal();
                    pcp.ShowDialog();
                    this.Dispose();
                    

                }
                else 
                {
                    string message = "Base de datos invalida";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Sqlite database|*.sqlite3";
                sfd.Title = "Crear nueva base de datos";
                sfd.ShowDialog();
                if (sfd.FileName != "") 
                {
                    this.path = sfd.FileName;
                    this.textBox1.Text = this.path;
                    this.lrdb = LibreROPOdb.GetInstance(this.path);
                    if (this.lrdb.isValidDb())
                    {
                        Principal pcp = new Principal();
                        this.Visible = false;
                        pcp.ShowDialog();
                        this.Dispose();
                        
                    }
                }
            }
        }
    }
}
