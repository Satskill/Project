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
    public partial class Kartlarim : Form
    {
        Baglanti bgln = new Baglanti();
        public Kartlarim()
        {
            InitializeComponent();
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {
            bgln.bagla();
            //SqlCommand getir = new SqlCommand("SELECT KartNo FROM KartBilgileri WHERE KisiID='" + GirisYap.ID + "'", bgln.bagla());
            //SqlDataReader nolar = getir.ExecuteReader();
            //while (nolar.Read()) 
            //{
            //    cmbkrtlrm.Items.Add(nolar["KartNo"]);
            //}
            SqlCommand yenikayit = new SqlCommand("INSERT INTO KartBilgileri (KartNo,KartIsmi,SKT,CVC,KisiID) VALUES (@no,@isim,@skt,@cvc,@kid)", bgln.bagla());
            yenikayit.Parameters.AddWithValue("@no", mskdkrtn.Text);
            yenikayit.Parameters.AddWithValue("@isim", txtad.Text);
            yenikayit.Parameters.AddWithValue("@skt", mskdskt.Text);
            yenikayit.Parameters.AddWithValue("@cvc", mskdcvc.Text);
            yenikayit.Parameters.AddWithValue("@kid", GirisYap.ID);
            try
            {
                yenikayit.ExecuteNonQuery();
                MessageBox.Show("Yeni kayıt başarılı");
            }
            catch
            {
                SqlCommand yenile = new SqlCommand("UPDATE KartBilgileri SET KartIsmi='" + txtad.Text + "' ,SKT='" + mskdskt.Text + "' ,CVC='" + mskdcvc.Text + "' WHERE KartNo='" + mskdkrtn.Text + "'", bgln.bagla());
                yenile.ExecuteNonQuery();
                MessageBox.Show("Bilgileriniz güncellenmiştir");
            }
            bgln.bagla().Close();
        }

        private void cmbkrtlrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand getir = new SqlCommand("SELECT KartNo,KartIsmi,SKT,CVC FROM KartBilgileri WHERE KartNo='" + cmbkrtlrm.SelectedItem + "'", bgln.bagla());
            SqlDataReader nolar = getir.ExecuteReader();
            if (nolar.Read())
            {
                txtad.Text = nolar["KartIsmi"].ToString();
                mskdkrtn.Text = nolar["KartNo"].ToString();
                mskdskt.Text = nolar["SKT"].ToString();
                mskdcvc.Text = nolar["CVC"].ToString();
            }
            bgln.bagla().Close();
        }

        private void Kartlarim_Load(object sender, EventArgs e)
        {
            cmbkrtlrm.Items.Add("Yeni Kayıt");
            bgln.bagla();
            SqlCommand getir = new SqlCommand("SELECT KartNo FROM KartBilgileri WHERE KisiID='" + GirisYap.ID + "'", bgln.bagla());
            SqlDataReader nolar = getir.ExecuteReader();
            while (nolar.Read())
            {
                cmbkrtlrm.Items.Add(nolar["KartNo"]);
            }
            bgln.bagla().Close();
        }
    }
}
