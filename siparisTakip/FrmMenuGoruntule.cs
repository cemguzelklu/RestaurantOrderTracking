using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmMenuGoruntule : Form
    {
        public static List<SepetUrun> sepet = new List<SepetUrun>();
        private int musteriID;

        // Kullanıcı giriş yaptıktan sonra kimlik bilgisi alınacak
        public FrmMenuGoruntule(int kullaniciId)
        {
            InitializeComponent();
            musteriID = kullaniciId;
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

        private void cmbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKategoriler.SelectedValue != null)
            {
                UrunleriListele(Convert.ToInt32(cmbKategoriler.SelectedValue));
            }
        }

        private void UrunleriListele(int kategoriID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, UrunAdi, Fiyat, Aciklama FROM Urun WHERE KategoriID = @KategoriID";

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
                int urunID = Convert.ToInt32(dgvUrunler.Rows[e.RowIndex].Cells["ID"].Value);
                string urunAdi = dgvUrunler.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
                decimal fiyat = Convert.ToDecimal(dgvUrunler.Rows[e.RowIndex].Cells["Fiyat"].Value);

                SepeteEkle(musteriID, urunID, 1, urunAdi, fiyat); // Miktar: 1
            }
        }

        private void SepeteEkle(int musteriID, int urunID, int miktar, string urunAdi, decimal fiyat)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    IF NOT EXISTS (SELECT 1 FROM Sepet WHERE MusteriID = @MusteriID)
                    BEGIN
                        INSERT INTO Sepet (MusteriID, OlusturmaTarihi)
                        VALUES (@MusteriID, GETDATE());
                    END

                    DECLARE @SepetID INT;
                    SELECT @SepetID = Id FROM Sepet WHERE MusteriID = @MusteriID;

                    IF EXISTS (SELECT 1 FROM SepetUrun WHERE SepetID = @SepetID AND UrunID = @UrunID)
                    BEGIN
                        UPDATE SepetUrun
                        SET Miktar = Miktar + @Miktar
                        WHERE SepetID = @SepetID AND UrunID = @UrunID;
                    END
                    ELSE
                    BEGIN
                        INSERT INTO SepetUrun (SepetID, UrunID, Miktar)
                        VALUES (@SepetID, @UrunID, @Miktar);
                    END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                        cmd.Parameters.AddWithValue("@UrunID", urunID);
                        cmd.Parameters.AddWithValue("@Miktar", miktar);
                        cmd.ExecuteNonQuery();
                    }

                    // Sepet listesine ekleme
                    var mevcutUrun = sepet.Find(u => u.UrunID == urunID);
                    if (mevcutUrun != null)
                    {
                        mevcutUrun.Miktar += miktar;
                    }
                    else
                    {
                        sepet.Add(new SepetUrun
                        {
                            UrunID = urunID,
                            UrunAdi = urunAdi,
                            Fiyat = fiyat,
                            Miktar = miktar
                        });
                    }

                    MessageBox.Show("Ürün sepete eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sepete ekleme hatası: " + ex.Message);
                }
            }
        }
        private void UrunleriFiltrele()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Dinamik SQL sorgusu
                    string query = @"SELECT ID, UrunAdi, Fiyat, Aciklama 
                             FROM Urun 
                             WHERE 1=1";

                    List<SqlParameter> parameters = new List<SqlParameter>();

                    // Kategori filtresi
                    if (cmbKategoriler.SelectedValue != null && Convert.ToInt32(cmbKategoriler.SelectedValue) > 0)
                    {
                        query += " AND KategoriID = @KategoriID";
                        parameters.Add(new SqlParameter("@KategoriID", cmbKategoriler.SelectedValue));
                    }

                    // Ürün adı araması
                    if (!string.IsNullOrWhiteSpace(txtArama.Text))
                    {
                        query += " AND UrunAdi LIKE @UrunAdi";
                        parameters.Add(new SqlParameter("@UrunAdi", "%" + txtArama.Text.Trim() + "%"));
                    }

                    // Fiyat aralığı filtresi
                    if (numMinFiyat.Value > 0)
                    {
                        query += " AND Fiyat >= @MinFiyat";
                        parameters.Add(new SqlParameter("@MinFiyat", numMinFiyat.Value));
                    }
                    if (numMaxFiyat.Value > 0 && numMaxFiyat.Value >= numMinFiyat.Value)
                    {
                        query += " AND Fiyat <= @MaxFiyat";
                        parameters.Add(new SqlParameter("@MaxFiyat", numMaxFiyat.Value));
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    foreach (var param in parameters)
                    {
                        da.SelectCommand.Parameters.Add(param);
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUrunler.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün arama hatası: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmSepet sepetFormu = new FrmSepet(musteriID);
            sepetFormu.ShowDialog();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            UrunleriFiltrele();
        }
    }
}
