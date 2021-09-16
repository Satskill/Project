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
    public partial class GirisYap : Form
    {
        Baglanti bgln = new Baglanti();
        int sayac = 0, saniye = 0;
        public static int ID;
        public static char TUR;
        public static string EM;
        public GirisYap()
        {
            InitializeComponent();
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            //txteml.Focus();
            txtsfr.UseSystemPasswordChar = true;
            timer1.Interval = 1000;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUnuttum sifreUnuttum = new SifreUnuttum();
            sifreUnuttum.Show();
            this.Hide();
        }

        private void btnkytol_Click(object sender, EventArgs e)
        {
            KayitOl kayitOl = new KayitOl();
            kayitOl.Show();
            this.Hide();
        }

        private void btngrsyp_Click(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand bilgi = new SqlCommand("SELECT Email,Sifre,KisiID,KullaniciTuru FROM KullaniciGiris WHERE Email='" + txteml.Text + "' AND Sifre='" + txtsfr.Text + "'", bgln.bagla());
            SqlDataReader dr = bilgi.ExecuteReader();
            if (dr.Read())
            {
                if (dr["KullaniciTuru"].ToString() != "X")
                {
                    ID = Convert.ToInt32(dr["KisiID"]);
                    TUR = Convert.ToChar(dr["KullaniciTuru"]);
                    EM = dr["Email"].ToString();
                    sayac = 0;
                    //EsyaDetay esyaDetay = new EsyaDetay();
                    //esyaDetay.Show();
                    AnaSayfa anaSayfa = new AnaSayfa();
                    anaSayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sistemden uzaklaştırıldınız");
                }
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı girişi");
                sayac++;
                if (sayac >= 3)
                {
                    MessageBox.Show("3 defa hatalı giriş yapıldı .30 saniye sistem kilitlendi");
                    btngrsyp.Enabled = false;
                    btnkytol.Enabled = false;
                    //linkLabel1.Enabled = false;
                    
                    timer1.Start();
                }
            }
            bgln.bagla().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtsfr.UseSystemPasswordChar == true)
            {
                txtsfr.UseSystemPasswordChar = false;
            }
            else
            {
                txtsfr.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye >= 30) 
            {
                btnkytol.Enabled = true;
                btngrsyp.Enabled = true;
                timer1.Stop();
            }
        }
    }
}
