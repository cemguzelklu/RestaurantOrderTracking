namespace siparisTakip
{
    partial class FrmMusteri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMusteri));
            this.btnMenuGoruntule = new System.Windows.Forms.Button();
            this.btnSiparisGoruntule = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenuGoruntule
            // 
            this.btnMenuGoruntule.BackColor = System.Drawing.Color.DarkOrange;
            this.btnMenuGoruntule.Location = new System.Drawing.Point(42, 206);
            this.btnMenuGoruntule.Name = "btnMenuGoruntule";
            this.btnMenuGoruntule.Size = new System.Drawing.Size(127, 74);
            this.btnMenuGoruntule.TabIndex = 0;
            this.btnMenuGoruntule.Text = "Menü";
            this.btnMenuGoruntule.UseVisualStyleBackColor = false;
            this.btnMenuGoruntule.Click += new System.EventHandler(this.btnMenuGoruntule_Click);
            // 
            // btnSiparisGoruntule
            // 
            this.btnSiparisGoruntule.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSiparisGoruntule.Location = new System.Drawing.Point(239, 206);
            this.btnSiparisGoruntule.Name = "btnSiparisGoruntule";
            this.btnSiparisGoruntule.Size = new System.Drawing.Size(120, 74);
            this.btnSiparisGoruntule.TabIndex = 1;
            this.btnSiparisGoruntule.Text = "Siparişlerim";
            this.btnSiparisGoruntule.UseVisualStyleBackColor = false;
            this.btnSiparisGoruntule.Click += new System.EventHandler(this.btnSiparisGoruntule_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(106, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(139, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hoşgeldiniz!";
            // 
            // FrmMusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSiparisGoruntule);
            this.Controls.Add(this.btnMenuGoruntule);
            this.Name = "FrmMusteri";
            this.Text = "FrmMusteri";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenuGoruntule;
        private System.Windows.Forms.Button btnSiparisGoruntule;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}