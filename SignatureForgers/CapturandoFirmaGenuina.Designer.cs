namespace SignatureForgers
{
    partial class CapturandoFirmaGenuina
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
            this.signControlWacomSTU1 = new SignCaptureWacomSTU.SignControlWacomSTU();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bClearWacom = new System.Windows.Forms.Button();
            this.bStopWacom = new System.Windows.Forms.Button();
            this.bStartWacom = new System.Windows.Forms.Button();
            this.bSetImage = new System.Windows.Forms.Button();
            this.bBrowse = new System.Windows.Forms.Button();
            this.bSaveSignature = new System.Windows.Forms.Button();
            this.labelSamples = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signControlWacomSTU1
            // 
            this.signControlWacomSTU1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signControlWacomSTU1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signControlWacomSTU1.Location = new System.Drawing.Point(2, 1);
            this.signControlWacomSTU1.MinimumSize = new System.Drawing.Size(100, 100);
            this.signControlWacomSTU1.Name = "signControlWacomSTU1";
            this.signControlWacomSTU1.Size = new System.Drawing.Size(384, 288);
            this.signControlWacomSTU1.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(221)))));
            this.signControlWacomSTU1.StrokeMaxThickPressure = 3.5F;
            this.signControlWacomSTU1.StrokeThickNoVisiblePressure = 3F;
            this.signControlWacomSTU1.StrokeThickNoVisiblePressureToExport = 3F;
            this.signControlWacomSTU1.StrokeVisiblePressure = false;
            this.signControlWacomSTU1.TabIndex = 0;
            this.signControlWacomSTU1.WacomSignArea = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuación deberá firmar en la tableta.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de firmas necesarias: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "5";
            // 
            // bClearWacom
            // 
            this.bClearWacom.Location = new System.Drawing.Point(330, 135);
            this.bClearWacom.Name = "bClearWacom";
            this.bClearWacom.Size = new System.Drawing.Size(100, 32);
            this.bClearWacom.TabIndex = 3;
            this.bClearWacom.Text = "Clear";
            this.bClearWacom.UseVisualStyleBackColor = true;
            this.bClearWacom.Click += new System.EventHandler(this.bClearWacom_Click);
            // 
            // bStopWacom
            // 
            this.bStopWacom.Location = new System.Drawing.Point(185, 135);
            this.bStopWacom.Name = "bStopWacom";
            this.bStopWacom.Size = new System.Drawing.Size(101, 32);
            this.bStopWacom.TabIndex = 4;
            this.bStopWacom.Text = "Stop";
            this.bStopWacom.UseVisualStyleBackColor = true;
            this.bStopWacom.Click += new System.EventHandler(this.bStopWacom_Click);
            // 
            // bStartWacom
            // 
            this.bStartWacom.Location = new System.Drawing.Point(41, 135);
            this.bStartWacom.Name = "bStartWacom";
            this.bStartWacom.Size = new System.Drawing.Size(101, 32);
            this.bStartWacom.TabIndex = 5;
            this.bStartWacom.Text = "Start";
            this.bStartWacom.UseVisualStyleBackColor = true;
            this.bStartWacom.Click += new System.EventHandler(this.bStartWacom_Click);
            // 
            // bSetImage
            // 
            this.bSetImage.Location = new System.Drawing.Point(41, 177);
            this.bSetImage.Name = "bSetImage";
            this.bSetImage.Size = new System.Drawing.Size(101, 32);
            this.bSetImage.TabIndex = 8;
            this.bSetImage.Text = "Set Image";
            this.bSetImage.UseVisualStyleBackColor = true;
            this.bSetImage.Click += new System.EventHandler(this.bSetImage_Click);
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(185, 177);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(101, 32);
            this.bBrowse.TabIndex = 7;
            this.bBrowse.Text = "Browse";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // bSaveSignature
            // 
            this.bSaveSignature.Location = new System.Drawing.Point(330, 177);
            this.bSaveSignature.Name = "bSaveSignature";
            this.bSaveSignature.Size = new System.Drawing.Size(100, 32);
            this.bSaveSignature.TabIndex = 6;
            this.bSaveSignature.Text = "Save Signature";
            this.bSaveSignature.UseVisualStyleBackColor = true;
            this.bSaveSignature.Click += new System.EventHandler(this.bSaveSignature_Click);
            // 
            // labelSamples
            // 
            this.labelSamples.AutoSize = true;
            this.labelSamples.Location = new System.Drawing.Point(327, 84);
            this.labelSamples.Name = "labelSamples";
            this.labelSamples.Size = new System.Drawing.Size(65, 13);
            this.labelSamples.TabIndex = 9;
            this.labelSamples.Text = "Muestra 1/5";
            // 
            // CapturandoFirmaGenuina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 221);
            this.Controls.Add(this.labelSamples);
            this.Controls.Add(this.bSetImage);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.bSaveSignature);
            this.Controls.Add(this.bStartWacom);
            this.Controls.Add(this.bStopWacom);
            this.Controls.Add(this.bClearWacom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 259);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(484, 259);
            this.Name = "CapturandoFirmaGenuina";
            this.Text = "CapturandoFirmaGenuina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private SignCaptureWacomSTU.SignControlWacomSTU signControlWacomSTU1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bClearWacom;
        private System.Windows.Forms.Button bStopWacom;
        private System.Windows.Forms.Button bStartWacom;
        private System.Windows.Forms.Button bSetImage;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Button bSaveSignature;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelSamples;
    }
}