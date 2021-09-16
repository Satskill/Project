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
    public partial class EsyaEkle : Form
    {
        Baglanti bgln = new Baglanti();
        int rsm1, rsm2, rsm3;

        public EsyaEkle()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void EsyaEkle_Load(object sender, EventArgs e)
        {
            bgln.bagla();
            SqlCommand cins = new SqlCommand("SELECT Cins FROM EsyaCins", bgln.bagla());
            SqlDataReader drcins = cins.ExecuteReader();
            while (drcins.Read())
            {
                cmbcns.Items.Add(drcins["Cins"]);
            }
            SqlCommand tur = new SqlCommand("SELECT TurAdi FROM EsyaTur", bgln.bagla());
            SqlDataReader turoku = tur.ExecuteReader();
            while (turoku.Read())
            {
                cmbtr.Items.Add(turoku["TurAdi"]);
            }
            //SqlCommand cek = new SqlCommand("SELECT Resim1,Resim2,Resim3 FROM EsyaResim", bgln.bagla());
            //SqlDataAdapter da = new SqlDataAdapter(cek);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //Byte[] resimler1 = new byte[0];
            //Byte[] resimler2 = new byte[0];
            //Byte[] resimler3 = new byte[0];
            //resimler1 = (Byte[])(ds.Tables[0].Rows[0][0]);
            //resimler2 = (Byte[])(ds.Tables[0].Rows[0][1]);
            //resimler3 = (Byte[])(ds.Tables[0].Rows[0][2]);
            //MemoryStream m1 = new MemoryStream(resimler1);
            //MemoryStream m2 = new MemoryStream(resimler2);
            //MemoryStream m3 = new MemoryStream(resimler3);
            //pictureBox1.Image = Image.FromStream(m1);
            //pictureBox2.Image = Image.FromStream(m2);
            //pictureBox3.Image = Image.FromStream(m3);
            ////pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ////pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            ////pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            if (AnaSayfa.ID != 0)
            {
                SqlCommand esyagetir = new SqlCommand("SELECT E.EsyaAdi,E.EsyaTuru,E.EsyaResim,E.Fiyat,E.UretimYili,ET.Cins,ET.TurAdi FROM Esya E,EsyaTur ET WHERE E.EsyaTuru=ET.ID AND E.ID='" + AnaSayfa.ID + "'", bgln.bagla());
                SqlDataReader getiroku = esyagetir.ExecuteReader();
                if (getiroku.Read())
                {
                    SqlCommand resimcek = new SqlCommand("SELECT Resim1,Resim2,Resim3 FROM EsyaResim WHERE ID='" + getiroku["EsyaResim"] + "'", bgln.bagla());
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
                    txtad.Text = getiroku["EsyaAdi"].ToString();
                    txtfyt.Text = getiroku["Fiyat"].ToString();
                    //Satislarim satislarim = new Satislarim();
                    dateTimePicker1.Text = getiroku["UretimYili"].ToString() + "-01-01";
                    cmbtr.SelectedItem = getiroku["TurAdi"].ToString();
                    cmbcns.SelectedItem = getiroku["Cins"].ToString();
                }
            }
            bgln.bagla().Close();
        }

        private void btnrsm1_Click(object sender, EventArgs e)
        {
            rsm1 = 1;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DialogResult dialogResult = new DialogResult();
            dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnrsm2_Click(object sender, EventArgs e)
        {
            rsm2 = 1;
            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            DialogResult dialogResult = new DialogResult();
            dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnrsm3_Click(object sender, EventArgs e)
        {
            rsm3 = 1;
            //pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            DialogResult dialogResult = new DialogResult();
            dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox3.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void cmbcns_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbtr.Items.Clear();
            bgln.bagla();
            SqlCommand tur = new SqlCommand("SELECT TurAdi FROM EsyaTur WHERE Cins='" + cmbcns.SelectedItem + "'", bgln.bagla());
            SqlDataReader drtur = tur.ExecuteReader();
            while (drtur.Read())
            {
                cmbtr.Items.Add(drtur["TurAdi"]);
            }
            bgln.bagla().Close();
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {
            Image i1 = pictureBox1.Image;
            Image i2 = pictureBox2.Image;
            Image i3 = pictureBox3.Image;
            byte[] arr1;
            byte[] arr2;
            byte[] arr3;
            ImageConverter convert = new ImageConverter();
            arr1 = (byte[])convert.ConvertTo(i1, typeof(byte[]));
            arr2 = (byte[])convert.ConvertTo(i2, typeof(byte[]));
            arr3 = (byte[])convert.ConvertTo(i3, typeof(byte[]));
            byte[] r1deneme = arr1;
            byte[] r2deneme = arr2;
            byte[] r3deneme = arr3;
            bgln.bagla();

            SqlCommand resim = new SqlCommand();

            if (AnaSayfa.ID != 0 && rsm1 == 1 && rsm2 == 1 && rsm3 == 3)
            {
                //Anasayfada bu forma gelişte id 0 yap unutma !!!!!!!!!!!!!!!!!!!!
                SqlCommand resimim = new SqlCommand("SELECT EsyaResim FROM Esya WHERE ID='" + AnaSayfa.ID + "'", bgln.bagla());
                SqlDataReader resimimoku = resimim.ExecuteReader();
                if (resimimoku.Read() && rsm1 == 1)
                {
                    resim = new SqlCommand("UPDATE EsyaResim SET Resim1='" + arr1 + "' WHERE ID='" + Convert.ToInt32(resimimoku["EsyaResim"]) + "'", bgln.bagla());
                }
                if (resimimoku.Read() && rsm2 == 1)
                {
                    resim = new SqlCommand("UPDATE EsyaResim SET Resim2='" + arr2 + "' WHERE ID='" + Convert.ToInt32(resimimoku["EsyaResim"]) + "'", bgln.bagla());
                }
                if (resimimoku.Read() && rsm3 == 1)
                {
                    resim = new SqlCommand("UPDATE EsyaResim SET Resim3='" + arr3 + "' WHERE ID='" + Convert.ToInt32(resimimoku["EsyaResim"]) + "'", bgln.bagla());
                }
                try
                {
                    resim.ExecuteNonQuery();
                }
                catch
                {

                }

            }
            else
            {
                resim = new SqlCommand("INSERT INTO EsyaResim (Resim1,Resim2,Resim3) VALUES (@R1,@R2,@R3)", bgln.bagla());
                resim.Parameters.AddWithValue("@R1", arr1);
                resim.Parameters.AddWithValue("@R2", arr2);
                resim.Parameters.AddWithValue("@R3", arr3);
                resim.ExecuteNonQuery();
            }

            SqlCommand tur = new SqlCommand("SELECT ID FROM EsyaTur WHERE Cins LIKE '%" + cmbcns.SelectedItem + "%' AND TurAdi LIKE '%" + cmbtr.SelectedItem + "%'", bgln.bagla());
            SqlDataReader drtur = tur.ExecuteReader();
            SqlCommand resimcek = new SqlCommand("SELECT TOP 1 ID FROM EsyaResim ORDER BY ID DESC", bgln.bagla());
            SqlDataReader dr = resimcek.ExecuteReader();
            if (dr.Read() && drtur.Read())
            {
                if (AnaSayfa.ID != 0)
                {
                    int girdi = 0;
                    if (txtfyt.Text.Length <= 5)
                    {
                        girdi = Convert.ToInt32(txtfyt.Text);
                    }
                    else
                    {
                        girdi = Convert.ToInt32(txtfyt.Text.Substring(0, txtfyt.Text.Length - 5));
                    }
                    SqlCommand esyadegis = new SqlCommand("UPDATE Esya SET EsyaAdi=@ad,EsyaTuru=@tur,Fiyat=@fiyat,UretimYili=@yil,Aktiflik=@aktif WHERE ID=@id", bgln.bagla());
                    esyadegis.Parameters.AddWithValue("@ad", txtad.Text);
                    esyadegis.Parameters.AddWithValue("@tur", Convert.ToInt32(drtur["ID"]));
                    esyadegis.Parameters.AddWithValue("@fiyat", girdi);
                    esyadegis.Parameters.AddWithValue("@yil", dateTimePicker1.Text);
                    esyadegis.Parameters.AddWithValue("@aktif", 0);
                    esyadegis.Parameters.AddWithValue("@id", AnaSayfa.ID);
                    esyadegis.ExecuteNonQuery();
                    MessageBox.Show("Eşyanız Güncellendi.");
                }
                else
                {
                    int yoktur = 0, index = 0, yokcins = 0;
                    SqlCommand turler = new SqlCommand("SELECT TurAdi,Cins FROM EsyaTur", bgln.bagla());
                    SqlDataReader turoku = turler.ExecuteReader();
                    while (turoku.Read())
                    {
                        if (turoku["TurAdi"].ToString() == cmbtr.Items.IndexOf(index).ToString())
                        {
                            yoktur++;
                            break;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    index = 0;
                    while (turoku.Read())
                    {
                        if (turoku["Cins"].ToString() == cmbcns.Items.IndexOf(index).ToString())
                        {
                            yokcins++;
                            break;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    if (yoktur >= 0 || yokcins >= 0)
                    {
                        SqlCommand turyaz = new SqlCommand();
                        //if (yoktur >= 0 && yokcins == 0)
                        //{
                        //    turyaz = new SqlCommand("INSERT INTO EsyaTur (TurAdi,Cins) VALUES ('" + cmbtr.Text + "','" + cmbcns.Text + "')", bgln.bagla());
                        //}
                        try
                        {
                            turyaz = new SqlCommand("INSERT INTO EsyaTur (TurAdi,Cins) VALUES ('" + cmbtr.Text + "','" + cmbcns.Text + "')", bgln.bagla());
                            SqlCommand cinsyaz = new SqlCommand("INSERT INTO EsyaCins (Cins) VALUES ('" + cmbcns.Text + "')", bgln.bagla());
                            cinsyaz.ExecuteNonQuery();
                        }
                        catch
                        {
                            turyaz = new SqlCommand("INSERT INTO EsyaTur (TurAdi,Cins) VALUES ('" + cmbtr.Text + "','" + cmbcns.Text + "')", bgln.bagla());
                        }
                        turyaz.ExecuteNonQuery();
                        cmbcns.Items.Clear();
                        cmbtr.Items.Clear();
                        SqlCommand cinss = new SqlCommand("SELECT Cins FROM EsyaCins", bgln.bagla());
                        SqlDataReader drcinss = cinss.ExecuteReader();
                        while (drcinss.Read())
                        {
                            cmbcns.Items.Add(drcinss["Cins"]);
                        }
                        SqlCommand turr = new SqlCommand("SELECT TurAdi FROM EsyaTur", bgln.bagla());
                        SqlDataReader drturr = turr.ExecuteReader();
                        while (drturr.Read())
                        {
                            cmbtr.Items.Add(drturr["TurAdi"]);
                        }
                    }
                    SqlCommand turrr = new SqlCommand("SELECT ID FROM EsyaTur WHERE Cins LIKE '%" + cmbcns.Text + "%' AND TurAdi LIKE '%" + cmbtr.Text + "%'", bgln.bagla());
                    SqlDataReader drturrr = turrr.ExecuteReader();

                    if (drturrr.Read())
                    {
                        SqlCommand esyaekle = new SqlCommand("INSERT INTO Esya (EsyaAdi,EsyaTuru,EsyaResim,EsyaYukliyen,Fiyat,UretimYili,Aktiflik) VALUES (@ad,@tur,@resim,@yuk,@fiyat,@yil,@aktif)", bgln.bagla());
                        esyaekle.Parameters.AddWithValue("@ad", txtad.Text);
                        esyaekle.Parameters.AddWithValue("@tur", Convert.ToInt32(drturrr["ID"]));
                        esyaekle.Parameters.AddWithValue("@resim", Convert.ToInt32(dr["ID"]));
                        esyaekle.Parameters.AddWithValue("@yuk", GirisYap.ID);
                        esyaekle.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtfyt.Text));
                        esyaekle.Parameters.AddWithValue("@yil", Convert.ToInt32(dateTimePicker1.Text));
                        esyaekle.Parameters.AddWithValue("@aktif", 0);
                        esyaekle.ExecuteNonQuery();
                        MessageBox.Show("Yeni Eşya Eklendi.");
                    }
                }
            }
            bgln.bagla().Close();

            //catch
            //{

            //    MessageBox.Show("3 Adet Resim Koymak Zorunludur !!!!");
            //}
        }
        private void btnkyt_MouseHover(object sender, EventArgs e)
        {
            btnkyt.BackColor = Color.FromArgb(244, 67, 54);
            //btnkyt.Image = Properties.Resources.icons8_save_32px;
        }

        private void btnkyt_MouseLeave(object sender, EventArgs e)
        {
            btnkyt.BackColor = Color.FromArgb(37, 36, 81);
        }
    }
}
