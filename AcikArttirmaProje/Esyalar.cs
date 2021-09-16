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
    public partial class Esyalar : Form
    {
        Baglanti bgln = new Baglanti();
        public Esyalar()
        {
            InitializeComponent();
        }



        private void Esyalar_Load(object sender, EventArgs e)
        {


            bgln.bagla();
            //SqlCommand esyatur = new SqlCommand("SELECT EsyaTuru FROM Esya WHERE ID='" + AnaSayfa.ID + "'", bgln.bagla());
            //SqlDataReader turoku = esyatur.ExecuteReader();
            //if (turoku.Read()) 
            //{
            SqlCommand fiyat = new SqlCommand("SELECT ET.TurAdi,ET.Cins,S.SatilanFiyat FROM SatisIslemi S,Esya E,EsyaTur ET WHERE S.SatilanEsya=E.ID AND E.EsyaTuru=ET.ID", bgln.bagla());
            SqlDataReader fiyatoku = fiyat.ExecuteReader();
            /*if (fiyatoku.Read())
            {
                chart1.Series.Clear();
                chart1.Series.Add(fiyatoku["TurAdi"].ToString());
                chart1.Series[fiyatoku["TurAdi"].ToString()].Points.AddXY(fiyatoku[0], fiyatoku[1]);
            }
            label1.Text = "Yukarıda " + fiyatoku["TurAdi"].ToString() + " ismi ile yapılmış olan satışların fiyatlarını görmektesiniz";*/
            cmbcns.Items.Clear();
            cmbtr.Items.Clear();
            cmbtr.Items.Add("Hepsi");
            while (fiyatoku.Read())
            {
                cmbcns.Items.Add(fiyatoku["Cins"].ToString());
                cmbtr.Items.Add(fiyatoku["TurAdi"].ToString());
            }
            //}
            bgln.bagla();

        }

        private void cmbcns_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cins = new SqlCommand("SELECT ET.Cins,S.SatilanFiyat,ET.TurAdi FROM SatisIslemi S,Esya E,EsyaTur ET WHERE S.SatilanEsya=E.ID AND E.EsyaTuru=ET.ID AND ET.Cins='" + cmbcns.SelectedItem + "'", bgln.bagla());
            SqlDataReader cinsoku = cins.ExecuteReader();
            if (cinsoku.Read())
            {
                cmbtr.Items.Clear();
                cmbtr.Items.Add("Hepsi");
                cmbtr.Items.Add(cinsoku["TurAdi"].ToString());
                chart1.Series.Clear();
                chart1.Series.Add(cinsoku["Cins"].ToString());
                chart1.Series[cinsoku["Cins"].ToString()].Points.AddXY(cinsoku[0], cinsoku[1]);
            }
            label1.Text = "Yukarıda " + cinsoku["Cins"].ToString() + " cins ismi ile yapılmış olan satışların fiyatlarını görmektesiniz";
        }

        private void cmbtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand tur = new SqlCommand();
            if (cmbtr.SelectedIndex == 0)
            {
                tur = new SqlCommand("SELECT ET.Cins,S.SatilanFiyat FROM SatisIslemi S,Esya E,EsyaTur ET WHERE S.SatilanEsya=E.ID AND E.EsyaTuru=ET.ID AND ET.Cins='" + cmbcns.SelectedItem + "'", bgln.bagla());
            }
            else
            {
                tur = new SqlCommand("SELECT ET.TurAdi,ET.Cins,S.SatilanFiyat FROM SatisIslemi S,Esya E,EsyaTur ET WHERE S.SatilanEsya=E.ID AND E.EsyaTuru=ET.ID AND ET.Cins='" + cmbcns.SelectedItem + "' AND ET.TurAdi='" + cmbtr.SelectedItem + "'", bgln.bagla());
            }
            SqlDataReader turoku = tur.ExecuteReader();
            if (turoku.Read())
            {
                chart1.Series.Clear();
                if (cmbtr.SelectedIndex == 0)
                {
                    chart1.Series.Add(turoku["Cins"].ToString());
                    chart1.Series[turoku["Cins"].ToString()].Points.AddXY(turoku[0], turoku[1]);
                }
                else
                {
                    chart1.Series.Add(turoku["TurAdi"].ToString());
                    chart1.Series[turoku["TurAdi"].ToString()].Points.AddXY(turoku[0], turoku[2]);
                }
            }
            if (cmbtr.SelectedIndex == 0)
                label1.Text = "Yukarıda " + turoku["Cins"].ToString() + " cins ismi ile yapılmış olan satışların fiyatlarını görmektesiniz";
            else
                label1.Text = "Yukarıda " + turoku["Cins"].ToString() + " cinsi ile " + turoku["TurAdi"].ToString() + " türünde yapılmış olan satışların fiyatlarını görmektesiniz";
        }
    }
}
