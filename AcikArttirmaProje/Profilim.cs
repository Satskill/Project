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
    public partial class Profilim : Form
    {
        Baglanti bgln = new Baglanti();


        //public void getir(Form frm)
        //{
        //    frm.MdiParent = this;
        //    frm.FormBorderStyle = FormBorderStyle.None;
        //    panel1.Controls.Add(frm);
        //    frm.Show();
        //}

        public Profilim()
        {
            InitializeComponent();
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "yyyy";
            //dateTimePicker1.ShowUpDown = true;
        }

        private void btnkydt_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((DateTime.Now.Year - dateTimePicker1.Value.Year).ToString());
            bgln.bagla();
            SqlCommand yazdir1 = new SqlCommand("UPDATE Kullanici SET Ad=@ad, Soyad=@syd, Sehir=@shr, DogumTarihi=@dt WHERE ID='" + GirisYap.ID + "'", bgln.bagla());
            yazdir1.Parameters.AddWithValue("@ad", txtad.Text);
            yazdir1.Parameters.AddWithValue("@syd", txtsyd.Text);
            yazdir1.Parameters.AddWithValue("@shr", cmshr.SelectedIndex + 1);
            yazdir1.Parameters.AddWithValue("@dt", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            SqlCommand yazdir2 = new SqlCommand("UPDATE KullaniciGiris SET Email=@eml, Sifre=@sfr WHERE Email='" + GirisYap.EM + "'", bgln.bagla());
            yazdir2.Parameters.AddWithValue("@eml", txteml.Text);
            yazdir2.Parameters.AddWithValue("@sfr", txtsfr.Text);
            try
            {
                yazdir1.ExecuteNonQuery();
                yazdir2.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                GirisYap.EM = txteml.Text;
            }
            catch
            {
                MessageBox.Show("E-Mail zaten mevcut bütün kayıtlar yenilenmedi");
                SqlCommand bilgi = new SqlCommand("SELECT K.Ad,K.Soyad,K.DogumTarihi,S.Sehir,KG.Email,KG.Sifre FROM Kullanici K,KullaniciGiris KG, Sehir S WHERE KG.KisiID=K.ID AND S.ID=K.Sehir AND K.ID='" + GirisYap.ID + "'", bgln.bagla());
                SqlDataReader bilgiler = bilgi.ExecuteReader();
                if (bilgiler.Read())
                {
                    txtad.Text = bilgiler["Ad"].ToString();
                    txtsyd.Text = bilgiler["Soyad"].ToString();
                    txteml.Text = bilgiler["Email"].ToString();
                    txtsfr.Text = bilgiler["Sifre"].ToString();
                    cmshr.SelectedItem = bilgiler["Sehir"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(bilgiler["DogumTarihi"]);
                }
            }
            bgln.bagla().Close();
        }

        private void Profilim_Load(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand sehir = new SqlCommand("SELECT Sehir FROM Sehir", bgln.bagla());
            SqlDataReader dr = sehir.ExecuteReader();
            while (dr.Read())
            {
                cmshr.Items.Add(dr["Sehir"]);
            }
            SqlCommand bilgi = new SqlCommand("SELECT K.Ad,K.Soyad,K.DogumTarihi,K.Sehir,KG.Email,KG.Sifre FROM Kullanici K,KullaniciGiris KG WHERE KG.KisiID=K.ID AND K.ID='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader bilgiler = bilgi.ExecuteReader();
            if (bilgiler.Read())
            {
                txtad.Text = bilgiler["Ad"].ToString();
                txtsyd.Text = bilgiler["Soyad"].ToString();
                txteml.Text = bilgiler["Email"].ToString();
                txtsfr.Text = bilgiler["Sifre"].ToString();
                cmshr.SelectedIndex = Convert.ToInt32(bilgiler["Sehir"]) - 1;
                dateTimePicker1.Value = Convert.ToDateTime(bilgiler["DogumTarihi"]);
            }
            bgln.bagla().Close();


            Kartlarim kartlarim = new Kartlarim();
            

        }
    }
}
