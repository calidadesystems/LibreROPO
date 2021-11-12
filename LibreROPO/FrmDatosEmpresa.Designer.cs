
namespace LibreROPO
{
    partial class FrmDatosEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblnif = new System.Windows.Forms.Label();
            this.lblropo = new System.Windows.Forms.Label();
            this.tbnif = new System.Windows.Forms.TextBox();
            this.tbropoempresa = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblnif
            // 
            this.lblnif.AutoSize = true;
            this.lblnif.Location = new System.Drawing.Point(12, 9);
            this.lblnif.Name = "lblnif";
            this.lblnif.Size = new System.Drawing.Size(24, 13);
            this.lblnif.TabIndex = 0;
            this.lblnif.Text = "NIF";
            // 
            // lblropo
            // 
            this.lblropo.AutoSize = true;
            this.lblropo.Location = new System.Drawing.Point(12, 55);
            this.lblropo.Name = "lblropo";
            this.lblropo.Size = new System.Drawing.Size(77, 13);
            this.lblropo.TabIndex = 1;
            this.lblropo.Text = "Ropo Empresa";
            // 
            // tbnif
            // 
            this.tbnif.Location = new System.Drawing.Point(118, 6);
            this.tbnif.Name = "tbnif";
            this.tbnif.Size = new System.Drawing.Size(163, 20);
            this.tbnif.TabIndex = 2;
            // 
            // tbropoempresa
            // 
            this.tbropoempresa.Location = new System.Drawing.Point(118, 48);
            this.tbropoempresa.Name = "tbropoempresa";
            this.tbropoempresa.Size = new System.Drawing.Size(163, 20);
            this.tbropoempresa.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(26, 103);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(167, 103);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 5;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmDatosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 154);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbropoempresa);
            this.Controls.Add(this.tbnif);
            this.Controls.Add(this.lblropo);
            this.Controls.Add(this.lblnif);
            this.Name = "FrmDatosEmpresa";
            this.Text = "FrmDatosEmpresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblnif;
        private System.Windows.Forms.Label lblropo;
        private System.Windows.Forms.TextBox tbnif;
        private System.Windows.Forms.TextBox tbropoempresa;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btncancelar;
    }
}