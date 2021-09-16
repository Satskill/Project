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
using System.Collections;

namespace AcikArttirmaProje
{
    public partial class Satislarim : Form
    {
        Baglanti bgln = new Baglanti();
        ArrayList esyalarim = new ArrayList();
        ArrayList satislarim = new ArrayList();
        int ID;
        public Satislarim()
        {
            InitializeComponent();
        }

        private void btnkydt_Click(object sender, EventArgs e)
        {
            if (cmbxsts.SelectedIndex >= 1 && (dtpbslngc.Value <= dtpbts.Value))
            {
                try
                {
                    DateTime baslangic = new DateTime(dtpbslngc.Value.Year, dtpbslngc.Value.Month, dtpbslngc.Value.Day, Convert.ToInt32(mtxtbslngc.Text.Substring(0, 2)), Convert.ToInt32(mtxtbslngc.Text.Substring(3, 2)), 0);
                    DateTime bitis = new DateTime(dtpbts.Value.Year, dtpbts.Value.Month, dtpbts.Value.Day, Convert.ToInt32(mtxtbts.Text.Substring(0, 2)), Convert.ToInt32(mtxtbts.Text.Substring(3, 2)), 0);
                    //SqlCommand satisyenilee = new SqlCommand("UPDATE AATablo SET Baslangic=@bas,Bitis=@bitis WHERE EsyaID=@eid", bgln.bagla());
                    //satisyenilee.Parameters.AddWithValue("@bas", null);
                    //satisyenilee.Parameters.AddWithValue("@bitis", null);
                    //satisyenilee.Parameters.AddWithValue("@eid", satislarim[cmbxsts.SelectedIndex - 1]);
                    //satisyenilee.ExecuteNonQuery();
                    SqlCommand satisyenile = new SqlCommand("UPDATE AATablo SET Baslangic=@bas,Bitis=@bitis WHERE EsyaID=@eid", bgln.bagla());
                    satisyenile.Parameters.AddWithValue("@bas", Convert.ToDateTime(baslangic.Year + "-" + baslangic.Month + "-" + baslangic.Day + " " + baslangic.Hour + ":" + baslangic.Minute + ":" + baslangic.Second));
                    satisyenile.Parameters.AddWithValue("@bitis", Convert.ToDateTime(bitis.Year + "-" + bitis.Month + "-" + bitis.Day + " " + bitis.Hour + ":" + bitis.Minute + ":" + bitis.Second));
                    satisyenile.Parameters.AddWithValue("@eid", satislarim[cmbxsts.SelectedIndex - 1]);
                    satisyenile.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Yenileme Başarılı");
                }
                catch
                {
                    MessageBox.Show("Lütfen Tarih ve saat bilgilerini kontrol edin");
                }
            }
            else if (cmbxesy.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen satılacak eşyayı seçiniz");
            }
            else if (dtpbslngc.Value > dtpbts.Value || Convert.ToDateTime(dtpbslngc.Value.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("Başlangıç tarihini kontrol ediniz");
            }
            else
            {
                //MessageBox.Show(lblfyt.Text);
                try
                {
                    DateTime baslangic = new DateTime(dtpbslngc.Value.Year, dtpbslngc.Value.Month, dtpbslngc.Value.Day, Convert.ToInt32(mtxtbslngc.Text.Substring(0, 2)), Convert.ToInt32(mtxtbslngc.Text.Substring(3, 2)), 0);
                    DateTime bitis = new DateTime(dtpbts.Value.Year, dtpbts.Value.Month, dtpbts.Value.Day, Convert.ToInt32(mtxtbts.Text.Substring(0, 2)), Convert.ToInt32(mtxtbts.Text.Substring(3, 2)), 0);
                    SqlCommand satisekle = new SqlCommand("INSERT INTO AATablo (EsyaID,KisiID,Baslangic,Bitis,Fiyat) VALUES (@esya,@kisi,@baslangic,@bitis,@fiyat)", bgln.bagla());
                    satisekle.Parameters.AddWithValue("@esya", esyalarim[cmbxesy.SelectedIndex]);
                    satisekle.Parameters.AddWithValue("@kisi", GirisYap.ID);
                    satisekle.Parameters.AddWithValue("@baslangic", Convert.ToDateTime(baslangic.Year + "-" + baslangic.Month + "-" + baslangic.Day + " " + baslangic.Hour + ":" + baslangic.Minute + ":" + baslangic.Second)/*(dtpbslngc.Value).ToString("yyyy-MM-dd") +" "+ mtxtbslngc.Text.Substring(0,2)+":"+mtxtbslngc.Text.Substring(3,2)+":"+"00"*/);
                    satisekle.Parameters.AddWithValue("@bitis", Convert.ToDateTime(bitis.Year + "-" + bitis.Month + "-" + bitis.Day + " " + bitis.Hour + ":" + bitis.Minute + ":" + bitis.Second)/*(dtpbts.Value).ToString("yyyy-MM-dd") + " " + mtxtbts.Text.Substring(0,2)+":"+mtxtbts.Text.Substring(3,2)+":"+"00"*/);
                    satisekle.Parameters.AddWithValue("@fiyat", Convert.ToDouble(lblfyt.Text));
                    satisekle.ExecuteNonQuery();
                    MessageBox.Show("Yeni Kayıt Başarılı");
                }
                catch
                {
                    MessageBox.Show("Eşya ve Tarih bilgisi kontrol ediniz ve Yeni Satış seçtiğinizden emin olunuz");
                }
            }
        }

        private void btnkldr_Click(object sender, EventArgs e)
        {
            if (cmbxsts.SelectedIndex >= 1)
            {
                SqlCommand satisis = new SqlCommand("DELETE FROM AATablo WHERE ID='" + satislarim[cmbxsts.SelectedIndex - 1] + "'", bgln.bagla());
                satisis.ExecuteNonQuery();
                satislarim.Remove(cmbxsts.SelectedIndex - 1);
                cmbxsts.Items.Remove(cmbxsts.SelectedIndex);
                cmbxsts.SelectedIndex = -1;
                MessageBox.Show("Silme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Kaldırmak istediğiniz satışı seçiniz");
            }
        }

        private void cmbxsts_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgln.bagla();
            try
            {
                SqlCommand satislar = new SqlCommand("SELECT Baslangic,Bitis FROM AATablo WHERE ID='" + satislarim[cmbxsts.SelectedIndex - 1] + "'", bgln.bagla());
                SqlDataReader satisoku = satislar.ExecuteReader();
                if (satisoku.Read())
                {
                    string secilitarih = satisoku["Baslangic"].ToString();
                    dtpbslngc.Value = Convert.ToDateTime(secilitarih.Substring(0, 10));
                    mtxtbslngc.Text = secilitarih.Substring(9, 5).ToString();
                    secilitarih = satisoku["Bitis"].ToString();
                    dtpbts.Value = Convert.ToDateTime(secilitarih.Substring(0, 10));
                    mtxtbts.Text = secilitarih.Substring(9, 5).ToString();
                }
                SqlCommand esyalar = new SqlCommand("SELECT E.EsyaAdi,E.Fiyat,E.UretimYili,ET.Cins,ET.TurAdi FROM Esya E,EsyaTur ET,AATablo AA WHERE E.EsyaTuru=ET.ID AND AA.EsyaID=E.ID AND AA.ID='" + satislarim[cmbxsts.SelectedIndex - 1] + "'", bgln.bagla());
                SqlDataReader esyaoku = esyalar.ExecuteReader();
                if (esyaoku.Read())
                {
                    lblyl.Text = esyaoku["UretimYili"].ToString();
                    lblfyt.Text = esyaoku["Fiyat"].ToString();
                    lblesytr.Text = esyaoku["TurAdi"].ToString() + " / " + esyaoku["Cins"].ToString();
                    cmbxesy.SelectedItem = esyaoku["EsyaAdi"].ToString();
                }
            }
            catch
            {
                dtpbslngc.Value = DateTime.Now.Date;
                dtpbts.Value = DateTime.Now.Date;
                mtxtbslngc.Text = null;
                mtxtbts.Text = null;
            }
            bgln.bagla().Close();
        }

