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
    public partial class AdminPaneli : Form
    {
        Baglanti bgln = new Baglanti();
        int hangisi = 0;
        public AdminPaneli()
        {
            InitializeComponent();
        }

        private void btnkslr_Click(object sender, EventArgs e)
        {
            hangisi = 1;
            kisilerbutonu();
        }

        private void btnesylr_Click(object sender, EventArgs e)
        {
            hangisi = 2;
            esyalarbutonu();
        }
        private void btnSatistakiler_Click(object sender, EventArgs e)
        {
            hangisi = 2;
            satisesyalarbutonu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bgln.bagla();
            if (hangisi == 1)
            {
                if (e.ColumnIndex == 1)
                {
                    if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == "K")
                    {
                        SqlCommand degis = new SqlCommand("UPDATE KullaniciGiris SET KullaniciTuru='S' WHERE Email='" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'", bgln.bagla());
                        degis.ExecuteNonQuery();
                        SqlCommand degiss = new SqlCommand("UPDATE Kullanici SET Talep='0' WHERE ID='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", bgln.bagla());
                        degiss.ExecuteNonQuery();
                        kisilerbutonu();
                    }
                    else
                    {
                        SqlCommand degis = new SqlCommand("UPDATE KullaniciGiris SET KullaniciTuru='K' WHERE Email='" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'", bgln.bagla());
                        degis.ExecuteNonQuery();
                        kisilerbutonu();
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    if (dataGridView1.CurrentRow.Cells[8].Value.ToString() != "X")
                    {
                        SqlCommand at = new SqlCommand("UPDATE KullaniciGiris SET KullaniciTuru='X' WHERE Email='" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'", bgln.bagla());
                        at.ExecuteNonQuery();
                        kisilerbutonu();
                    }
                    else
                    {
                        SqlCommand at = new SqlCommand("UPDATE KullaniciGiris SET KullaniciTuru='K' WHERE Email='" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'", bgln.bagla());
                        at.ExecuteNonQuery();
                        kisilerbutonu();
                    }
                }
            }
            else if (hangisi == 2)
            {
                if (e.ColumnIndex == 0)
                {
                    AnaSayfa.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                    EsyaDetay esyaDetay = new EsyaDetay();
                    esyaDetay.Show();
                }
                else if (e.ColumnIndex == 1)
                {
                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value) == 1)
                    {
                        SqlCommand ekle = new SqlCommand("UPDATE Esya SET Aktiflik=0 WHERE ID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) + "'", bgln.bagla());
                        ekle.ExecuteNonQuery();
                        esyalarbutonu();
                    }
                    else
                    {
                        SqlCommand ekle = new SqlCommand("UPDATE Esya SET Aktiflik=1 WHERE ID='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) + "'", bgln.bagla());
                        ekle.ExecuteNonQuery();
                        esyalarbutonu();
                    }
                }
            }
            bgln.bagla().Close();
        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            //DataGridViewColumn dc = new DataGridViewColumn();
            //dc.HeaderText = "İŞLEM BUTONU SEÇİNİZ";
            //dataGridView1.Columns.Add(dc);
        }
        private void kisilerbutonu()
        {
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn yukle = new DataGridViewButtonColumn();
            DataGridViewButtonColumn karaliste = new DataGridViewButtonColumn();
            karaliste.HeaderText = "DEĞİŞTİR";
            yukle.HeaderText = "AT";
            karaliste.Text = "DEĞİŞTİR";
            yukle.Text = "AT";
            karaliste.Name = "degis";
            yukle.Name = "at";
            karaliste.Width = 60;
            yukle.Width = 30;
            karaliste.UseColumnTextForButtonValue = true;
            yukle.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(yukle);
            dataGridView1.Columns.Add(karaliste);
            bgln.bagla();
            SqlCommand kullanicilar = new SqlCommand("SELECT K.ID,K.Ad,K.Soyad,S.Sehir[Şehir],K.DogumTarihi[Doğum Tarihi],KG.Email,KG.KullaniciTuru[Yetki],K.Talep FROM Kullanici K,KullaniciGiris KG,Sehir S WHERE K.Sehir=S.ID AND K.ID=KG.KisiID AND KG.KullaniciTuru != 'A' ORDER BY K.ID", bgln.bagla());
            SqlDataAdapter hepsi = new SqlDataAdapter(kullanicilar);
            DataTable tumkullanici = new DataTable();
            hepsi.Fill(tumkullanici);
            dataGridView1.DataSource = tumkullanici;
            bgln.bagla().Close();
        }
        private void esyalarbutonu()
        {
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn detay = new DataGridViewButtonColumn();
            DataGridViewButtonColumn ekle = new DataGridViewButtonColumn();
            detay.HeaderText = "DETAY";
            ekle.HeaderText = "EKLE";
            detay.Text = "DETAY";
            ekle.Text = "EKLE";
            detay.Name = "detay";
            ekle.Name = "ekle";
            detay.Width = 45;
            ekle.Width = 45;
            detay.UseColumnTextForButtonValue = true;
            ekle.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(detay);
            dataGridView1.Columns.Add(ekle);
            bgln.bagla();
            SqlCommand esyalar = new SqlCommand("SELECT E.ID,E.EsyaAdi[Eşya Adı],ET.TurAdi[Esya Türü],ET.Cins,K.Ad+' '+K.Soyad[Yükleyen Kişi],E.Aktiflik FROM Esya E,EsyaTur ET,Kullanici K WHERE K.ID=E.EsyaYukliyen AND E.EsyaTuru=ET.ID", bgln.bagla());
            SqlDataAdapter hepsi = new SqlDataAdapter(esyalar);
            DataTable tumesya = new DataTable();
            hepsi.Fill(tumesya);
            dataGridView1.DataSource = tumesya;
            bgln.bagla().Close();
        }
        private void satisesyalarbutonu()
        {
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn detay = new DataGridViewButtonColumn();
            DataGridViewButtonColumn ekle = new DataGridViewButtonColumn();
            detay.HeaderText = "DETAY";
            ekle.HeaderText = "EKLE";
            detay.Text = "DETAY";
            ekle.Text = "EKLE";
            detay.Name = "detay";
            ekle.Name = "ekle";
            detay.Width = 45;
            ekle.Width = 45;
            detay.UseColumnTextForButtonValue = true;
            ekle.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(detay);
            dataGridView1.Columns.Add(ekle);
            bgln.bagla();
            SqlCommand esyalar = new SqlCommand("SELECT E.ID,E.EsyaAdi[Eşya Adı],ET.TurAdi[Esya Türü],ET.Cins,K.Ad+' '+K.Soyad[Yükleyen Kişi],E.Aktiflik FROM Esya E,EsyaTur ET,Kullanici K,AATablo AA WHERE K.ID=E.EsyaYukliyen AND AA.EsyaID=E.ID AND E.EsyaTuru=ET.ID", bgln.bagla());
            SqlDataAdapter hepsi = new SqlDataAdapter(esyalar);
            DataTable tumesya = new DataTable();
            hepsi.Fill(tumesya);
            dataGridView1.DataSource = tumesya;
            bgln.bagla().Close();
        }

        private void btnesylr_MouseHover(object sender, EventArgs e)
        {
            btnesylr.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnesylr_MouseLeave(object sender, EventArgs e)
        {
            btnesylr.BackColor = Color.FromArgb(37, 36, 81);
        }

        private void btnkslr_MouseLeave(object sender, EventArgs e)
        {
            btnkslr.BackColor = Color.FromArgb(37, 36, 81);
        }

        private void btnkslr_MouseHover(object sender, EventArgs e)
        {
            btnkslr.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnSatistakiler_MouseHover(object sender, EventArgs e)
        {
            btnSatistakiler.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void btnSatistakiler_MouseLeave(object sender, EventArgs e)
        {
            btnSatistakiler.BackColor = Color.FromArgb(37, 36, 81);
        }
    }
}
