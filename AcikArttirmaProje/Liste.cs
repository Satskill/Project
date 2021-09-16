using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcikArttirmaProje
{
    public partial class Liste : UserControl
    {
        public Liste()
        {
            InitializeComponent();
        }
        public static int ID;

        private void btn_detay_MouseHover(object sender, EventArgs e)
        {
            btn_detay.BackgroundImage = Properties.Resources.Başlıksız_1;
            btn_detay.Text = "Detaylar";
            btn_detay.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void btn_detay_MouseLeave(object sender, EventArgs e)
        {
            btn_detay.BackgroundImage = Properties.Resources.icons8_documents_64px;
            btn_detay.Text = "";
        }

        private void btn_satin_al_MouseHover(object sender, EventArgs e)
        {
            btn_satin_al.BackgroundImage = Properties.Resources.Başlıksız_1;
            btn_satin_al.Text = "Satın Al";
            btn_satin_al.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void btn_satin_al_MouseLeave(object sender, EventArgs e)
        {
            btn_satin_al.BackgroundImage = Properties.Resources.icons8_shopping_cart_64px;
            btn_satin_al.Text = "";
        }

        private void btn_detay_Click(object sender, EventArgs e)
        {
            AnaSayfa.ID = Convert.ToInt32(lbl_id.Text);
            EsyaDetay esyaDetay = new EsyaDetay();
            esyaDetay.Show();
        }

        private void btn_satin_al_Click(object sender, EventArgs e)
        {
            AnaSayfa.ID = Convert.ToInt32(lbl_id.Text);

            //AnaSayfa anaSayfa = new AnaSayfa();

            if (Form.ActiveForm == SatinAl.ActiveForm)
            {
                SatinAl satinAl = new SatinAl();
                satinAl.Show();
            }
            else
            {
                SatinAl satinAl = new SatinAl();
                satinAl.Close();
            }
        }
    }
}
