using System;
using System.Configuration;
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
                SiparisOlustur("Kredi Karti İle Ödeme");
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

        private int GetOdemeYontemiID(string odemeYontemi)
        {
            int odemeYontemiID = 0;
            string query = "SELECT Id FROM OdemeYontem WHERE YontemAdi = @YontemAdi";

            using (SqlConnection con = new SqlConnection(connectionString))
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
            return odemeYontemiID;
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
                        cmd.Parameters.AddWithValue("@YontemAdi", odemeYontemi); // "Kapıda Ödeme" veya "Kredi Kartı ile Ödeme"
                        cmd.Parameters.AddWithValue("@MusteriID", 1);  // Örnek MüşteriID
                        cmd.Parameters.AddWithValue("@ToplamTutar", ToplamTutar);

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
