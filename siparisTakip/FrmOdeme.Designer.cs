namespace siparisTakip
{
    partial class FrmOdeme
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
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.btnOdemeYap = new System.Windows.Forms.Button();
            this.rbKart = new System.Windows.Forms.RadioButton();
            this.rbNakit = new System.Windows.Forms.RadioButton();
            this.pnlKartBilgileri = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKartSahibi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSKT = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtKartNumarasi = new System.Windows.Forms.TextBox();
            this.pnlKartBilgileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(102, 65);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(44, 16);
            this.lblToplamTutar.TabIndex = 0;
            this.lblToplamTutar.Text = "label1";
            // 
            // btnOdemeYap
            // 
            this.btnOdemeYap.Location = new System.Drawing.Point(163, 180);
            this.btnOdemeYap.Name = "btnOdemeYap";
            this.btnOdemeYap.Size = new System.Drawing.Size(113, 40);
            this.btnOdemeYap.TabIndex = 1;
            this.btnOdemeYap.Text = "Sipariş Oluştur";
            this.btnOdemeYap.UseVisualStyleBackColor = true;
            this.btnOdemeYap.Click += new System.EventHandler(this.btnOdemeYap_Click);
            // 
            // rbKart
            // 
            this.rbKart.AutoSize = true;
            this.rbKart.Location = new System.Drawing.Point(469, 113);
            this.rbKart.Name = "rbKart";
            this.rbKart.Size = new System.Drawing.Size(116, 20);
            this.rbKart.TabIndex = 2;
            this.rbKart.TabStop = true;
            this.rbKart.Text = "Kart İle Ödeme";
            this.rbKart.UseVisualStyleBackColor = true;
            this.rbKart.CheckedChanged += new System.EventHandler(this.rbKart_CheckedChanged);
            // 
            // rbNakit
            // 
            this.rbNakit.AutoSize = true;
            this.rbNakit.Location = new System.Drawing.Point(469, 167);
            this.rbNakit.Name = "rbNakit";
            this.rbNakit.Size = new System.Drawing.Size(59, 20);
            this.rbNakit.TabIndex = 3;
            this.rbNakit.TabStop = true;
            this.rbNakit.Text = "Nakit";
            this.rbNakit.UseVisualStyleBackColor = true;
            // 
            // pnlKartBilgileri
            // 
            this.pnlKartBilgileri.Controls.Add(this.label3);
            this.pnlKartBilgileri.Controls.Add(this.txtCVV);
            this.pnlKartBilgileri.Controls.Add(this.label2);
            this.pnlKartBilgileri.Controls.Add(this.txtKartSahibi);
            this.pnlKartBilgileri.Controls.Add(this.label1);
            this.pnlKartBilgileri.Controls.Add(this.txtSKT);
            this.pnlKartBilgileri.Controls.Add(this.textBox2);
            this.pnlKartBilgileri.Controls.Add(this.txtKartNumarasi);
            this.pnlKartBilgileri.Location = new System.Drawing.Point(362, 238);
            this.pnlKartBilgileri.Name = "pnlKartBilgileri";
            this.pnlKartBilgileri.Size = new System.Drawing.Size(296, 200);
            this.pnlKartBilgileri.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "CVV";
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(123, 161);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(100, 22);
            this.txtCVV.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "SKT";
            // 
            // txtKartSahibi
            // 
            this.txtKartSahibi.AutoSize = true;
            this.txtKartSahibi.Location = new System.Drawing.Point(22, 78);
            this.txtKartSahibi.Name = "txtKartSahibi";
            this.txtKartSahibi.Size = new System.Drawing.Size(71, 16);
            this.txtKartSahibi.TabIndex = 4;
            this.txtKartSahibi.Text = "Kart Sahibi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kart Numarası";
            // 
            // txtSKT
            // 
            this.txtSKT.Location = new System.Drawing.Point(123, 122);
            this.txtSKT.Name = "txtSKT";
            this.txtSKT.Size = new System.Drawing.Size(100, 22);
            this.txtSKT.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(123, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            // 
            // txtKartNumarasi
            // 
            this.txtKartNumarasi.Location = new System.Drawing.Point(123, 22);
            this.txtKartNumarasi.Name = "txtKartNumarasi";
            this.txtKartNumarasi.Size = new System.Drawing.Size(100, 22);
            this.txtKartNumarasi.TabIndex = 0;
            // 
            // FrmOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlKartBilgileri);
            this.Controls.Add(this.rbNakit);
            this.Controls.Add(this.rbKart);
            this.Controls.Add(this.btnOdemeYap);
            this.Controls.Add(this.lblToplamTutar);
            this.Name = "FrmOdeme";
            this.Text = "FrmOdeme";
            this.Load += new System.EventHandler(this.FrmOdeme_Load);
            this.pnlKartBilgileri.ResumeLayout(false);
            this.pnlKartBilgileri.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Button btnOdemeYap;
        private System.Windows.Forms.RadioButton rbKart;
        private System.Windows.Forms.RadioButton rbNakit;
        private System.Windows.Forms.Panel pnlKartBilgileri;
        private System.Windows.Forms.TextBox txtSKT;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtKartNumarasi;
        private System.Windows.Forms.Label txtKartSahibi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label label3;
    }
}