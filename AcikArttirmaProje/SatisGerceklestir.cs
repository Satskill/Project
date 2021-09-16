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
using System.IO;

namespace AcikArttirmaProje
{
    public partial class SatisGerceklestir : Form
    {
        Baglanti bgln = new Baglanti();
        ArrayList adreslerim = new ArrayList();
        Liste[] li;
        int i = 0;
        int esyaid;
        public SatisGerceklestir()
        {
            InitializeComponent();
        }

        private void btnstnal_Click(object sender, EventArgs e)
        {
            bgln.bagla();
            try
            {
                SqlCommand satisekle = new SqlCommand("INSERT INTO SatisIslemi (SatilanEsya,SatinAlan,Adres,SatilanFiyat,KartBilgi,Tamamlandi) VALUES (@esya,@alan,@adres,@fiyat,@kart,@tamam)", bgln.bagla());
                satisekle.Parameters.AddWithValue("@esya", AnaSayfa.ID);
                satisekle.Parameters.AddWithValue("@alan", GirisYap.ID);
                satisekle.Parameters.AddWithValue("@adres", adreslerim[cmbadrs.SelectedIndex]);
                satisekle.Parameters.AddWithValue("@fiyat", Convert.ToDouble(lblfyt.Text));
                satisekle.Parameters.AddWithValue("@kart", cmbkrt.SelectedItem);
                satisekle.Parameters.AddWithValue("@tamam", 1);
                satisekle.ExecuteNonQuery();
                SqlCommand satisbitir = new SqlCommand("UPDATE AATablo SET Tamamlandi = 1 WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
                satisbitir.ExecuteNonQuery();
                MessageBox.Show("Satın Alma İşleminiz Gerçekleşti.");

            }
            catch
            {
                MessageBox.Show("Lütfen bilgi girişinin doğru olduğuna emin olunuz(Adres/Kart Bilgileri)");
            }
            bgln.bagla().Close();
        }

        private void btnkrtekl_Click(object sender, EventArgs e)
        {
            Kartlarim kartlarim = new Kartlarim();
            kartlarim.Show();
        }

        private void btnadrsekl_Click(object sender, EventArgs e)
        {
            Adresim adresim = new Adresim();
            adresim.Show();
        }

        private void btnesydty_Click(object sender, EventArgs e)
        {
            EsyaDetay esyaDetay = new EsyaDetay();
            esyaDetay.Show();


        }

        private void SatisGerceklestir_Load(object sender, EventArgs e)
        {
            cmbkrt.Items.Clear();
            cmbadrs.Items.Clear();

            bgln.bagla();
            //BURDAN AŞAĞISI DÜZENLENİCEK !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            try
            {
                SqlCommand bilgiler = new SqlCommand("SELECT E.ID, E.EsyaAdi, E.EsyaResim, ET.TurAdi, ET.Cins,AA.KisiID FROM Esya E, EsyaTur ET, AATablo AA WHERE E.ID=AA.EsyaID AND ET.ID = E.EsyaTuru AND AA.KisiID='" + GirisYap.ID + "' AND AA.Tamamlandi=0", bgln.bagla());
                SqlDataReader oku = bilgiler.ExecuteReader();
                SqlCommand bilgiler2 = new SqlCommand("SELECT E.ID, E.EsyaAdi, E.EsyaResim, ET.TurAdi, ET.Cins,AA.KisiID,AA.Bitis,SI.Tamamlandi FROM Esya E, EsyaTur ET, AATablo AA,SatisIslemi SI WHERE SI.SatilanEsya=E.ID AND E.ID=AA.EsyaID AND ET.ID = E.EsyaTuru AND AA.Bitis<=GETDATE() AND AA.KisiID='" + GirisYap.ID + "' AND SI.Tamamlandi!=1", bgln.bagla());
                SqlDataReader oku3 = bilgiler2.ExecuteReader();

                SqlCommand toplam = new SqlCommand("SELECT COUNT(ID)[id] FROM Esya", bgln.bagla());
                SqlDataReader oku2 = toplam.ExecuteReader();

                if (oku2.Read())
                {


                    //MessageBox.Show(oku2["id"].ToString());
                    //toplam = oku2["id"];

                    li = new Liste[Convert.ToInt32(oku2["id"])];

                }

                //if (oku.Read())



                while (oku.Read())
                {
                    //for (int i = 0; i < Convert.ToInt32(oku2["id"]); i++)

                    li[i] = new Liste();
                    //MessageBox.Show(oku["EsyaAdi"].ToString());
                    li[i].lbl_Esya_Adi.Text = oku["EsyaAdi"].ToString();
                    li[i].lbl_id.Text = oku["ID"].ToString();
                    li[i].lbl_tur.Text = oku["TurAdi"].ToString() + " / " + oku["Cins"].ToString();
                    SqlCommand resimcek = new SqlCommand("SELECT E.ID,ER.Resim1 FROM EsyaResim ER, Esya E WHERE E.EsyaResim=ER.ID AND E.ID='" + li[i].lbl_id.Text + "'", bgln.bagla());
                    SqlDataAdapter da = new SqlDataAdapter(resimcek);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Byte[] resimler1 = new byte[0];
                    resimler1 = (Byte[])(ds.Tables[0].Rows[0][1]);
                    MemoryStream m1 = new MemoryStream(resimler1);
                    li[i].pictureBox1.Image = Image.FromStream(m1);
                    //li.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //li.pictureBox1.Image = resimleme.ResimGetirme(oku[""].);
                    li[i].btn_satin_al.Visible = false;
                    li[i].progressBar1.Visible = false;
                    panel1.Controls.Add(li[i]);

                    AnaSayfa.ID = Convert.ToInt32(li[i].lbl_id.Text);
                    i++;
                }





                SqlCommand adresler = new SqlCommand("SELECT ID,AdresAdi FROM Adresim WHERE KisiID='" + GirisYap.ID + "'", bgln.bagla());
                SqlDataReader adresoku = adresler.ExecuteReader();
                while (adresoku.Read())
                {
                    cmbadrs.Items.Add(adresoku["AdresAdi"].ToString());
                    adreslerim.Add(Convert.ToInt32(adresoku["ID"]));
                }
                SqlCommand kartlar = new SqlCommand("SELECT KartNo FROM KartBilgileri WHERE KisiID='" + GirisYap.ID + "'", bgln.bagla());
                SqlDataReader kartoku = kartlar.ExecuteReader();
                while (kartoku.Read())
                {
                    cmbkrt.Items.Add(kartoku["KartNo"].ToString());
                }
                SqlCommand fiyat = new SqlCommand("SELECT Fiyat FROM AATablo WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());

                SqlDataReader fiyatoku = fiyat.ExecuteReader();
                if (fiyatoku.Read())
                {
                    lblfyt.Text = fiyatoku["Fiyat"].ToString();
                }

            }
            catch
            {
                MessageBox.Show("Yeni Satış gerçekleştirmelisiniz");
            }
            bgln.bagla().Close();





        }

        private void cmbadrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand adresbilgi = new SqlCommand("SELECT A.Adres,S.Sehir FROM Adresim A,Sehir S WHERE A.Sehir=S.ID AND A.ID='" + adreslerim[cmbadrs.SelectedIndex] + "'", bgln.bagla());
            SqlDataReader adresim = adresbilgi.ExecuteReader();
            if (adresim.Read())
            {
                lbladrs.Text = adresim["Adres"].ToString();
                lblshr.Text = adresim["Sehir"].ToString();
            }
            bgln.bagla().Close();
        }

        private void cmbkrt_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand kartbilgi = new SqlCommand("SELECT KartIsmi,SKT,CVC FROM KartBilgileri WHERE KartNo='" + cmbkrt.SelectedItem + "'", bgln.bagla());
            SqlDataReader kartim = kartbilgi.ExecuteReader();
            if (kartim.Read())
            {
                lblkrtad.Text = kartim["KartIsmi"].ToString();
                lblskt.Text = kartim["SKT"].ToString();
                lblcvc.Text = kartim["CVC"].ToString();
            }
            bgln.bagla().Close();
        }

        private void btnstnal_MouseHover(object sender, EventArgs e)
        {
            btnstnal.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnstnal_MouseLeave(object sender, EventArgs e)
        {
            btnstnal.BackColor = Color.FromArgb(37, 36, 81);
        }
    }
}
