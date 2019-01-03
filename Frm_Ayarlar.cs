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
using Microsoft.VisualBasic;

namespace Kitaplık
{
    public partial class Frm_Ayarlar : Form
    {
        public Frm_Ayarlar()
        {
            InitializeComponent();
        }
        OleDbCommand komut;
        OleDbDataReader oku;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result== DialogResult.OK)
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("update Ayar set Renk=@1", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", colorDialog1.Color.ToArgb());
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                Frm_AnaSayfa.arkaplan = colorDialog1.Color;
                foreach (Form frm in Application.OpenForms)
                {
                    frm.BackColor = colorDialog1.Color;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listboxdoldur()
        {
            lstb_Brans.Items.Clear();
            lstb_Grup.Items.Clear();
            lstb_Dil.Items.Clear();
            lstb_Tur.Items.Clear();
            Kitap.baglanti.Open();
            komut = new OleDbCommand("select Brans From Sabit_Brans", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lstb_Brans.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Grup From Sabit_Grup", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lstb_Grup.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Dil From Sabit_Dil", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lstb_Dil.Items.Add(oku[0].ToString());
            }
            komut = new OleDbCommand("select Tur From Sabit_Tur", Kitap.baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lstb_Tur.Items.Add(oku[0].ToString());
            }
            Kitap.baglanti.Close();
        }

        private void Frm_Ayarlar_Load(object sender, EventArgs e)
        {
            listboxdoldur();
        }

        private void btn_Grup_Ekle_Click(object sender, EventArgs e)
        {
            bool tekrar = false;
            string yenigrup = Interaction.InputBox("Tanımlamak istediğiniz Grubu giriniz.", "Yeni Grup", "", 300, 300);
            foreach (object item in lstb_Grup.Items)
            {
                if (item.ToString()==yenigrup)
                {
                    tekrar = true;
                    break;
                }
            }
            if (!tekrar && yenigrup!="")
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("insert into Sabit_Grup (Grup) values (@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", yenigrup);
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
            else
            {
                MessageBox.Show("Oluşturmaya çalıştığınız grup zaten mevcut");
            }
        }

        private void btn_Brans_Ekle_Click(object sender, EventArgs e)
        {
            bool tekrar = false;
            string yenibrans = Interaction.InputBox("Tanımlamak istediğiniz Branşı giriniz.", "Yeni Branş", "", 300, 300);
            foreach (object item in lstb_Brans.Items)
            {
                if (item.ToString() == yenibrans)
                {
                    tekrar = true;
                    break;
                }
            }
            if (!tekrar && yenibrans != "")
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("insert into Sabit_Brans (Brans) values (@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", yenibrans);
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
            else
            {
                MessageBox.Show("Oluşturmaya çalıştığınız Branş zaten mevcut");
            }
        }

        private void btn_Dil_Ekle_Click(object sender, EventArgs e)
        {
            bool tekrar = false;
            string yenidil = Interaction.InputBox("Tanımlamak istediğiniz Dili giriniz.", "Yeni Branş", "", 300, 300);
            foreach (object item in lstb_Dil.Items)
            {
                if (item.ToString() == yenidil)
                {
                    tekrar = true;
                    break;
                }
            }
            if (!tekrar && yenidil != "")
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("insert into Sabit_Dil (Dil) values (@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", yenidil);
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
            else
            {
                MessageBox.Show("Oluşturmaya çalıştığınız Dil zaten mevcut");
            }
        }

        private void btn_Tur_Ekle_Click(object sender, EventArgs e)
        {
            bool tekrar = false;
            string yenitur = Interaction.InputBox("Tanımlamak istediğiniz Türü giriniz.", "Yeni Tür", "", 300, 300);
            foreach (object item in lstb_Dil.Items)
            {
                if (item.ToString() == yenitur)
                {
                    tekrar = true;
                    break;
                }
            }
            if (!tekrar && yenitur != "")
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("insert into Sabit_Tur (Tur) values (@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", yenitur);
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
            else
            {
                MessageBox.Show("Oluşturmaya çalıştığınız Dil zaten mevcut");
            }
        }

        private void btn_Grup_Sil_Click(object sender, EventArgs e)
        {
            if (lstb_Grup.SelectedItems.Count == 1)
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("delete from Sabit_Grup where Grup=@1", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", lstb_Grup.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
        }

        private void btn_Brans_Sil_Click(object sender, EventArgs e)
        {
            if (lstb_Brans.SelectedItems.Count == 1)
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("delete from Sabit_Brans where Brans=@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", lstb_Brans.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
        }

        private void btn_Dil_Sil_Click(object sender, EventArgs e)
        {
            if (lstb_Dil.SelectedItems.Count == 1)
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("delete from Sabit_Dil where Dil=@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", lstb_Dil.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
            }
        }

        private void btn_Tur_Sil_Click(object sender, EventArgs e)
        {
            if (lstb_Tur.SelectedItems.Count == 1)
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("delete from Sabit_Tur where Dil=@1)", Kitap.baglanti);
                komut.Parameters.AddWithValue("1", lstb_Tur.SelectedItem.ToString());
                komut.ExecuteNonQuery();
                Kitap.baglanti.Close();
                listboxdoldur();
            }
        }

        private void Frm_Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["Frm_AnaSayfa"].Show();
        }
    }
}
