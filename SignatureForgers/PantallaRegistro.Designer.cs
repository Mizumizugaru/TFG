namespace SignatureForgers
{
    partial class PantallaRegistro
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.usuarioRegistradoGen = new System.Windows.Forms.Button();
            this.nuevoUsuarioGen = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.usuarioRegistradoFal = new System.Windows.Forms.Button();
            this.nuevoUsuarioFal = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 236);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.tabPage1.Controls.Add(this.usuarioRegistradoGen);
            this.tabPage1.Controls.Add(this.nuevoUsuarioGen);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(454, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios Genuninos";
            // 
            // usuarioRegistradoGen
            // 
            this.usuarioRegistradoGen.Location = new System.Drawing.Point(235, 107);
            this.usuarioRegistradoGen.Name = "usuarioRegistradoGen";
            this.usuarioRegistradoGen.Size = new System.Drawing.Size(180, 44);
            this.usuarioRegistradoGen.TabIndex = 1;
            this.usuarioRegistradoGen.Text = "Usuario Registrado";
            this.usuarioRegistradoGen.UseVisualStyleBackColor = true;
            this.usuarioRegistradoGen.Click += new System.EventHandler(this.usuarioRegistradoGen_Click);
            // 
            // nuevoUsuarioGen
            // 
            this.nuevoUsuarioGen.Location = new System.Drawing.Point(22, 107);
            this.nuevoUsuarioGen.Name = "nuevoUsuarioGen";
            this.nuevoUsuarioGen.Size = new System.Drawing.Size(180, 44);
            this.nuevoUsuarioGen.TabIndex = 0;
            this.nuevoUsuarioGen.Text = "Nuevo Usuario";
            this.nuevoUsuarioGen.UseVisualStyleBackColor = true;
            this.nuevoUsuarioGen.Click += new System.EventHandler(this.nuevoUsuarioGen_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.tabPage2.Controls.Add(this.usuarioRegistradoFal);
            this.tabPage2.Controls.Add(this.nuevoUsuarioFal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(454, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usuarios Falsificadores";
            // 
            // usuarioRegistradoFal
            // 
            this.usuarioRegistradoFal.Location = new System.Drawing.Point(235, 107);
            this.usuarioRegistradoFal.Name = "usuarioRegistradoFal";
            this.usuarioRegistradoFal.Size = new System.Drawing.Size(180, 44);
            this.usuarioRegistradoFal.TabIndex = 3;
            this.usuarioRegistradoFal.Text = "Usuario Registrado";
            this.usuarioRegistradoFal.UseVisualStyleBackColor = true;
            this.usuarioRegistradoFal.Click += new System.EventHandler(this.usuarioRegistradoFal_Click);
            // 
            // nuevoUsuarioFal
            // 
            this.nuevoUsuarioFal.Location = new System.Drawing.Point(22, 107);
            this.nuevoUsuarioFal.Name = "nuevoUsuarioFal";
            this.nuevoUsuarioFal.Size = new System.Drawing.Size(180, 44);
            this.nuevoUsuarioFal.TabIndex = 2;
            this.nuevoUsuarioFal.Text = "Nuevo Usuario";
            this.nuevoUsuarioFal.UseVisualStyleBackColor = true;
            this.nuevoUsuarioFal.Click += new System.EventHandler(this.nuevoUsuarioFal_Click);
            // 
            // PantallaRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 240);
            this.Controls.Add(this.tabControl1);
            this.Name = "PantallaRegistro";
            this.Text = "Inicio";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button usuarioRegistradoGen;
        private System.Windows.Forms.Button nuevoUsuarioGen;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button usuarioRegistradoFal;
        private System.Windows.Forms.Button nuevoUsuarioFal;
    }
}

