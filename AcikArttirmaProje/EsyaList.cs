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
    public partial class EsyaList : Form
    {
        public EsyaList()
        {
            InitializeComponent();
        }
        Resimleme resimleme = new Resimleme();
        Baglanti bgln = new Baglanti();
        Liste[] li;
        int i = 0;

        private void EsyaList_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            //resimgetirdeneme();
            SqlCommand bilgiler = new SqlCommand("SELECT E.ID, E.EsyaAdi, E.EsyaResim, ET.TurAdi, ET.Cins FROM Esya E, EsyaTur ET, AATablo AA WHERE ET.ID = E.EsyaTuru AND E.Aktiflik=1 AND AA.EsyaID=E.ID AND AA.Baslangic<=GETDATE() AND AA.Bitis>=GETDATE()", bgln.bagla());
            SqlDataReader oku = bilgiler.ExecuteReader();

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
                flowLayoutPanel1.Controls.Add(li[i]);

                SqlCommand sure = new SqlCommand("SELECT (DATEDIFF(MINUTE,Baslangic,Bitis)-DATEDIFF(MINUTE,Bitis,GETDATE()))[süre] FROM AATablo WHERE Bitis>=GETDATE() AND EsyaID='" + Convert.ToInt32(li[i].lbl_id.Text) + "'", bgln.bagla());
                SqlDataReader sureoku = sure.ExecuteReader();
                SqlCommand sure2 = new SqlCommand("SELECT DATEDIFF(MINUTE,Baslangic,Bitis)[süre] FROM AATablo WHERE Bitis>=GETDATE() AND EsyaID='" + Convert.ToInt32(li[i].lbl_id.Text) + "'", bgln.bagla());
                SqlDataReader sureoku2 = sure2.ExecuteReader();
                li[i].progressBar1.Visible = false;
                if (sureoku.Read() && sureoku2.Read())
                {
                    li[i].progressBar1.Maximum = Convert.ToInt32(sureoku["süre"]);
                    li[i].progressBar1.Value = Convert.ToInt32(sureoku["süre"]) - Convert.ToInt32(sureoku2["süre"]);


                }

                i++;
            }

            bgln.bagla().Close();
        }


        private void resimgetirdeneme()
        {
            Liste[] listitem = new Liste[5];

            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Liste();
                //listitem[i].label1 = "Deneme";

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(listitem[i]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < i; j++)
            {
                if (li[j].progressBar1.Value == li[j].progressBar1.Maximum)
                {
                    break;
                }
                else
                {
                    li[j].progressBar1.Value += 1;
                }
            }
        }
    }
}
