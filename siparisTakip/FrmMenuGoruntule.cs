using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmMenuGoruntule : Form
    {
        public FrmMenuGoruntule()
        {
            InitializeComponent();
        }

        private void FrmMenuGoruntule_Load(object sender, EventArgs e)
        {
            KategorileriListele();
        }

        private void KategorileriListele()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, KategoriAdi FROM Kategori";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbKategoriler.DisplayMember = "KategoriAdi";
                    cmbKategoriler.ValueMember = "ID";
                    cmbKategoriler.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori listeleme hatası: " + ex.Message);
                }
            }
        }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriListele(Convert.ToInt32(cmbKategoriler.SelectedValue));
        }


        private void UrunleriListele(int kategoriID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UrunAdi, Fiyat, Aciklama FROM Urun WHERE KategoriID = @KategoriID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@KategoriID", kategoriID);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUrunler.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün listeleme hatası: " + ex.Message);
                }
            }
        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string urunAdi = dgvUrunler.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
                decimal fiyat = Convert.ToDecimal(dgvUrunler.Rows[e.RowIndex].Cells["Fiyat"].Value);

                SepeteEkle(urunAdi, fiyat, 1);  // Miktar: 1
            }

        }
        private void SepeteEkle(string urunAdi, decimal fiyat, int miktar)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"IF EXISTS (SELECT * FROM Sepet WHERE UrunAdi = @UrunAdi)
                             BEGIN
                                 UPDATE Sepet SET Miktar = Miktar + @Miktar, 
                                                  ToplamFiyat = ToplamFiyat + @ToplamFiyat 
                                 WHERE UrunAdi = @UrunAdi
                             END
                             ELSE
                             BEGIN
                                 INSERT INTO Sepet (UrunAdi, Fiyat, Miktar, ToplamFiyat) 
                                 VALUES (@UrunAdi, @Fiyat, @Miktar, @ToplamFiyat)
                             END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        cmd.Parameters.AddWithValue("@Fiyat", fiyat);
                        cmd.Parameters.AddWithValue("@Miktar", miktar);
                        cmd.Parameters.AddWithValue("@ToplamFiyat", fiyat * miktar);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{urunAdi} sepete eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sepete ekleme hatası: " + ex.Message);
                }
            }
        }

    }
}
