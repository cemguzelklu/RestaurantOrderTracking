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
            this.btnMenuGoruntule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMenuGoruntule
            // 
            this.btnMenuGoruntule.Location = new System.Drawing.Point(52, 31);
            this.btnMenuGoruntule.Name = "btnMenuGoruntule";
            this.btnMenuGoruntule.Size = new System.Drawing.Size(113, 51);
            this.btnMenuGoruntule.TabIndex = 0;
            this.btnMenuGoruntule.Text = "Menü";
            this.btnMenuGoruntule.UseVisualStyleBackColor = true;
            this.btnMenuGoruntule.Click += new System.EventHandler(this.btnMenuGoruntule_Click);
            // 
            // FrmMusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMenuGoruntule);
            this.Name = "FrmMusteri";
            this.Text = "FrmMusteri";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMenuGoruntule;
    }
}