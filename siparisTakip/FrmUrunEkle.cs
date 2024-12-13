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
    public partial class FrmUrunEkle : Form
    {
        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Urun (UrunAdi,Aciklama, Fiyat, KategoriID) VALUES (@UrunAdi,@Aciklama, @Fiyat, @KategoriID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Ürün adı ve fiyat parametreleri
                        cmd.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
                        cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                        cmd.Parameters.AddWithValue("@Fiyat", Convert.ToDecimal(txtFiyat.Text));

                        // Kategori ID kontrol ve ekleme
                        DataRowView selectedRow = cmbKategori.SelectedItem as DataRowView;
                        if (selectedRow != null)
                        {
                            int kategoriID = Convert.ToInt32(selectedRow["ID"]);
                            cmd.Parameters.AddWithValue("@KategoriID", kategoriID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ürün başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Lütfen bir kategori seçin.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            string query = "SELECT Id, KategoriAdi FROM Kategori";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                cmbKategori.DataSource = dt;
                cmbKategori.DisplayMember = "KategoriAdi";  // Görünecek değer
                cmbKategori.ValueMember = "Id";  // Saklanacak değer
                cmbKategori.SelectedIndex = -1;  // Hiçbir öğe seçili olmasın

            }
        }

    }
}
