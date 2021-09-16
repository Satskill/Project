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
    public partial class Adresim : Form
    {
        Baglanti bgln = new Baglanti();
        ArrayList adreslerim = new ArrayList();
        public Adresim()
        {
            InitializeComponent();
        }

        private void Adresim_Load(object sender, EventArgs e)
        {
            cmbadrslrm.Items.Add("Yeni Kayıt");
            bgln.bagla();
            SqlCommand adresler = new SqlCommand("SELECT ID, AdresAdi FROM Adresim WHERE KisiID='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader adres = adresler.ExecuteReader();
            while (adres.Read())
            {
                cmbadrslrm.Items.Add(adres["AdresAdi"].ToString());
                adreslerim.Add(Convert.ToInt32(adres["ID"]));
            }
            SqlCommand sehirler = new SqlCommand("SELECT Sehir FROM Sehir", bgln.bagla());
            SqlDataReader sehir = sehirler.ExecuteReader();
            while (sehir.Read())
            {
                cmbshr.Items.Add(sehir["Sehir"].ToString());
            }
            bgln.bagla().Close();
        }


        private void cmbadrslrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bgln.bagla();
            try
            {
                SqlCommand adresim = new SqlCommand("SELECT Adres,Sehir FROM Adresim WHERE ID='" + adreslerim[cmbadrslrm.SelectedIndex - 1] + "'", bgln.bagla());
                SqlDataReader adres = adresim.ExecuteReader();
                if (adres.Read())
                {
                    txtadrs.Text = adres["Adres"].ToString();
                    cmbshr.SelectedIndex = Convert.ToInt32(adres["Sehir"]) - 1;
                    txtad.Text = cmbadrslrm.SelectedItem.ToString();
                }
            }
            catch 
            {

                MessageBox.Show("Yeni Kayıt.");
            }
            bgln.bagla().Close();
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {
            bgln.bagla();
            if (cmbadrslrm.SelectedIndex == 0)
            {
                SqlCommand yenikayit = new SqlCommand("INSERT INTO Adresim (Adres,Sehir,KisiID,AdresAdi) VALUES (@adres,@sehir,@kisi,@aadi)", bgln.bagla());
                yenikayit.Parameters.AddWithValue("@adres", txtadrs.Text);
                yenikayit.Parameters.AddWithValue("@sehir", cmbshr.SelectedIndex + 1);
                yenikayit.Parameters.AddWithValue("@kisi", GirisYap.ID);
                yenikayit.Parameters.AddWithValue("@aadi", txtad.Text);
                yenikayit.ExecuteNonQuery();
                MessageBox.Show("Yeni adres kaydı başarrılı");
            }
            else
            {
                SqlCommand yenile = new SqlCommand("UPDATE Adresim SET Adres='" + txtadrs.Text + "',Sehir='" + cmbshr.SelectedIndex + 1 + "',AdresAdi='" + txtad.Text + "' WHERE ID='" + adreslerim[cmbadrslrm.SelectedIndex - 1] + "'", bgln.bagla());
                yenile.ExecuteNonQuery();
                MessageBox.Show("Adres kaydınız yenilendi");
            }
            bgln.bagla().Close();
        }
    }
}
