namespace siparisTakip
{
    partial class FrmUrunGuncelle
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
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.txtUrun = new System.Windows.Forms.TextBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.Location = new System.Drawing.Point(320, 395);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(116, 43);
            this.btnUrunGuncelle.TabIndex = 1;
            this.btnUrunGuncelle.Text = "Güncelle";
            this.btnUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            // 
            // txtUrun
            // 
            this.txtUrun.Location = new System.Drawing.Point(455, 67);
            this.txtUrun.Name = "txtUrun";
            this.txtUrun.Size = new System.Drawing.Size(100, 22);
            this.txtUrun.TabIndex = 2;
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(618, 67);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(100, 22);
            this.txtFiyat.TabIndex = 3;
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(12, 12);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.RowTemplate.Height = 24;
            this.dgvUrunler.Size = new System.Drawing.Size(424, 281);
            this.dgvUrunler.TabIndex = 0;
            // 
            // FrmUrunGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtUrun);
            this.Controls.Add(this.btnUrunGuncelle);
            this.Controls.Add(this.dgvUrunler);
            this.Name = "FrmUrunGuncelle";
            this.Text = "FrmUrunGuncelle";
            this.Load += new System.EventHandler(this.FrmUrunGuncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.TextBox txtUrun;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.DataGridView dgvUrunler;
    }
}