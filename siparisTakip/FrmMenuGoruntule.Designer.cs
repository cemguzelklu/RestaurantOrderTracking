namespace siparisTakip
{
    partial class FrmMenuGoruntule
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
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.cmbKategoriler = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.numMinFiyat = new System.Windows.Forms.NumericUpDown();
            this.numMaxFiyat = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(22, 82);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Size = new System.Drawing.Size(474, 215);
            this.dgvUrunler.TabIndex = 0;
            this.dgvUrunler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunler_CellContentClick);
            // 
            // cmbKategoriler
            // 
            this.cmbKategoriler.FormattingEnabled = true;
            this.cmbKategoriler.Location = new System.Drawing.Point(101, 26);
            this.cmbKategoriler.Name = "cmbKategoriler";
            this.cmbKategoriler.Size = new System.Drawing.Size(151, 24);
            this.cmbKategoriler.TabIndex = 1;
            this.cmbKategoriler.SelectedIndexChanged += new System.EventHandler(this.cmbKategoriler_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sepet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(572, 104);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(181, 22);
            this.txtArama.TabIndex = 3;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(572, 334);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(136, 59);
            this.btnAra.TabIndex = 4;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // numMinFiyat
            // 
            this.numMinFiyat.Location = new System.Drawing.Point(572, 194);
            this.numMinFiyat.Name = "numMinFiyat";
            this.numMinFiyat.Size = new System.Drawing.Size(142, 22);
            this.numMinFiyat.TabIndex = 5;
            // 
            // numMaxFiyat
            // 
            this.numMaxFiyat.Location = new System.Drawing.Point(572, 245);
            this.numMaxFiyat.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxFiyat.Name = "numMaxFiyat";
            this.numMaxFiyat.Size = new System.Drawing.Size(142, 22);
            this.numMaxFiyat.TabIndex = 6;
            // 
            // FrmMenuGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numMaxFiyat);
            this.Controls.Add(this.numMinFiyat);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbKategoriler);
            this.Controls.Add(this.dgvUrunler);
            this.Name = "FrmMenuGoruntule";
            this.Text = "FrmMenuGoruntule";
            this.Load += new System.EventHandler(this.FrmMenuGoruntule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFiyat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.ComboBox cmbKategoriler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.NumericUpDown numMinFiyat;
        private System.Windows.Forms.NumericUpDown numMaxFiyat;
    }
}