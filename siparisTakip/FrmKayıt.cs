﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace siparisTakip
{
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtEposta.Text) || string.IsNullOrEmpty(txtSifre.Text) ||
                string.IsNullOrEmpty(txtTelefon.Text) || string.IsNullOrEmpty(txtAdres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // Şifre doğrulama: En az bir büyük harf, bir küçük harf ve 8 karakter
            string password = txtSifre.Text;
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Şifre en az bir büyük harf, bir küçük harf ve 8 karakter içermelidir.");
                return;
            }

            // Veritabanı bağlantısı
            string connectionString = ConfigurationManager.ConnectionStrings["RestoranConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL Sorgusu
                    string query = "INSERT INTO Kullanici (Ad, Soyad, Eposta, Sifre, TelefonNumarasi, Adres) " +
                                   "VALUES (@Ad, @Soyad, @Eposta, @Sifre, @TelefonNumarasi, @Adres); " +
                                   "DECLARE @KullaniciID INT = SCOPE_IDENTITY(); " +
                                   "INSERT INTO KullaniciRol (KullaniciID, RolID) VALUES (@KullaniciID, 3);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                        cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                        cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                        cmd.Parameters.AddWithValue("@TelefonNumarasi", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);

                        // Veriyi veritabanına ekle
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarılı!");

                        // Kayıt sonrası, giriş ekranına yönlendirme
                        this.Hide();
                        FrmLogin frmLogin = new FrmLogin();
                        frmLogin.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }
        }

        // Şifre doğrulama fonksiyonu
        private bool IsValidPassword(string password)
        {            // deneme
            // Şifrede en az bir büyük harf, bir küçük harf ve 8 karakter olmalı
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
