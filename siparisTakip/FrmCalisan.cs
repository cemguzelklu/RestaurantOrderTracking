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

        private void FrmCalisan_Load(object sender, EventArgs e)
        {
            cmbSiparisDurumu.Items.Add("Beklemede");
            cmbSiparisDurumu.Items.Add("Hazırlanıyor");
            cmbSiparisDurumu.Items.Add("Teslim Edildi");
            cmbSiparisDurumu.SelectedIndex = 0;

            SiparisleriListele();
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
                        U.UrunAdi AS Ürün,
                        K.Ad,
                        K.Adres,
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
                    JOIN Urun U ON SD.UrunId=U.ID
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count > 0)
            {
                int siparisNo = Convert.ToInt32(dgvSiparisler.SelectedRows[0].Cells["SiparisNo"].Value);

                // Mevcut Durumu Al
                string mevcutDurumText = dgvSiparisler.SelectedRows[0].Cells["SiparisDurumu"].Value.ToString();
                int mevcutDurum = DurumIdAl(mevcutDurumText);

                // Yeni Durumu Al
                int yeniDurum = cmbSiparisDurumu.SelectedIndex + 1;

                if (yeniDurum < mevcutDurum)
                {
                    MessageBox.Show("Geriye dönük sipariş durumu güncellemesi yapılamaz!");
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = @"
                UPDATE SiparisDetay
                SET SiparisDurum = @YeniDurum
                WHERE SiparisID = @SiparisNo;
                ";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@SiparisNo", siparisNo);
                            cmd.Parameters.AddWithValue("@YeniDurum", yeniDurum);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Sipariş durumu güncellendi!");

                        // "Teslim Edildi" durumuna geçtiyse satırı sil
                        if (yeniDurum == 3)
                        {
                            dgvSiparisler.Rows.RemoveAt(dgvSiparisler.SelectedRows[0].Index);
                        }
                        else
                        {
                            SiparisleriListele();  // Güncellemeden sonra listeyi yenile
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz siparişi seçin.");
            }
        }

        // Durum Adını İlgili ID'ye Dönüştüren Fonksiyon
        private int DurumIdAl(string siparisDurumu)
        {
            if (siparisDurumu == "Beklemede")
                return 1;
            else if (siparisDurumu == "Hazırlanıyor")
                return 2;
            else if (siparisDurumu == "Teslim Edildi")
                return 3;
            else
                return 0;  // Bilinmeyen durum
        }

        private void btnGunlukRapor_Click(object sender, EventArgs e)
        {
            FrmGunlukRapor frmGunlukRapor=new FrmGunlukRapor();
            frmGunlukRapor.ShowDialog();
        }
    }
}
