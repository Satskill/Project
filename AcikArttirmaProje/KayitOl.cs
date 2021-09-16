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

namespace AcikArttirmaProje
{
    public partial class KayitOl : Form
    {
        Baglanti bgln = new Baglanti();
        int kisiid = 0, kytdeneme = 0;
        public KayitOl()
        {
            InitializeComponent();
        }

        private void KayitOl_Load(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand sehir = new SqlCommand("SELECT Sehir FROM Sehir", bgln.bagla());
            SqlDataReader dr = sehir.ExecuteReader();
            while (dr.Read())
            {
                cmbshr.Items.Add(dr["Sehir"]);
            }
            //for (int i = 0; i < 81; i++) 
            //{
            //    cmbshr.Items.Add(dr[i]);
            //}
            bgln.bagla().Close();
        }

        private void btngr_Click(object sender, EventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            girisYap.Show();
            this.Close();
        }

        private void KayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            //GirisYap girisYap = new GirisYap();
            //if(Form.ActiveForm==girisYap)
            //    girisYap.Show();
            
        }

        private void txtsyd_TextChanged(object sender, EventArgs e)
        {
            txtsyd.Text = txtsyd.Text.ToUpper();
            txtsyd.SelectionStart = txtsyd.Text.Length;
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {
            try
            {
                bgln.bagla();
                if (kytdeneme == 0)
                {
                    SqlCommand yaz = new SqlCommand("INSERT INTO Kullanici (Ad,Soyad,DogumTarihi,Sehir) VALUES (@ad,@syd,@dgmtrh,@sehir)", bgln.bagla());
                    yaz.Parameters.AddWithValue("@ad", txtad.Text);
                    yaz.Parameters.AddWithValue("@syd", txtsyd.Text);
                    yaz.Parameters.AddWithValue("@dgmtrh", dgmtrh.Value.ToString("yyyy-MM-dd"));
                    yaz.Parameters.AddWithValue("@sehir", cmbshr.SelectedIndex + 1);
                    yaz.ExecuteNonQuery();
                    kytdeneme++;
                    SqlCommand getir = new SqlCommand("SELECT TOP 1 ID FROM Kullanici ORDER BY ID DESC", bgln.bagla());
                    SqlDataReader dr = getir.ExecuteReader();
                    if (dr.Read())
                        kisiid = Convert.ToInt32(dr["ID"]);
                    SqlCommand yazdir = new SqlCommand("INSERT INTO KullaniciGiris (Email,Sifre,KisiID,KullaniciTuru) VALUES (@email,@sifre,@kisi,@tur)", bgln.bagla());
                    yazdir.Parameters.AddWithValue("@email", txteml.Text);
                    yazdir.Parameters.AddWithValue("@sifre", txtsfr.Text);
                    yazdir.Parameters.AddWithValue("@kisi", kisiid);
                    yazdir.Parameters.AddWithValue("@tur", 'K');
                    yazdir.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı");
                }
                else 
                {
                    SqlCommand yazdir = new SqlCommand("INSERT INTO KullaniciGiris (Email,Sifre,KisiID,KullaniciTuru) VALUES (@email,@sifre,@kisi,@tur)", bgln.bagla());
                    yazdir.Parameters.AddWithValue("@email", txteml.Text);
                    yazdir.Parameters.AddWithValue("@sifre", txtsfr.Text);
                    yazdir.Parameters.AddWithValue("@kisi", kisiid);
                    yazdir.Parameters.AddWithValue("@tur", 'K');
                    yazdir.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı");
                }
            }
            catch 
            {
                MessageBox.Show("E-Mail zaten mevcut");
            }
            bgln.bagla().Close();
        }
    }
}
