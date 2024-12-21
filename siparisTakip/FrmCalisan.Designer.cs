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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiparisler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSiparisler
            // 
            this.dgvSiparisler.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.dgvSiparisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiparisler.Location = new System.Drawing.Point(12, 12);
            this.dgvSiparisler.Name = "dgvSiparisler";
            this.dgvSiparisler.RowHeadersWidth = 51;
            this.dgvSiparisler.RowTemplate.Height = 24;
            this.dgvSiparisler.Size = new System.Drawing.Size(555, 321);
            this.dgvSiparisler.TabIndex = 0;
            // 
            // btnListele
            // 
            this.btnListele.BackColor = System.Drawing.Color.DarkOrange;
            this.btnListele.Location = new System.Drawing.Point(65, 374);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(146, 64);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(311, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 64);
            this.button1.TabIndex = 2;
            this.button1.Text = "Güncelle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSiparisDurumu
            // 
            this.cmbSiparisDurumu.FormattingEnabled = true;
            this.cmbSiparisDurumu.Location = new System.Drawing.Point(593, 163);
            this.cmbSiparisDurumu.Name = "cmbSiparisDurumu";
            this.cmbSiparisDurumu.Size = new System.Drawing.Size(183, 24);
            this.cmbSiparisDurumu.TabIndex = 3;
            // 
            // btnGunlukRapor
            // 
            this.btnGunlukRapor.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGunlukRapor.Location = new System.Drawing.Point(571, 374);
            this.btnGunlukRapor.Name = "btnGunlukRapor";
            this.btnGunlukRapor.Size = new System.Drawing.Size(124, 64);
            this.btnGunlukRapor.TabIndex = 4;
            this.btnGunlukRapor.Text = "Günlük Rapor";
            this.btnGunlukRapor.UseVisualStyleBackColor = false;
            this.btnGunlukRapor.Click += new System.EventHandler(this.btnGunlukRapor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(573, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sipariş Durumu Güncelle";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmCalisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 499);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSiparisler;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSiparisDurumu;
        private System.Windows.Forms.Button btnGunlukRapor;
        private System.Windows.Forms.Label label1;
    }
}