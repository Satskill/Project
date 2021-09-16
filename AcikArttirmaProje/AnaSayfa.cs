using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Data.SqlClient;

namespace AcikArttirmaProje
{
    public partial class AnaSayfa : Form
    {
        public static int ID;

        int mov, movX, movY;
        private IconButton aktifBtn;
        private Panel solCizgiBtn;
        Baglanti bgln = new Baglanti();





        public AnaSayfa()
        {
            InitializeComponent();
            solCizgiBtn = new Panel();
            solCizgiBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(solCizgiBtn);
            linkLabel1.Visible = false;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 117, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(255, 40, 40);
        }


        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                aktifBtn = (IconButton)senderBtn;
                aktifBtn.BackColor = Color.FromArgb(37, 36, 81);
                aktifBtn.ForeColor = color;
                aktifBtn.TextAlign = ContentAlignment.MiddleCenter;
                aktifBtn.IconColor = color;
                aktifBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                aktifBtn.ImageAlign = ContentAlignment.MiddleRight;

                solCizgiBtn.BackColor = color;
                solCizgiBtn.Location = new Point(0, aktifBtn.Location.Y);
                solCizgiBtn.Visible = true;
                solCizgiBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (aktifBtn != null)
            {

                aktifBtn.BackColor = Color.FromArgb(31, 30, 68);
                aktifBtn.ForeColor = Color.White;
                aktifBtn.TextAlign = ContentAlignment.MiddleLeft;
                aktifBtn.IconColor = Color.White;
                aktifBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                aktifBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Reset()
        {
            DisableButton();
            solCizgiBtn.Visible = false;
        }
        public void getir(Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }
        public void getir5(Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel5.Controls.Add(frm);
            frm.Show();
        }
        public void getir6(Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel6.Controls.Add(frm);
            frm.Show();
        }
        public void getir7(Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel7.Controls.Add(frm);
            frm.Show();
        }















        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            if (GirisYap.TUR == 'K')
            {
                linkLabel1.Visible = true;
            }
            SqlCommand cmd = new SqlCommand("SELECT ID,Ad,Soyad FROM Kullanici WHERE ID='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label2.Text = dr["Ad"].ToString() + " " + dr["Soyad"].ToString() + " Hoşgeldiniz";
            }

            //MessageBox.Show(AnaSayfa.ID.ToString());

            bgln.bagla().Close();
            if (GirisYap.TUR == 'K')
            {
                btnAdminPanel.Visible = false;
                btnUrunEkle.Visible = false;
            }
            else if (GirisYap.TUR == 'S')
            {
                btnAdminPanel.Visible = false;
            }

        }

        //private void btnsylr_Click(object sender, EventArgs e)
        //{

        //    Esyalar esyalar = new Esyalar();
        //    esyalar.Show();
        //    this.Hide();
        //}

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btncksyp_Click(object sender, EventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            this.Hide();
            girisYap.Show();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            ID = 1;
            panel1.Controls.Clear();
            panel1.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            EsyaList esyaList = new EsyaList();
            getir(esyaList);
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            panel1.Controls.Clear();
            panel1.Visible = false;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            Profilim profilim = new Profilim();
            Kartlarim kartlarim = new Kartlarim();
            Adresim adresim = new Adresim();
            getir5(profilim);
            getir6(kartlarim);
            getir7(adresim);
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            ID = 1;
            ActivateButton(sender, RGBColors.color3);
            panel1.Controls.Clear();
            panel1.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            Esyalar esyalar = new Esyalar();
            getir(esyalar);

        }

        private void btnSiparislerim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            panel1.Controls.Clear();
            panel1.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            SatisGerceklestir satisGerceklestir = new SatisGerceklestir();
            getir(satisGerceklestir);
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            panel1.Controls.Clear();
            panel1.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            ID = 0;
            EsyaEkle esyaEkle = new EsyaEkle();
            getir(esyaEkle);

        }


        private void btnAdminPanel_Click(object sender, EventArgs e)
        {

            ActivateButton(sender, RGBColors.color6);
            panel1.Controls.Clear();
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            AdminPaneli adminPaneli = new AdminPaneli();
            getir(adminPaneli);

        }

        private void btnAdreslerim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            panel1.Controls.Clear();
            Adresim adresim = new Adresim();
            getir(adresim);

        }

        private void btnKartlarim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            panel1.Controls.Clear();
            Kartlarim kartlarim = new Kartlarim();
            getir(kartlarim);
        }

        private void btnSatışlarım_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            panel1.Controls.Clear();
            panel1.Visible = true;

            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            Satislarim satislarim = new Satislarim();
            getir(satislarim);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            GirisYap girisYap = new GirisYap();
            this.Hide();
            girisYap.Show();

        }

        private void btnCikis_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
        }

        private void btnCikis_MouseLeave(object sender, EventArgs e)
        {
            Reset();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bgln.bagla();
            SqlCommand talep = new SqlCommand("UPDATE Kullanici SET Talep='1' WHERE ID='" + GirisYap.ID + "'", bgln.bagla());
            talep.ExecuteNonQuery();
            MessageBox.Show("Talebiniz iletildi");
            bgln.bagla().Close();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }

        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
