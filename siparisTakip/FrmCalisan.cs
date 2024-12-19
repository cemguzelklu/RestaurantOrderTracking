using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmCalisan : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

        public FrmCalisan()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
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
                        S.Id AS SiparisNo,
                        S.MusteriID,
                        S.ToplamTutar,
                        CASE 
                            WHEN SD.SiparisDurum = 1 THEN 'Beklemede'
                            WHEN SD.SiparisDurum = 2 THEN 'Hazırlanıyor'
                            WHEN SD.SiparisDurum = 3 THEN 'Teslim Edildi'
                            ELSE 'Bilinmiyor'
                        END AS SiparisDurumu
                    FROM Siparis S
                    JOIN SiparisDetay SD ON S.Id = SD.SiparisID
                    ORDER BY S.Id DESC;
                    ";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSiparisler.DataSource = dt;
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
