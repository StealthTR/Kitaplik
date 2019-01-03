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
    public partial class Frm_AnaSayfa : Form
    {
        public Frm_AnaSayfa()
        {
            InitializeComponent();
        }
        OleDbCommand komut;
        OleDbDataReader oku;
        public static string adres = Application.StartupPath;
        List<Kitap> kitaps = new List<Kitap>();
        List<Kitap> aramakitap = new List<Kitap>();
        internal static Color arkaplan=Color.LightGray;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Kitap.baglanti.Open();
                komut = new OleDbCommand("select Renk from Ayar", Kitap.baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    arkaplan = Color.FromArgb(Convert.ToInt32(oku[0].ToString()));
                }
                Kitap.baglanti.Close();
            }
            catch (Exception)
            {
                Kitap.baglanti.Close();
                arkaplan = Color.LightGray;
            }
            tumkitaplar();
            this.BackColor = arkaplan;
            timer2.Start();
        }

        private void tumkitaplar()
        {
            kitaps.Clear();
            lstv_kitaplar.Items.Clear();
            kitaps = Kitap.Tum_Kitaplar();
            Kitap.Listview_Ekle(lstv_kitaplar, kitaps);
            filtredoldur();            
        }

        private void tbArama_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void filtredoldur()
        {
            cmbSorguKitapAdi.Items.Clear();
            cmbSorguYazar.Items.Clear();
            cmbSorguGrup.Items.Clear();
            cmbSorguBrans.Items.Clear();
            cmbSorguDil.Items.Clear();
            cmbSorguSayfaSayisi.Items.Clear();
            cmbSorguTur.Items.Clear();
            cmbSorguOduncAlan.Items.Clear();
            foreach (Kitap ktp in kitaps)
            {
                cmbSorguKitapAdi.Items.Add(ktp.kitap_adi);
                cmbSorguYazar.Items.Add(ktp.yazar);
                cmbSorguGrup.Items.Add(ktp.grup);
                cmbSorguBrans.Items.Add(ktp.brans);
                cmbSorguDil.Items.Add(ktp.dil);
                cmbSorguSayfaSayisi.Items.Add(ktp.sayfa_Sayisi);
                cmbSorguTur.Items.Add(ktp.tur);
                cmbSorguOduncAlan.Items.Add(ktp.odunc_alan);
            }
        }

        private void filtrele()
        {
            if (dtpilk.Value.ToShortDateString()=="1.01.1900" && dtpson.Value.ToShortDateString()=="1.01.3000")
            {
                List<Kitap> filtrekitap = new List<Kitap>();
                foreach (Kitap item in kitaps)
                {
                    if ((item.kitap_adi.IndexOf(cmbSorguKitapAdi.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguKitapAdi.Text == "") && (item.yazar.IndexOf(cmbSorguYazar.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguYazar.Text == "") && (item.grup.IndexOf(cmbSorguGrup.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguGrup.Text == "") && (item.brans.IndexOf(cmbSorguBrans.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguBrans.Text == "") && (item.dil.IndexOf(cmbSorguDil.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguDil.Text == "") && (item.sayfa_Sayisi.IndexOf(cmbSorguSayfaSayisi.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguSayfaSayisi.Text == "") && (item.tur.IndexOf(cmbSorguTur.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguTur.Text == "") && (item.odunc_alan.IndexOf(cmbSorguOduncAlan.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguOduncAlan.Text == "") && (item.iade_tarihi >= dtpilk.Value || item.iade_tarihi.ToShortDateString() == "1.01.0001") && (item.iade_tarihi <= dtpson.Value || item.iade_tarihi.ToShortDateString() == "1.01.0001"))
                    {
                        filtrekitap.Add(item);
                    }
                }
                lstv_kitaplar.Items.Clear();
                Kitap.Listview_Ekle(lstv_kitaplar, filtrekitap);
            }
            else
            {
                List<Kitap> filtrekitap = new List<Kitap>();
                foreach (Kitap item in kitaps)
                {
                    if ((item.kitap_adi.IndexOf(cmbSorguKitapAdi.Text, 0,StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguKitapAdi.Text == "") && (item.yazar.IndexOf(cmbSorguYazar.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguYazar.Text == "") && (item.grup.IndexOf(cmbSorguGrup.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguGrup.Text == "") && (item.brans.IndexOf(cmbSorguBrans.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguBrans.Text == "") && (item.dil.IndexOf(cmbSorguDil.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguDil.Text == "") && (item.sayfa_Sayisi.IndexOf(cmbSorguSayfaSayisi.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguSayfaSayisi.Text == "") && (item.tur.IndexOf(cmbSorguTur.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguTur.Text == "") && (item.odunc_alan.IndexOf(cmbSorguOduncAlan.Text, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 || cmbSorguOduncAlan.Text == "") && (item.iade_tarihi >= dtpilk.Value ) && (item.iade_tarihi <= dtpson.Value ))
                    {
                        filtrekitap.Add(item);
                    }
                }
                lstv_kitaplar.Items.Clear();
                Kitap.Listview_Ekle(lstv_kitaplar, filtrekitap);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            aramakitap.Clear();
            lstv_kitaplar.Items.Clear();
            aramakitap = Kitap.Arama(tbArama.Text);
            Kitap.Listview_Ekle(lstv_kitaplar, aramakitap);
            filtredoldur();
        }

        private void FiltreCalistir(object sender, EventArgs e)
        {
            filtrele();
        }

        private void pbKitap_Ekle_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbKitap_Ekle_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        private void pbCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void pbArka_Plan_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Iade Tarihi Geçenleri Listele
        {
            foreach (Control c in gpb_filtre.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            dtpilk.Value = DateTime.Parse("01.01.1900");
            dtpson.Value = DateTime.Today;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e) //Tümünü Listele
        {
            foreach (Control c in gpb_filtre.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            dtpilk.Value = DateTime.Parse("01.01.1900");
            dtpson.Value = DateTime.Parse("01.01.3000");
            tumkitaplar();
        }

        private void pbKitap_Ekle_Click(object sender, EventArgs e)
        {
            Frm_Kitap ktp = new Frm_Kitap();
            ktp.BackColor = arkaplan;
            this.Hide();
            ktp.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frm_Ayarlar ayar = new Frm_Ayarlar();
            ayar.BackColor = arkaplan;
            ayar.Show();
            this.Hide();
        }

        private void Frm_AnaSayfa_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==true)
            {
                tumkitaplar();
            }
        }

        private void lstv_kitaplar_DoubleClick(object sender, EventArgs e)
        {
            if (lstv_kitaplar.SelectedItems.Count==1)
            {
                Frm_Kitap ktp = new Frm_Kitap();
                ktp.id = lstv_kitaplar.SelectedItems[0].Text;
                ktp.BackColor = arkaplan;
                ktp.Show();
                this.Hide();
            }
        }

        private void lstv_kitaplar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lstv_kitaplar.SelectedItems.Count==1)
            {
                lstv_kitaplar.ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                lstv_kitaplar.ContextMenuStrip = null;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lstv_kitaplar.SelectedItems[0].SubItems[9].Text=="")
            {
                mi_TeslimAl.Enabled = false;
                mi_OduncVer.Enabled = true;
            }
            else
            {
                mi_OduncVer.Enabled = false;
                mi_TeslimAl.Enabled = true;
            }
        }

        private void mi_TeslimAl_Click(object sender, EventArgs e)
        {
            Kitap ktp = new Kitap();
            ktp.Kitap_Getir(lstv_kitaplar.SelectedItems[0].Text);
            ktp.odunc_alan = "";
            ktp.iade_tarihi =DateTime.Parse("01.01.0001");
            ktp.Kitap_Guncelle();
            tumkitaplar();
        }

        private void mi_OduncVer_Click(object sender, EventArgs e)
        {
            Frm_OduncVer odunc = new Frm_OduncVer();
            odunc.BackColor = arkaplan;
            odunc.id = lstv_kitaplar.SelectedItems[0].Text;
            DialogResult result = odunc.ShowDialog();
            if (result==DialogResult.OK)
            {
                tumkitaplar();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Kitap> iade = new List<Kitap>();
            string iadekitap="";
            if (Kitap.baglanti.State==ConnectionState.Closed)
            {
                foreach (Kitap ktp in Kitap.Tum_Kitaplar())
                {
                    if (ktp.iade_tarihi.ToShortDateString()!= "1.01.0001" && ktp.iade_tarihi.ToShortDateString() != "01.01.0001")
                    {
                        if (ktp.iade_tarihi <= DateTime.Today)
                        {
                            iade.Add(ktp);
                            iadekitap += (ktp.kitap_adi + " \n");
                        }
                    }
                }
            }
            
            notifyIcon1.BalloonTipTitle = "Kitaplık Kitap Hatırlatma";
            notifyIcon1.BalloonTipText = iadekitap;
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Frm_AnaSayfa_DoubleClick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void mi_Sil_Click(object sender, EventArgs e)
        {
            if (lstv_kitaplar.SelectedItems.Count == 1)
            {
                Kitap ktp = new Kitap();
                ktp.Kitap_Getir(lstv_kitaplar.SelectedItems[0].Text);
                ktp.Kitap_Sil();
                tumkitaplar();
            }
        }
    }
}
