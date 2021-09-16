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
using System.IO;
using System.Drawing.Imaging;

namespace AcikArttirmaProje
{
    public partial class EsyaDetay : Form
    {
        Baglanti bgln = new Baglanti();
        int mov, movX, movY;
        public EsyaDetay()
        {
            InitializeComponent();
        }

        private void EsyaDetay_Load(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand bilgiler = new SqlCommand("SELECT E.ID,E.EsyaAdi,E.EsyaTuru,E.EsyaResim,E.EsyaYukliyen,E.Fiyat,E.UretimYili,K.Ad,K.Soyad FROM Esya E,Kullanici K WHERE K.ID=E.EsyaYukliyen AND E.ID='" + AnaSayfa.ID + "'", bgln.bagla());
            SqlDataReader oku = bilgiler.ExecuteReader();
            if (oku.Read())
            {
                SqlCommand cins = new SqlCommand("SELECT TurAdi,Cins FROM EsyaTur WHERE ID='" + Convert.ToInt32(oku["EsyaTuru"]) + "'", bgln.bagla());
                SqlDataReader cinsi = cins.ExecuteReader();
                SqlCommand resimcek = new SqlCommand("SELECT Resim1,Resim2,Resim3 FROM EsyaResim WHERE ID='" + oku["EsyaResim"] + "'", bgln.bagla());
                SqlDataAdapter da = new SqlDataAdapter(resimcek);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Byte[] resimler1 = new byte[0];
                Byte[] resimler2 = new byte[0];
                Byte[] resimler3 = new byte[0];
                resimler1 = (Byte[])(ds.Tables[0].Rows[0][0]);
                resimler2 = (Byte[])(ds.Tables[0].Rows[0][1]);
                resimler3 = (Byte[])(ds.Tables[0].Rows[0][2]);
                MemoryStream m1 = new MemoryStream(resimler1);
                MemoryStream m2 = new MemoryStream(resimler2);
                MemoryStream m3 = new MemoryStream(resimler3);
                pictureBox1.Image = Image.FromStream(m1);
                pictureBox2.Image = Image.FromStream(m2);
                pictureBox3.Image = Image.FromStream(m3);
                if (cinsi.Read())
                {
                    lblesyadi.Text = oku["EsyaAdi"].ToString();
                    lblesycns.Text = cinsi["Cins"].ToString();
                    lblesytr.Text = cinsi["TurAdi"].ToString();
                    lblfyt.Text = oku["Fiyat"].ToString();
                    lblys.Text = (Convert.ToInt32(DateTime.Today.Year) - Convert.ToInt32(oku["UretimYili"])).ToString();
                    lblyklyn.Text = oku["Ad"].ToString() + " " + oku["Soyad"].ToString();
                }
            }
            bgln.bagla().Close();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }
    }
}
