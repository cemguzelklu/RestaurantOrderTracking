using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmUrunGuncelle : Form
    {
        public FrmUrunGuncelle()
        {
            InitializeComponent();
        }

        private void FrmUrunGuncelle_Load(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, UrunAdi, Fiyat, Aciklama FROM Urun";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUrunler.DataSource = dt;
                    dgvUrunler.Columns["ID"].Visible = false;  // ID sütununu gizle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listeleme hatası: " + ex.Message);
                }
            }
        }

        private void dgvUrunler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                txtFiyat.Text = dgvUrunler.SelectedRows[0].Cells["Fiyat"].Value.ToString();
                txtUrun.Text = dgvUrunler.SelectedRows[0].Cells["Aciklama"].Value.ToString();
            }
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
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
                        string query = "UPDATE Urun SET Fiyat = @Fiyat, Aciklama = @Aciklama WHERE ID = @UrunID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Fiyat", Convert.ToDecimal(txtFiyat.Text));
                            cmd.Parameters.AddWithValue("@Aciklama", txtUrun.Text);
                            cmd.Parameters.AddWithValue("@UrunID", urunID);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ürün başarıyla güncellendi.");
                        UrunleriListele();  // Listeyi güncelle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme hatası: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz ürünü seçin.");
            }
        }
    }
}
