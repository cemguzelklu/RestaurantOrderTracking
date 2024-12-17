using System;
using System.Linq;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmSepet : Form
    {
        public FrmSepet()
        {
            InitializeComponent();
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

                dgvSepet.Refresh();
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
            FrmOdeme odemeSayfasi = new FrmOdeme();
            odemeSayfasi.ToplamTutar = FrmMenuGoruntule.sepet.Sum(u => u.Fiyat * u.Miktar);
            odemeSayfasi.ShowDialog();
        }
    }
}