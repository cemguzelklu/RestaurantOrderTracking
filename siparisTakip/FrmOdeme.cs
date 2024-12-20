using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmOdeme : Form
    {
        private int musteriID;
        private decimal toplamTutar;

        string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

        public FrmOdeme(int musteriID, decimal toplamTutar)
        {
            InitializeComponent();
            this.musteriID = musteriID;
            this.toplamTutar = toplamTutar;
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            lblToplamTutar.Text = $"Ödenecek Tutar: {toplamTutar:C2}";
        }

        private void rbKart_CheckedChanged(object sender, EventArgs e)
        {
            pnlKartBilgileri.Visible = rbKart.Checked;
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (rbKart.Checked && KartBilgileriGecerliMi())
            {
                SiparisOlustur("Kredi Kartı ile Ödeme");
            }
            else if (rbNakit.Checked)
            {
                SiparisOlustur("Kapıda Ödeme");
            }
            else
            {
                MessageBox.Show("Lütfen bir ödeme yöntemi seçin.");
            }
        }

        private bool KartBilgileriGecerliMi()
        {
            if (string.IsNullOrWhiteSpace(txtKartNumarasi.Text) ||
                string.IsNullOrWhiteSpace(txtKartSahibi.Text) ||
                string.IsNullOrWhiteSpace(txtSKT.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show("Kart bilgilerini eksiksiz doldurun.");
                return false;
            }
            return true;
        }

        private void SiparisOlustur(string odemeYontemi)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = @"
                    DECLARE @SiparisID INT;
                    DECLARE @OdemeYontemID INT;

                    SELECT @OdemeYontemID = Id 
                    FROM OdemeYontem 
                    WHERE YontemAdi = @YontemAdi;

                    IF (@OdemeYontemID IS NULL)
                    BEGIN
                        RAISERROR('Geçerli bir ödeme yöntemi bulunamadı.', 16, 1);
                        RETURN;
                    END

                    INSERT INTO Siparis (MusteriID, ToplamTutar)
                    VALUES (@MusteriID, @ToplamTutar);

                    SET @SiparisID = SCOPE_IDENTITY();

                    INSERT INTO SiparisDetay (SiparisID, UrunID, Miktar, OdemeYontemID, SiparisDurum)
                    SELECT @SiparisID, SU.UrunID, SU.Miktar, @OdemeYontemID, 1 -- SiparişDurum: Beklemede
                    FROM SepetUrun SU
                    JOIN Sepet S ON S.Id = SU.SepetID
                    WHERE S.MusteriID = @MusteriID;
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@YontemAdi", odemeYontemi);
                        cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                        cmd.Parameters.AddWithValue("@ToplamTutar", toplamTutar);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ödeme işleminiz başarıyla tamamlandı!");
                    FrmMenuGoruntule.sepet.Clear();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
