namespace siparisTakip
{
    partial class FrmYonetici
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
            this.btnCalisanEkle = new System.Windows.Forms.Button();
            this.btnCalisanSil = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalisanEkle
            // 
            this.btnCalisanEkle.Location = new System.Drawing.Point(85, 100);
            this.btnCalisanEkle.Name = "btnCalisanEkle";
            this.btnCalisanEkle.Size = new System.Drawing.Size(98, 47);
            this.btnCalisanEkle.TabIndex = 0;
            this.btnCalisanEkle.Text = "Çalışan Ekle";
            this.btnCalisanEkle.UseVisualStyleBackColor = true;
            this.btnCalisanEkle.Click += new System.EventHandler(this.btnCalisanEkle_Click);
            // 
            // btnCalisanSil
            // 
            this.btnCalisanSil.Location = new System.Drawing.Point(85, 209);
            this.btnCalisanSil.Name = "btnCalisanSil";
            this.btnCalisanSil.Size = new System.Drawing.Size(98, 46);
            this.btnCalisanSil.TabIndex = 2;
            this.btnCalisanSil.Text = "Çalışan Sil";
            this.btnCalisanSil.UseVisualStyleBackColor = true;
            this.btnCalisanSil.Click += new System.EventHandler(this.btnCalisanSil_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ürün Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Ürün Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(248, 309);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(98, 46);
            this.btnGuncelle.TabIndex = 5;
            this.btnGuncelle.Text = "Ürün Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // FrmYonetici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCalisanSil);
            this.Controls.Add(this.btnCalisanEkle);
            this.Name = "FrmYonetici";
            this.Text = "FrmYonetici";
            this.Load += new System.EventHandler(this.FrmYonetici_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalisanEkle;
        private System.Windows.Forms.Button btnCalisanSil;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGuncelle;
    }
}