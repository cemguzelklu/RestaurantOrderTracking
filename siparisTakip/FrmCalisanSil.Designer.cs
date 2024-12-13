namespace siparisTakip
{
    partial class FrmCalisanSil
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
            this.dgvCalisanlar = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalisanlar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalisanlar
            // 
            this.dgvCalisanlar.AllowUserToAddRows = false;
            this.dgvCalisanlar.AllowUserToDeleteRows = false;
            this.dgvCalisanlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalisanlar.Location = new System.Drawing.Point(4, 12);
            this.dgvCalisanlar.Name = "dgvCalisanlar";
            this.dgvCalisanlar.ReadOnly = true;
            this.dgvCalisanlar.RowHeadersWidth = 51;
            this.dgvCalisanlar.Size = new System.Drawing.Size(784, 365);
            this.dgvCalisanlar.TabIndex = 0;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(301, 383);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(155, 55);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // FrmCalisanSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dgvCalisanlar);
            this.Name = "FrmCalisanSil";
            this.Text = "FrmCalisanSil";
            this.Load += new System.EventHandler(this.FrmCalisanSil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalisanlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalisanlar;
        private System.Windows.Forms.Button btnSil;
    }
}