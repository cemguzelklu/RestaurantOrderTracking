namespace siparisTakip
{
    partial class FrmRaporlama
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
            this.cmbRaporTuru = new System.Windows.Forms.ComboBox();
            this.btnRaporAl = new System.Windows.Forms.Button();
            this.dgvRapor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRaporTuru
            // 
            this.cmbRaporTuru.FormattingEnabled = true;
            this.cmbRaporTuru.Location = new System.Drawing.Point(148, 63);
            this.cmbRaporTuru.Name = "cmbRaporTuru";
            this.cmbRaporTuru.Size = new System.Drawing.Size(121, 24);
            this.cmbRaporTuru.TabIndex = 0;
            // 
            // btnRaporAl
            // 
            this.btnRaporAl.Location = new System.Drawing.Point(466, 147);
            this.btnRaporAl.Name = "btnRaporAl";
            this.btnRaporAl.Size = new System.Drawing.Size(108, 63);
            this.btnRaporAl.TabIndex = 1;
            this.btnRaporAl.Text = "Raporu Göster";
            this.btnRaporAl.UseVisualStyleBackColor = true;
            this.btnRaporAl.Click += new System.EventHandler(this.btnRaporAl_Click);
            // 
            // dgvRapor
            // 
            this.dgvRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapor.Location = new System.Drawing.Point(28, 250);
            this.dgvRapor.Name = "dgvRapor";
            this.dgvRapor.RowHeadersWidth = 51;
            this.dgvRapor.RowTemplate.Height = 24;
            this.dgvRapor.Size = new System.Drawing.Size(240, 150);
            this.dgvRapor.TabIndex = 2;
            // 
            // FrmRaporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRapor);
            this.Controls.Add(this.btnRaporAl);
            this.Controls.Add(this.cmbRaporTuru);
            this.Name = "FrmRaporlama";
            this.Text = "FrmRaporlama";
            this.Load += new System.EventHandler(this.FrmRaporlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRaporTuru;
        private System.Windows.Forms.Button btnRaporAl;
        private System.Windows.Forms.DataGridView dgvRapor;
    }
}