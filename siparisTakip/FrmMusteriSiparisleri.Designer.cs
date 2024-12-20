namespace siparisTakip
{
    partial class FrmMusteriSiparisleri
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
            this.dgvMusteriSiparisleri = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriSiparisleri)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMusteriSiparisleri
            // 
            this.dgvMusteriSiparisleri.AllowUserToAddRows = false;
            this.dgvMusteriSiparisleri.AllowUserToDeleteRows = false;
            this.dgvMusteriSiparisleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusteriSiparisleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMusteriSiparisleri.Location = new System.Drawing.Point(0, 0);
            this.dgvMusteriSiparisleri.Name = "dgvMusteriSiparisleri";
            this.dgvMusteriSiparisleri.ReadOnly = true;
            this.dgvMusteriSiparisleri.RowHeadersWidth = 51;
            this.dgvMusteriSiparisleri.RowTemplate.Height = 24;
            this.dgvMusteriSiparisleri.Size = new System.Drawing.Size(800, 450);
            this.dgvMusteriSiparisleri.TabIndex = 0;
            // 
            // FrmMusteriSiparisleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMusteriSiparisleri);
            this.Name = "FrmMusteriSiparisleri";
            this.Text = "FrmMusteriSiparisleri";
            this.Load += new System.EventHandler(this.FrmMusteriSiparisleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriSiparisleri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMusteriSiparisleri;
    }
}