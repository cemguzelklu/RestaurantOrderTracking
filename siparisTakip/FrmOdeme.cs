using System;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmOdeme : Form
    {
        public decimal ToplamTutar { get; set; }

        public FrmOdeme()
        {
            InitializeComponent();
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            lblToplamTutar.Text = $"Ödenecek Tutar: {ToplamTutar:C2}";
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            // Burada ödeme işlemlerini gerçekleştirebilirsiniz
            MessageBox.Show("Ödeme işleminiz başarıyla tamamlandı!");

            // Ödeme tamamlandıktan sonra sepeti temizle
            FrmMenuGoruntule.sepet.Clear();

            this.Close(); // Ödeme sayfasını kapat
        }
    }
}
