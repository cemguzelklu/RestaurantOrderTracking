using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace siparisTakip
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Giriş Boş Kontrolü
            if (string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen e-posta ve şifreyi doldurun.");
                return;  // İşlemi durdur
            }

            // Veritabanı bağlantısı
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT r.RolAdi FROM Kullanici k " +
                                   "JOIN CalisanRol cr ON k.Id = cr.KullaniciID " +
                                   "JOIN Rol r ON cr.RolID = r.Id " +
                                   "WHERE Eposta = @Eposta AND Sifre = @Sifre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                        cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string rol = reader["RolAdi"].ToString();

                            // Yönetici ise ana sayfaya yönlendir
                            if (rol == "Yönetici")
                            {
                                FrmAna frmAna = new FrmAna();
                                frmAna.Show();
                                this.Hide(); // Giriş ekranını gizle
                            }
                            else if (rol == "Çalışan")
                            {
                                // Çalışan için sayfa açılabilir
                                FrmCalisan frmCalisan = new FrmCalisan();
                                frmCalisan.Show();
                                this.Hide(); // Giriş ekranını gizle
                            }
                            else if (rol == "Müşteri")
                            {
                                // Müşteri için sayfa açılabilir
                                FrmMusteri frmMusteri = new FrmMusteri();
                                frmMusteri.Show();
                                this.Hide(); // Giriş ekranını gizle
                            }
                        }
                        else
                        {
                            MessageBox.Show("Geçersiz e-posta veya şifre.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }
       



        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FrmKayıt frmKayıt = new FrmKayıt();
            frmKayıt.Show();
        }
    }
}


