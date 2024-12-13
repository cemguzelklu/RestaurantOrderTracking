using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmUrunSil : Form
    {
        public FrmUrunSil()
        {
            InitializeComponent();
        }

        private void FrmUrunSil_Load(object sender, EventArgs e)
        {
            UrunleriListele();  // Form yüklendiğinde ürünleri listele
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                int urunID = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["ID"].Value);

                string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Urun WHERE ID = @UrunID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UrunID", urunID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ürün başarıyla silindi.");

                        // Listeyi güncelle
                        UrunleriListele();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme hatası: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
            }
        }

        private void UrunleriListele()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, UrunAdi, Fiyat FROM Urun";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUrunler.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
            }
        }
    }
}
