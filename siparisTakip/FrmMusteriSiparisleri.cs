using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmMusteriSiparisleri : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;
        int musteriId;  // Müşteri giriş yaptığında bu değer atanacak

        public FrmMusteriSiparisleri(int kullaniciId)
        {
            InitializeComponent();
            musteriId = kullaniciId;  // Giriş yapan müşterinin ID'sini al
        }

        private void FrmMusteriSiparisleri_Load(object sender, EventArgs e)
        {
            SiparisleriListele();
        }



        private void SiparisleriListele()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"
    SELECT 
        U.UrunAdi AS Ürün,
        S.ToplamTutar,
        CASE 
            WHEN SD.SiparisDurum = 1 THEN 'Beklemede'
            WHEN SD.SiparisDurum = 2 THEN 'Hazırlanıyor'
            WHEN SD.SiparisDurum = 3 THEN 'Teslim Edildi'
            ELSE 'Bilinmiyor'
        END AS SiparisDurumu
    FROM Kullanici K
    JOIN Siparis S ON K.Id = S.MusteriID
    JOIN SiparisDetay SD ON S.Id = SD.SiparisID
    JOIN Urun U ON SD.UrunId = U.ID
    WHERE K.Id = @MusteriId
    ORDER BY S.Id DESC;";


                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@MusteriId", musteriId);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgvMusteriSiparisleri.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Herhangi bir sipariş bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

    }
}
