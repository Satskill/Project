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
    public partial class SifreUnuttum : Form
    {
        Baglanti bgln = new Baglanti();
        public SifreUnuttum()
        {
            InitializeComponent();
        }

        private void SifreUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void btnynl_Click(object sender, EventArgs e)
        {
            try
            {
                bgln.bagla();
                SqlCommand degis = new SqlCommand("UPDATE KullaniciGiris SET Sifre='" + txtynsfr.Text + "' WHERE Email='" + txteml.Text + "'", bgln.bagla());
                degis.ExecuteNonQuery();
                MessageBox.Show("Yeni şifreniz : " + txtynsfr.Text);
                bgln.bagla().Close();
            }
            catch
            {
                MessageBox.Show("Hatalı E-Mail");
            }
        }

        private void btngr_Click(object sender, EventArgs e)
        {

        }

        private void SifreUnuttum_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            if (Form.ActiveForm == girisYap)
                girisYap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            girisYap.Show();
            this.Close();
        }
    }
}
