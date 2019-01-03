using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kitaplık
{
    public partial class Frm_Kitap : Form
    {
        public Frm_Kitap()
        {
            InitializeComponent();
        }
        OleDbCommand komut;
        OleDbDataReader oku;

        public string id = "";

        private void cmbdoldur()
        {
            cmbBrans.Items.Clear();
            cmbGrup.Items.Clear();
            cmbDil.Items.Clear();
            cmbTur.Items.Clear();
            Kitap.baglanti.Open();
            komut = new OleDbCommand("select Brans From Sabit_Brans", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBrans.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Grup From Sabit_Grup", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbGrup.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Dil From Sabit_Dil", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbDil.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Tur From Sabit_Tur", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbTur.Items.Add(oku[0].ToString());
            }
            Kitap.baglanti.Close();
        }

        private void Frm_Kitap_Load(object sender, EventArgs e)
        {
            cmbdoldur();
            if (id!="")
            {
                Kitap kitap = new Kitap();
                kitap.Kitap_Getir(id);
                tbKitap_Adi.Text = kitap.kitap_adi;
                tbYazar.Text = kitap.yazar;
                cmbGrup.Text = kitap.grup;
                cmbBrans.Text = kitap.brans;
                cmbDil.Text = kitap.dil;
                cmbTur.Text = kitap.tur;
                tbSayfa_Sayisi.Text = kitap.sayfa_Sayisi;
                tbDosya.Text = kitap.dosya;
            }
            Button btn = new Button();
            this.AcceptButton = btn;
            btn.Click += pictureBox1_Click;
            Button btn2 = new Button();
            this.CancelButton = btn2;
            btn2.Click += pictureBox2_Click;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.Fixed3D;
            if ((sender as PictureBox).Tag.ToString()=="iptal")
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.cancel2;
            }
            else
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.Ok2;
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
            if ((sender as PictureBox).Tag.ToString() == "iptal")
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.cancel1;
            }
            else
            {
                (sender as PictureBox).BackgroundImage = Properties.Resources.Ok1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (id=="")
            {
                Kitap ktp = new Kitap();
                ktp.kitap_adi = tbKitap_Adi.Text;
                ktp.yazar = tbYazar.Text;
                ktp.grup = cmbGrup.Text;
                ktp.brans = cmbBrans.Text;
                ktp.dil = cmbDil.Text;
                ktp.tur = cmbTur.Text;
                ktp.sayfa_Sayisi = tbSayfa_Sayisi.Text;
                ktp.dosya = tbDosya.Text;
                ktp.Kitap_Ekle();
                this.Close();
            }
            else
            {
                Kitap ktp = new Kitap();
                ktp.Kitap_Getir(id);
                ktp.kitap_adi = tbKitap_Adi.Text;
                ktp.yazar = tbYazar.Text;
                ktp.grup = cmbGrup.Text;
                ktp.brans = cmbBrans.Text;
                ktp.dil = cmbDil.Text;
                ktp.tur = cmbTur.Text;
                ktp.sayfa_Sayisi = tbSayfa_Sayisi.Text;
                ktp.dosya = tbDosya.Text;
                ktp.Kitap_Guncelle();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Kitap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["Frm_AnaSayfa"].Show();
        }
    }
}
