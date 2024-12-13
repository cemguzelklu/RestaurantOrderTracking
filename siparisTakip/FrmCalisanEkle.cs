using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmCalisanEkle : Form
    {
        public FrmCalisanEkle()
        {
            InitializeComponent();
        }

        private void btnCalisanKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kullanıcıyı Ekle
                    string insertUserQuery = "INSERT INTO Kullanici (Ad, Soyad, Eposta, Sifre, TelefonNumarasi, Adres) " +
                                             "VALUES (@Ad, @Soyad, @Eposta, @Sifre, @TelefonNumarasi, @Adres); " +
                                             "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                        cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                        cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                        cmd.Parameters.AddWithValue("@TelefonNumarasi", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);

                        int kullaniciID = Convert.ToInt32(cmd.ExecuteScalar());

                        // Çalışan Rolünü Ekle
                        string insertRoleQuery = "INSERT INTO KullaniciRol (KullaniciID, RolID) VALUES (@KullaniciID, 2)";
                        using (SqlCommand roleCmd = new SqlCommand(insertRoleQuery, conn))
                        {
                            roleCmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                            roleCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Çalışan başarıyla eklendi!");
                        this.Close(); // Formu kapat
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