        private void cmbxesy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand esyalar = new SqlCommand("SELECT E.EsyaAdi,E.Fiyat,E.UretimYili,ET.Cins,ET.TurAdi FROM Esya E,EsyaTur ET WHERE E.EsyaTuru=ET.ID AND E.ID='" + esyalarim[cmbxesy.SelectedIndex] + "'", bgln.bagla());
            SqlDataReader esyaoku = esyalar.ExecuteReader();
            if (esyaoku.Read())
            {
                lblyl.Text = esyaoku["UretimYili"].ToString();
                lblfyt.Text = esyaoku["Fiyat"].ToString();
                lblesytr.Text = esyaoku["TurAdi"].ToString() + " / " + esyaoku["Cins"].ToString();

            }
            bgln.bagla().Close();
        }

        private void btndty_Click(object sender, EventArgs e)
        {
            try
            {
                AnaSayfa.ID = Convert.ToInt32(esyalarim[cmbxesy.SelectedIndex]);
                EsyaDetay esyaDetay = new EsyaDetay();
                esyaDetay.Show();
            }
            catch
            {

                MessageBox.Show("Eşya Seçmeyi Unuttunuz.");
            }
        }

        private void Satislarim_Load(object sender, EventArgs e)
        {


            cmbxsts.Items.Add("Yeni Satış");
            bgln.bagla();
            SqlCommand esyalar = new SqlCommand("SELECT ID,EsyaAdi FROM Esya WHERE EsyaYukliyen='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader esyaoku = esyalar.ExecuteReader();
            while (esyaoku.Read())
            {
                cmbxesy.Items.Add(esyaoku["EsyaAdi"].ToString());
                esyalarim.Add(Convert.ToInt32(esyaoku["ID"]));
            }
            SqlCommand satislar = new SqlCommand("SELECT AA.ID,E.EsyaAdi FROM AATablo AA,Esya E WHERE AA.EsyaID=E.ID AND AA.KisiID='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader satisoku = satislar.ExecuteReader();
            while (satisoku.Read())
            {
                cmbxsts.Items.Add(satisoku["ID"].ToString() + " - " + satisoku["EsyaAdi"].ToString());
                satislarim.Add(Convert.ToInt32(satisoku["ID"]));
            }
            bgln.bagla().Close();
        }

        private void btnkldr_MouseHover(object sender, EventArgs e)
        {
            btnkldr.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnkldr_MouseLeave(object sender, EventArgs e)
        {
            btnkldr.BackColor = Color.FromArgb(37, 36, 81);
        }

        private void btnkydt_MouseHover(object sender, EventArgs e)
        {
            btnkydt.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnkydt_MouseLeave(object sender, EventArgs e)
        {

            btnkydt.BackColor = Color.FromArgb(37, 36, 81);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {

                AnaSayfa.ID = Convert.ToInt32(esyalarim[cmbxesy.SelectedIndex]);
                EsyaEkle esyaEkle = new EsyaEkle();
                esyaEkle.Show();
            }
            catch
            {

                MessageBox.Show("Eşya Seçmeyi Unuttunuz.");
            }
        }
    }
}
