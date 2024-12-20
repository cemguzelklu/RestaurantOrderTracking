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
            if (string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen e-posta ve şifreyi doldurun.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT k.Id, r.RolAdi FROM Kullanici k " +
                                   "JOIN KullaniciRol cr ON k.Id = cr.KullaniciID " +
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
                            int kullaniciID = Convert.ToInt32(reader["Id"]);
                            string rol = reader["RolAdi"].ToString();

                            if (rol == "Yönetici")
                            {
                                FrmYonetici frmYonetici = new FrmYonetici();
                                frmYonetici.Show();
                            }
                            else if (rol == "Çalışan")
                            {
                                FrmCalisan frmCalisan = new FrmCalisan();
                                frmCalisan.Show();
                            }
                            else if (rol == "Müşteri")
                            {
                                FrmMusteri frmMusteri = new FrmMusteri(kullaniciID);
                                frmMusteri.Show();
                            }
                            this.Hide(); // Login ekranını gizle
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
            this.Hide();
        }
    }
}


