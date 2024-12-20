namespace siparisTakip
{
    partial class FrmCalisan
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
            this.dgvSiparisler = new System.Windows.Forms.DataGridView();
            this.btnListele = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSiparisDurumu = new System.Windows.Forms.ComboBox();
            this.btnGunlukRapor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Location = new System.Drawing.Point(65, 34);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.RowHeadersWidth = 51;
            this.dgvSiparisler.RowTemplate.Height = 24;
            this.dgvSiparisler.Size = new System.Drawing.Size(466, 279);
            this.dgvSiparisler.TabIndex = 0;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(65, 354);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(146, 64);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 64);
            this.button1.TabIndex = 2;
            this.button1.Text = "Güncelle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSiparisDurumu
            // 
            this.cmbSiparisDurumu.FormattingEnabled = true;
            this.cmbSiparisDurumu.Location = new System.Drawing.Point(607, 110);
            this.cmbSiparisDurumu.Name = "cmbSiparisDurumu";
            this.cmbSiparisDurumu.Size = new System.Drawing.Size(163, 24);
            this.cmbSiparisDurumu.TabIndex = 3;
            // 
            // btnGunlukRapor
            // 
            this.btnGunlukRapor.Location = new System.Drawing.Point(556, 354);
            this.btnGunlukRapor.Name = "btnGunlukRapor";
            this.btnGunlukRapor.Size = new System.Drawing.Size(124, 64);
            this.btnGunlukRapor.TabIndex = 4;
            this.btnGunlukRapor.Text = "Günlük Rapor";
            this.btnGunlukRapor.UseVisualStyleBackColor = true;
            this.btnGunlukRapor.Click += new System.EventHandler(this.btnGunlukRapor_Click);
            // 
            // FrmCalisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGunlukRapor);
            this.Controls.Add(this.cmbSiparisDurumu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.dgvSiparisler);
            this.Name = "FrmCalisan";
            this.Text = "FrmCalisan";
            this.Load += new System.EventHandler(this.FrmCalisan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSiparisDurumu;
        private System.Windows.Forms.Button btnGunlukRapor;
    }
}