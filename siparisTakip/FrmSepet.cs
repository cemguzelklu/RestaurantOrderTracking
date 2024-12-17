using System;
using System.Data;
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

                // Miktarı güncelle
                secilenUrun.Miktar += miktarDegisiklik;

                if (secilenUrun.Miktar <= 0) // Eğer miktar sıfır veya daha küçükse ürünü listeden kaldır
                {
                    FrmMenuGoruntule.sepet.Remove(secilenUrun);
                }

                dgvSepet.Refresh(); // DataGridView'i güncelle
                ToplamTutariGuncelle(); // Toplam tutarı yeniden hesapla
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
            MessageBox.Show("Siparişiniz onaylandı!");
            FrmMenuGoruntule.sepet.Clear();

            dgvSepet.DataSource = null;
            dgvSepet.DataSource = FrmMenuGoruntule.sepet;

            ToplamTutariGuncelle(); // Sipariş onaylanınca tutarı sıfırla
        }
    }
}
