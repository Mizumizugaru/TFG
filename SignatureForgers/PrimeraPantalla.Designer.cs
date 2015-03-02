namespace SignatureForgers
{
    partial class PrimeraPantalla
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
            this.botonConfiguracion = new System.Windows.Forms.Button();
            this.botonFalsificar = new System.Windows.Forms.Button();
            this.BotonRegistro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonConfiguracion
            // 
            this.botonConfiguracion.Location = new System.Drawing.Point(80, 160);
            this.botonConfiguracion.Name = "botonConfiguracion";
            this.botonConfiguracion.Size = new System.Drawing.Size(135, 42);
            this.botonConfiguracion.TabIndex = 0;
            this.botonConfiguracion.Text = "Configuración";
            this.botonConfiguracion.UseVisualStyleBackColor = true;
            this.botonConfiguracion.Click += new System.EventHandler(this.botonConfiguracion_Click);
            // 
            // botonFalsificar
            // 
            this.botonFalsificar.Location = new System.Drawing.Point(80, 103);
            this.botonFalsificar.Name = "botonFalsificar";
            this.botonFalsificar.Size = new System.Drawing.Size(135, 42);
            this.botonFalsificar.TabIndex = 2;
            this.botonFalsificar.Text = "Usuario falsificador";
            this.botonFalsificar.UseVisualStyleBackColor = true;
            this.botonFalsificar.Click += new System.EventHandler(this.botonFalsificar_Click);
            // 
            // BotonRegistro
            // 
            this.BotonRegistro.Location = new System.Drawing.Point(80, 42);
            this.BotonRegistro.Name = "BotonRegistro";
            this.BotonRegistro.Size = new System.Drawing.Size(135, 42);
            this.BotonRegistro.TabIndex = 3;
            this.BotonRegistro.Text = "Usuario genuino";
            this.BotonRegistro.UseVisualStyleBackColor = true;
            this.BotonRegistro.Click += new System.EventHandler(this.botonRegistro_Click);
            // 
            // PrimeraPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(327, 267);
            this.Controls.Add(this.BotonRegistro);
            this.Controls.Add(this.botonFalsificar);
            this.Controls.Add(this.botonConfiguracion);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(343, 305);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(343, 305);
            this.Name = "PrimeraPantalla";
            this.Text = "PrimeraPantalla";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonConfiguracion;
        private System.Windows.Forms.Button botonFalsificar;
        private System.Windows.Forms.Button BotonRegistro;
    }
}