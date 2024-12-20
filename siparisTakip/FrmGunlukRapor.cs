using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace siparisTakip
{
    public partial class FrmGunlukRapor : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

        public FrmGunlukRapor()
        {
            InitializeComponent();
        }

        private void FrmGunlukRapor_Load(object sender, EventArgs e)
        {
            GunlukSiparisOzetiniGetir();
        }

        private void GunlukSiparisOzetiniGetir()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = @"
                    SELECT COUNT(*) AS SiparisSayisi, 
                           SUM(S.ToplamTutar) AS ToplamTutar
                    FROM Siparis S
                    WHERE CAST(S.SiparisTarihi AS DATE) = CAST(GETDATE() AS DATE)
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                lblSiparisSayisi.Text = $"Sipariş Sayısı: {dr["SiparisSayisi"]}";
                                lblToplamTutar.Text = $"Toplam Tutar: {Convert.ToDecimal(dr["ToplamTutar"]):C2}";
                            }
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
}

