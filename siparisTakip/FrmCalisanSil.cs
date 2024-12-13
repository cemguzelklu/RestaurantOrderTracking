using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmCalisanSil : Form
    {
        public FrmCalisanSil()
        {
            InitializeComponent();
        }

        private void FrmCalisanSil_Load(object sender, EventArgs e)
        {
            CalisanlariListele();
        }

        private void CalisanlariListele()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT K.ID, K.Ad, K.Soyad, K.Eposta, K.TelefonNumarasi, K.Adres 
                 FROM Kullanici K
                 INNER JOIN KullaniciRol CR ON K.ID = CR.KullaniciID
                 WHERE CR.RolID = 2";


                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCalisanlar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvCalisanlar.SelectedRows.Count > 0)
            {
                int kullaniciID = Convert.ToInt32(dgvCalisanlar.SelectedRows[0].Cells["ID"].Value);

                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteQuery = @"DELETE FROM KullaniciRol WHERE KullaniciID = @KullaniciID;
                       DELETE FROM Kullanici WHERE ID = @KullaniciID;";


                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Çalışan başarıyla silindi.");
                        CalisanlariListele();  // Listeyi güncelle
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz çalışanı seçin.");
            }
        }

    }
}
