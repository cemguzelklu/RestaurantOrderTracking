using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmRaporlama : Form
    {
        public FrmRaporlama()
        {
            InitializeComponent();
        }
        private void RaporGoster(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvRapor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rapor oluşturma hatası: " + ex.Message);
                }
            }
        }




        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            string query = string.Empty;

            switch (cmbRaporTuru.SelectedItem?.ToString())
            {
                case "Günlük Sipariş Raporu":
                    query = @"
                SELECT Urun.UrunAdi, SUM(SepetUrun.Miktar) AS SiparisSayisi
                FROM Siparis 
                JOIN Kullanici ON Siparis.MusteriID = Kullanici.ID
                JOIN Sepet ON Kullanici.ID=Sepet.MusteriID
                JOIN SepetUrun ON Sepet.ID=SepetUrun.SepetID
                JOIN Urun ON Urun.ID = SepetUrun.UrunID
                WHERE CAST(Siparis.SiparisTarihi AS DATE) = CAST(GETDATE() AS DATE)
                GROUP BY Urun.UrunAdi
                ORDER BY SiparisSayisi DESC";
                    break;

                case "Haftalık Sipariş Raporu":
                    query = @"
                SELECT Urun.UrunAdi, SUM(SepetUrun.Miktar) AS SiparisSayisi
FROM Siparis 
JOIN Kullanici ON Siparis.MusteriID = Kullanici.ID
JOIN Sepet ON Kullanici.ID = Sepet.MusteriID
JOIN SepetUrun ON Sepet.ID = SepetUrun.SepetID
JOIN Urun ON Urun.ID = SepetUrun.UrunID
WHERE Siparis.SiparisTarihi >= DATEADD(DAY, -7, GETDATE())
GROUP BY Urun.UrunAdi
ORDER BY SiparisSayisi DESC
";
                    break;

                case "Aylık Sipariş Raporu":
                    query = @"
                SELECT Urun.UrunAdi, SUM(SepetUrun.Miktar) AS SiparisSayisi
FROM Siparis 
JOIN Kullanici ON Siparis.MusteriID = Kullanici.ID
JOIN Sepet ON Kullanici.ID = Sepet.MusteriID
JOIN SepetUrun ON Sepet.ID = SepetUrun.SepetID
JOIN Urun ON Urun.ID = SepetUrun.UrunID
WHERE Siparis.SiparisTarihi >= DATEADD(MONTH, -1, GETDATE())
GROUP BY Urun.UrunAdi
ORDER BY SiparisSayisi DESC";
                    break;

                case "En Çok Satan Ürünler":
                    query = @"
                SELECT TOP 5 Urun.UrunAdi, SUM(SepetUrun.Miktar) AS ToplamSatis
                FROM SepetUrun 
                JOIN Urun ON Urun.ID = SepetUrun.UrunID
                GROUP BY Urun.UrunAdi
                ORDER BY ToplamSatis DESC";
                    break;

                default:
                    MessageBox.Show("Lütfen geçerli bir rapor türü seçin.");
                    return;
            }

            RaporGoster(query);
        }



        private void FrmRaporlama_Load(object sender, EventArgs e)
        {
            cmbRaporTuru.Items.Add("Günlük Sipariş Raporu");
            cmbRaporTuru.Items.Add("Haftalık Sipariş Raporu");
            cmbRaporTuru.Items.Add("Aylık Sipariş Raporu");
            cmbRaporTuru.Items.Add("En Çok Satan Ürünler");
        }
    }
}
