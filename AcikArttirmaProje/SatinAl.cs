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
    public partial class SatinAl : Form
    {
        Baglanti bgln = new Baglanti();
        int alankisi = 0;
        double sondgr = 0, dgr = 0;
        public SatinAl()
        {
            InitializeComponent();
        }

        private void btndgr_Click(object sender, EventArgs e)
        {
            bgln.bagla();
            try
            {
                //MessageBox.Show(nudesydgr.Value.ToString());
                SqlCommand aadegis = new SqlCommand("UPDATE AATablo SET Tamamlandi=0 ,KisiID='" + GirisYap.ID + "',Fiyat='" + Convert.ToDouble(nudesydgr.Value/* btndgr.Text */) + "' WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
                aadegis.ExecuteNonQuery();
                //sondgr = Convert.ToDouble(nudesydgr.va);
            }
            catch
            {
                //SqlCommand aadegis = new SqlCommand("UPDATE AATablo SET Tamamlandi=0 ,KisiID='" + GirisYap.ID + "',Fiyat='" + nudesydgr.Value/* btndgr.Text */ + "' WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
                //aadegis.ExecuteNonQuery();
                //MessageBox.Show("Değer girişi yapıldı .Yeni değer butona yansıycaktır");
                MessageBox.Show("Değer girişi yapıldı .Yeni değer giriniz");
            }
            bgln.bagla().Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* if (sondgr <= 0 || dgr < sondgr)
             {
                 kontrol();
                 dgr = sondgr;
             }*/
            kontrol();
            //bgln.bagla();
            //SqlCommand aa = new SqlCommand("SELECT AA.KisiID,AA.Fiyat,E.EsyaAdi,AA.Bitis FROM AATablo AA,Esya E WHERE E.ID=AA.EsyaID AND E.ID='" + AnaSayfa.ID + "'", bgln.bagla());
            //SqlDataReader aaoku = aa.ExecuteReader();
            //if (aaoku.Read())
            //{
            //    lblad.Text = aaoku["EsyaAdi"].ToString();
            //    //lbldgr.Text = aaoku["Fiyat"].ToString();
            //    lbldgr.Text = aaoku["Fiyat"].ToString();
            //    lbldgr.Text = lbldgr.Text.Substring(0, lbldgr.Text.Length - 5);
            //    nudesydgr.Minimum = Convert.ToInt32(lbldgr.Text) + 1;
            //    //nudesydgr.Value = Convert.ToInt32(lbldgr.Text);
            //    alankisi = Convert.ToInt32(aaoku["KisiID"]);
            //    if (Convert.ToInt32(aaoku["KisiID"]) == GirisYap.ID)
            //    {
            //        btndgr.Enabled = false;
            //        nudesydgr.Enabled = false;
            //        btndgr.Text = "EN YÜKSEK BAHİS SİZİN";
            //    }
            //    else
            //    {
            //        btndgr.Enabled = true;
            //        nudesydgr.Enabled = true;
            //    }
            //    if (Convert.ToDateTime(aaoku["Bitis"]) <= DateTime.Now)
            //    {
            //        this.Close();
            //        /*SqlCommand aasonuc = new SqlCommand("SELECT KisiID,ID FROM AATablo WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
            //        SqlDataReader aasonucoku = aasonuc.ExecuteReader();
            //        if (aasonucoku.Read())
            //        {
            //            if (Convert.ToInt32(aasonucoku["KisiID"]) == GirisYap.ID)
            //            {
            //                MessageBox.Show("Tebrikler " + lbldgr.Text + " değeri ile alım gerçekleşti");
            //                timer1.Enabled = false;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Maalesef alım işlemini gerçekleştiremediniz");
            //                timer1.Stop();
            //            }
            //            //this.Close();
            //            //timer1.Stop();
            //        }
            //        //timer1.Stop();*/
            //    }
            //    //btndgr.Text = (Convert.ToDouble(aaoku["Fiyat"]) + Convert.ToDouble(aaoku["Fiyat"]) / 20).ToString();
            //}
            //aaoku.Close();
            //bgln.bagla().Close();
        }

        private void SatinAl_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();
            lbldgr.Visible = false;
        }

        private void kontrol()
        {
            bgln.bagla();
            SqlCommand aa = new SqlCommand("SELECT AA.KisiID,AA.Fiyat,E.EsyaAdi,AA.Bitis FROM AATablo AA,Esya E WHERE E.ID=AA.EsyaID AND E.ID='" + AnaSayfa.ID + "'", bgln.bagla());
            SqlDataReader aaoku = aa.ExecuteReader();
            if (aaoku.Read())
            {
                lblad.Text = aaoku["EsyaAdi"].ToString();
                //lbldgr.Text = aaoku["Fiyat"].ToString();
                lbldgr.Text = aaoku["Fiyat"].ToString();
                lbldgr.Text = lbldgr.Text.Substring(0, lbldgr.Text.Length - 5);
                nudesydgr.Minimum = Convert.ToInt32(lbldgr.Text) + 1;
                //nudesydgr.Value = Convert.ToInt32(lbldgr.Text);
                alankisi = Convert.ToInt32(aaoku["KisiID"]);
                if (Convert.ToInt32(aaoku["KisiID"]) == GirisYap.ID)
                {
                    btndgr.Enabled = false;
                    nudesydgr.Enabled = false;
                    btndgr.Text = "EN YÜKSEK BAHİS SİZİN";
                }
                else
                {
                    btndgr.Enabled = true;
                    nudesydgr.Enabled = true;
                }
                if (Convert.ToDateTime(aaoku["Bitis"]) <= DateTime.Now)
                {
                    this.Close();
                    /*SqlCommand aasonuc = new SqlCommand("SELECT KisiID,ID FROM AATablo WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
                    SqlDataReader aasonucoku = aasonuc.ExecuteReader();
                    if (aasonucoku.Read())
                    {
                        if (Convert.ToInt32(aasonucoku["KisiID"]) == GirisYap.ID)
                        {
                            MessageBox.Show("Tebrikler " + lbldgr.Text + " değeri ile alım gerçekleşti");
                            timer1.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Maalesef alım işlemini gerçekleştiremediniz");
                            timer1.Stop();
                        }
                        //this.Close();
                        //timer1.Stop();
                    }
                    //timer1.Stop();*/
                }
                //btndgr.Text = (Convert.ToDouble(aaoku["Fiyat"]) + Convert.ToDouble(aaoku["Fiyat"]) / 20).ToString();
            }
            if (dgr <= 0)
            {
                dgr = Convert.ToInt32(lbldgr.Text);
            }
            if (sondgr > dgr)
            {
                dgr = sondgr;
            }
            aaoku.Close();
            bgln.bagla().Close();
        }

        private void SatinAl_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (alankisi == 0 && timer1.Enabled == false)
            {
                MessageBox.Show("Açık arttırma işlemi bitti lütfen yeni eşya seçiniz");
            }
            else if (alankisi == GirisYap.ID && timer1.Enabled == false)
            {
                MessageBox.Show("Tebrikler alım işlemini başarıyla tamamladınız");
            }
            else if (timer1.Enabled == false)
            {
                MessageBox.Show("Maalesef satın alım işlemini başka kullanıcı tamamladı");
            }
            //bgln.bagla();
            //SqlCommand aa = new SqlCommand("SELECT AA.KisiID,AA.Fiyat,E.EsyaAdi,AA.Bitis FROM AATablo AA,Esya E WHERE E.ID=AA.EsyaID AND E.ID='" + AnaSayfa.ID + "'", bgln.bagla());
            //SqlDataReader aaoku = aa.ExecuteReader();
            //if (aaoku.Read())
            //{
            //    lblad.Text = aaoku["EsyaAdi"].ToString();
            //    lbldgr.Text = aaoku["Fiyat"].ToString();
            //    if (Convert.ToInt32(aaoku["KisiID"]) == GirisYap.ID)
            //    {
            //    btndgr.Enabled = false;
            //    }
            //    else
            //    {
            //        btndgr.Enabled = true;
            //    }
            //    if (Convert.ToDateTime(aaoku["Bitis"]) <= DateTime.Now)
            //    {
            //        //this.Close();
            //        SqlCommand aasonuc = new SqlCommand("SELECT KisiID,ID FROM AATablo WHERE EsyaID='" + AnaSayfa.ID + "'", bgln.bagla());
            //        SqlDataReader aasonucoku = aasonuc.ExecuteReader();
            //        if (aasonucoku.Read())
            //        {
            //            if (Convert.ToInt32(aasonucoku["KisiID"]) == GirisYap.ID)
            //            {
            //                MessageBox.Show("Tebrikler " + lbldgr.Text + " değeri ile alım gerçekleşti");
            //                //timer1.Enabled = false;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Maalesef alım işlemini gerçekleştiremediniz");
            //                //timer1.Stop();
            //            }
            //            //this.Close();
            //            //timer1.Stop();
            //        }
            //        //timer1.Stop();
            //    }
            //    btndgr.Text = (Convert.ToDouble(aaoku["Fiyat"]) + Convert.ToDouble(aaoku["Fiyat"]) / 20).ToString();
            //}
            //bgln.bagla().Close();
        }
    }
}
