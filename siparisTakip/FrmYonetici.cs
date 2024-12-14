using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmYonetici : Form
    {
        public FrmYonetici()
        {
            InitializeComponent();
        }

        private void FrmYonetici_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Yönetici Ekranına Hoş Geldiniz!");
        }

        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            FrmCalisanEkle frmCalisanEkle = new FrmCalisanEkle();
            frmCalisanEkle.ShowDialog();
        }
        private void btnCalisanSil_Click(object sender, EventArgs e)
        {
            FrmCalisanSil frmCalisanSil = new FrmCalisanSil();
            frmCalisanSil.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUrunEkle frmUrunEkle = new FrmUrunEkle();
            frmUrunEkle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrunSil frmUrunSil = new FrmUrunSil();
            frmUrunSil.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmUrunGuncelle frmUrunGuncelle = new FrmUrunGuncelle();
            frmUrunGuncelle.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
