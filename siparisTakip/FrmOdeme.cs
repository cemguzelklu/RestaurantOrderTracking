using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmOdeme : Form
    {
        public decimal ToplamTutar { get; set; }

        string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

        public FrmOdeme()
        {
            InitializeComponent();
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            lblToplamTutar.Text = $"Ödenecek Tutar: {ToplamTutar:C2}";
        }

        private void rbKart_CheckedChanged(object sender, EventArgs e)
        {
            pnlKartBilgileri.Visible = rbKart.Checked;
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            if (rbKart.Checked && KartBilgileriGecerliMi())
            {
                SiparisOlustur("Kart");
            }
            else if (rbNakit.Checked)
            {
                SiparisOlustur("Nakit");
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
        private int GetOdemeYontemiID(string odemeYontemi)
        {
            int odemeYontemiID = 0;

            string query = "SELECT Id FROM OdemeYontem WHERE YontemAdi = @YontemAdi";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@YontemAdi", odemeYontemi);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            odemeYontemiID = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return odemeYontemiID;
        }


        private void SiparisOlustur(string odemeYontemi)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // 'OdemeYontem' tablosundaki 'YontemAdi' değerine göre ödeme yöntemini alıyoruz
                    string query = @"
                -- Değişkenleri tanımlıyoruz
DECLARE @SiparisID INT;
DECLARE @MusteriID INT = 1; -- Örnek MusteriID, bunu kullanıcıdan alıyorsunuz
DECLARE @ToplamTutar DECIMAL(10, 2) = 150.00; -- Örnek ToplamTutar, bunu hesaplayarak alıyorsunuz
DECLARE @OdemeYontemi NVARCHAR(100) = 'Kredi Kartı'; -- Örnek ödeme yöntemi, kullanıcıdan alıyorsunuz

-- Yeni bir sipariş ekliyoruz ve ID'yi @SiparisID'ye alıyoruz
INSERT INTO Siparis (MusteriID, ToplamTutar)
VALUES (@MusteriID, @ToplamTutar);

-- Son eklenen siparişin ID'sini almak için OUTPUT kullanıyoruz
SET @SiparisID = SCOPE_IDENTITY();

-- Sipariş Detaylarını ekliyoruz
INSERT INTO SiparisDetay (SiparisID, UrunID, Miktar, OdemeYontemID, SiparisDurum)
SELECT @SiparisID, SU.UrunID, SU.Miktar, O.Id, 1 -- Beklemede durumu için '1'
FROM SepetUrun SU
JOIN Sepet S ON S.Id = SU.SepetID
JOIN OdemeYontem O ON O.YontemAdi = @OdemeYontemi -- Ödeme yöntemine göre ID alıyoruz
WHERE S.MusteriID = @MusteriID;


";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                        cmd.Parameters.AddWithValue("@YontemAdi", odemeYontemi);  // Kart ya da Nakit
                        cmd.Parameters.AddWithValue("@Tutar", ToplamTutar);

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
