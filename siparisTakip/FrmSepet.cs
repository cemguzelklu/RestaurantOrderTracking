using System;
using System.Linq;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmSepet : Form
    {
        private int musteriID;

        public FrmSepet(int musteriID)
        {
            InitializeComponent();
            this.musteriID = musteriID;
        }

        private void FrmSepet_Load(object sender, EventArgs e)
        {
            dgvSepet.DataSource = null;
            dgvSepet.DataSource = FrmMenuGoruntule.sepet;
            dgvSepet.AutoGenerateColumns = true;
            ToplamTutariGuncelle();
        }

        private void btnMiktarArtır_Click(object sender, EventArgs e)
        {
            MiktariDegistir(1);
        }

        private void btnMiktarAzalt_Click(object sender, EventArgs e)
        {
            MiktariDegistir(-1);
        }

        private void MiktariDegistir(int miktarDegisiklik)
        {
            if (dgvSepet.CurrentRow != null)
            {
                var secilenUrun = (SepetUrun)dgvSepet.CurrentRow.DataBoundItem;
                secilenUrun.Miktar += miktarDegisiklik;

                if (secilenUrun.Miktar <= 0)
                {
                    FrmMenuGoruntule.sepet.Remove(secilenUrun);
                }

                dgvSepet.DataSource = null;
                dgvSepet.DataSource = FrmMenuGoruntule.sepet;
                dgvSepet.AutoGenerateColumns = true;
                ToplamTutariGuncelle();
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
            }
        }

        private void ToplamTutariGuncelle()
        {
            decimal toplamTutar = FrmMenuGoruntule.sepet.Sum(u => u.Fiyat * u.Miktar);
            lblToplamTutar.Text = $"Toplam Tutar: {toplamTutar:C2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = FrmMenuGoruntule.sepet.Sum(u => u.Fiyat * u.Miktar);

            if (toplamTutar <= 0)
            {
                MessageBox.Show("Sepetiniz boş. Lütfen ürün ekleyin.");
                return;
            }

            FrmOdeme odemeSayfasi = new FrmOdeme(musteriID, toplamTutar);
            odemeSayfasi.ShowDialog();
        }

    }
}
