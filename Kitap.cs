using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Kitaplık
{ 
    internal class Kitap
    {
        internal static OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Frm_AnaSayfa.adres + @"\Kitap.accdb;Jet OLEDB:Database Password = 123456");

        OleDbCommand komut;
        OleDbDataReader dr;

        private string Id;
        private string Kitap_Adi="";
        private string Yazar = "";
        private string Grup = "";
        private string Brans = "";
        private string Dil = "";
        private string Sayfa_Sayisi = "";
        private string Tur = "";
        private string Odunc_Alan="";
        private DateTime Iade_Tarihi;
        private string Dosya;

        public string id
        {
            get
            {
                return Id;
            }
            set
            {

            }
        }
        public string kitap_adi
        {
            get
            {
                return Kitap_Adi;
            }
            set
            {
                if (value.Length<=255)
                {
                    Kitap_Adi = value;
                }
                else
                {
                    Kitap_Adi = value.Remove(255);
                }
            }
        }
        public string yazar
        {
            get
            {
                return Yazar;
            }
            set
            {
                if (value.Length <= 255)
                {
                    Yazar = value;
                }
                else
                {
                    Yazar = value.Remove(255);
                }
            }
        }
        public string grup
        {
            get
            {
                return Grup;
            }
            set
            {
                if (value.Length<=255)
                {
                    Grup = value;
                }
                else
                {
                    Grup = value.Remove(255);
                }
            }
        }
        public string brans
        {
            get
            {
                return Brans;
            }
            set
            {
                if (value.Length<=255)
                {
                    Brans = value;
                }
                else
                {
                    Brans = value.Remove(255);
                }
            }
        }
        public string dil
        {
            get
            {
                return Dil;
            }
            set
            {
                if (value.Length <= 255)
                {
                    Dil = value;
                }
                else
                {
                    Dil = value.Remove(255);
                }
            }
        }
        public string sayfa_Sayisi
        {
            get
            {
                return Sayfa_Sayisi;
            }
            set
            {
                bool sayimi = true;
                foreach (char c in value.ToString())
                {                 
                    if (!Char.IsNumber(c))
                    {
                        sayimi = false;
                    }
                }
                if (sayimi)
                {
                    Sayfa_Sayisi = value;
                }
                else
                {
                    Sayfa_Sayisi = "0";
                }
            }
        }
        public string tur
        {
            get
            {
                return Tur;
            }
            set
            {
                if (value.Length<=255)
                {
                    Tur = value;
                }
                else
                {
                    Tur = value.Remove(255);
                }
            }
        }
        public string odunc_alan
        {
            get
            {
                return Odunc_Alan;
            }
            set
            {
                if (value.Length<=255)
                {
                    Odunc_Alan = value;
                }
                else
                {
                    Odunc_Alan = value.Remove(255);
                }
            }
        }
        public DateTime iade_tarihi
        {
            get
            {
                return Iade_Tarihi;
            }
            set
            {                
                Iade_Tarihi = value;                   
            }
        }
        public string dosya
        {
            get
            {
                return Dosya;
            }
            set
            {
                if (value.Length<=255)
                {
                    Dosya = value;
                }
                else
                {
                    Dosya = null;
                }
            }
        }

        public void Kitap_Ekle()
        {
            try
            {
                baglanti.Open();
                komut = new OleDbCommand("insert into Kitaplar (Kitap_Adi,Yazar,Grup,Brans,Dil,Sayfa_Sayisi,Tur,Odunc_Alan,Iade_Tarihi,Dosya) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)", baglanti);
                komut.Parameters.AddWithValue("1", Kitap_Adi);
                komut.Parameters.AddWithValue("2", Yazar);
                komut.Parameters.AddWithValue("3", Grup);
                komut.Parameters.AddWithValue("4", Brans);
                komut.Parameters.AddWithValue("5", Dil);
                komut.Parameters.AddWithValue("6", Sayfa_Sayisi);
                komut.Parameters.AddWithValue("7", Tur);
                komut.Parameters.AddWithValue("8", Odunc_Alan);
                komut.Parameters.AddWithValue("9", Iade_Tarihi);
                komut.Parameters.AddWithValue("10", Dosya);
                komut.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show("Yeni Kitap Eklenirken hatayla karşılaşıldı \nhata mesajı: " + x.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void Kitap_Guncelle()
        {
            try
            {
                baglanti.Open();
                komut = new OleDbCommand("update Kitaplar  set Kitap_Adi=@1,Yazar=@2,Grup=@3,Brans=@4,Dil=@5,Sayfa_Sayisi=@6,Tur=@7,Odunc_Alan=@8,Iade_Tarihi=@9,Dosya=@10 where Id=@11", baglanti);
                komut.Parameters.AddWithValue("1", Kitap_Adi);
                komut.Parameters.AddWithValue("2", Yazar);
                komut.Parameters.AddWithValue("3", Grup);
                komut.Parameters.AddWithValue("4", Brans);
                komut.Parameters.AddWithValue("5", Dil);
                komut.Parameters.AddWithValue("6", Sayfa_Sayisi);
                komut.Parameters.AddWithValue("7", Tur);
                komut.Parameters.AddWithValue("8", Odunc_Alan);
                komut.Parameters.AddWithValue("9", Iade_Tarihi);
                komut.Parameters.AddWithValue("10", Dosya);
                komut.Parameters.AddWithValue("11", Id);
                komut.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show("Kitap Bilgileri Güncellerken hatayla karşılaşıldı \nhata mesajı: " + x.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void Kitap_Sil()
        {
            try
            {
                baglanti.Open();
                komut = new OleDbCommand("delete from Kitaplar where Id=@1", baglanti);
                komut.Parameters.AddWithValue("1", Id);
                komut.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show("Kayıt silinirken hatayla karşılaşıldı \nhata mesajı: " + x.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void Kitap_Getir(string idno)
        {
            try
            {
                baglanti.Open();
                komut = new OleDbCommand("select * from Kitaplar where Id=@1", baglanti);
                komut.Parameters.AddWithValue("1", idno);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Id = dr["Id"].ToString();
                    Kitap_Adi = dr["Kitap_Adi"].ToString();
                    Yazar = dr["Yazar"].ToString();
                    Grup = dr["Grup"].ToString();
                    Brans = dr["Brans"].ToString();
                    Dil = dr["Dil"].ToString();
                    Sayfa_Sayisi = dr["Sayfa_Sayisi"].ToString();
                    Tur = dr["Tur"].ToString();
                    Odunc_Alan = dr["Odunc_Alan"].ToString();
                    //Iade_Tarihi = DateTime.Parse(dr["Odunc_Alan"].ToString());
                    Dosya = dr["Dosya"].ToString();
                }
                
            }
            catch (Exception x)
            {
                MessageBox.Show("Kitap Çağırılırken hatayla karşılaşıldı \nhata mesajı: " + x.Message); ;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public static List<Kitap> Tum_Kitaplar()
        {
            List<Kitap> kitaplar = new List<Kitap>();
            OleDbDataAdapter cmd;
            DataTable dt=new DataTable();
            try
            {
                cmd = new OleDbDataAdapter("select * from Kitaplar", baglanti);
                cmd.Fill(dt);
            }
            catch (Exception x)
            {
                MessageBox.Show("Tüm Kitaplar çağırılırken hata oluştu \nhata mesajı: " + x.Message);
            }

            foreach (DataRow row in dt.Rows)
            {
                Kitap ktp = new Kitap();
                ktp.Id = row["Id"].ToString();
                ktp.Kitap_Adi = row["Kitap_Adi"].ToString();
                ktp.Yazar = row["Yazar"].ToString();
                ktp.Grup = row["Grup"].ToString();
                ktp.Brans = row["Brans"].ToString();
                ktp.Dil = row["Dil"].ToString();
                ktp.Sayfa_Sayisi = row["Sayfa_Sayisi"].ToString();
                ktp.Tur = row["Tur"].ToString();
                ktp.Odunc_Alan = row["Odunc_Alan"].ToString();
                if (row["Iade_Tarihi"].ToString() != "")
                {
                    ktp.Iade_Tarihi = DateTime.Parse(row["Iade_Tarihi"].ToString());
                }
                ktp.Dosya = row["Dosya"].ToString();
                kitaplar.Add(ktp);
            }
            return kitaplar;
        }
        public static List<Kitap> Sorgu(string Pno, string Pkitap_adi, string Pyazar, string Pgrup, string Pbrans, string Pdil, string Psayfa_sayisi, string Ptur, string Podunc_alan, DateTime Piade_tarih1, DateTime Piade_tarih2, string Pdosya)
        {
            List<Kitap> kitaplar = new List<Kitap>();
            OleDbCommand cmd;
            OleDbDataReader dr;
            try
            {
                baglanti.Open();
                cmd = new OleDbCommand("select * from Kitaplar where Id like '%'& @1 &'%' and Kitap_Adi like '%'& @2 &'%' and Yazar like  '%'& @3 &'%' and Grup like  '%'& @4 &'%' and Brans like  '%'& @5 &'%' and Dil like  '%'& @6 &'%' and Sayfa_Sayisi like  '%'& @7 &'%' and Tur like  '%'& @8 &'%' and Odunc_Alan like  '%'& @9 &'%' and (Iade_Tarihi between @10 and @11) and Dosya like  '%'&@12&'%' ", baglanti);
                cmd.Parameters.AddWithValue("1",Pno);
                cmd.Parameters.AddWithValue("2",Pkitap_adi);
                cmd.Parameters.AddWithValue("3",Pyazar);
                cmd.Parameters.AddWithValue("4",Pgrup);
                cmd.Parameters.AddWithValue("5",Pbrans);
                cmd.Parameters.AddWithValue("6",Pdil);
                cmd.Parameters.AddWithValue("7",Psayfa_sayisi);
                cmd.Parameters.AddWithValue("8",Ptur);
                cmd.Parameters.AddWithValue("9",Podunc_alan);
                cmd.Parameters.AddWithValue("10", Piade_tarih1.AddDays(-1));
                cmd.Parameters.AddWithValue("11", Piade_tarih2.AddDays(1));
                cmd.Parameters.AddWithValue("12",Pdosya);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Kitap ktp = new Kitap();
                    ktp.Id = dr["Id"].ToString();
                    ktp.Kitap_Adi = dr["Yazar"].ToString();
                    ktp.Yazar = dr["Yazar"].ToString();
                    ktp.Grup = dr["Grup"].ToString();
                    ktp.Brans = dr["Brans"].ToString();
                    ktp.Dil = dr["Dil"].ToString();
                    ktp.Sayfa_Sayisi = dr["Sayfa_Sayisi"].ToString();
                    ktp.Tur = dr["Tur"].ToString();
                    ktp.Odunc_Alan = dr["Odunc_Alan"].ToString();
                    ktp.Iade_Tarihi = DateTime.Parse(dr["Iade_Tarihi"].ToString());
                    ktp.Dosya = dr["Dosya"].ToString();
                    kitaplar.Add(ktp);
                }
                baglanti.Close();
            }
            catch (Exception x)
            {
                baglanti.Close();
                MessageBox.Show("Sorgu çalıştırılırken hata oluştu \nhata mesajı: " + x.Message);
            }
            return kitaplar;
        }
        public static List<Kitap> Arama(string Parama)
        {
            List<Kitap> kitaplar = new List<Kitap>();
            OleDbCommand cmd;
            OleDbDataReader dr;
            try
            {
                baglanti.Open();
                cmd = new OleDbCommand("select * from Kitaplar where Kitap_Adi like '%'& @1&'%' or Yazar like '%'& @1&'%' or Grup like '%'& @1&'%' or Brans like '%'& @1&'%' or Dil like '%'& @1&'%' or Sayfa_Sayisi like '%'& @1&'%' or Tur like '%'& @1&'%' or Odunc_Alan like '%'& @1&'%' or Iade_Tarihi like '%'&@1&'%' or Dosya like '%'& @1&'%'", baglanti);
                cmd.Parameters.AddWithValue("1", Parama);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Kitap ktp = new Kitap();
                    ktp.Id = dr["Id"].ToString();
                    ktp.Kitap_Adi = dr["Kitap_Adi"].ToString();
                    ktp.Yazar = dr["Yazar"].ToString();
                    ktp.Grup = dr["Grup"].ToString();
                    ktp.Brans = dr["Brans"].ToString();
                    ktp.Dil = dr["Dil"].ToString();
                    ktp.Sayfa_Sayisi = dr["Sayfa_Sayisi"].ToString();
                    ktp.Tur = dr["Tur"].ToString();
                    ktp.Odunc_Alan = dr["Odunc_Alan"].ToString();
                    if (dr["Iade_Tarihi"].ToString() != "")
                    {
                        ktp.Iade_Tarihi = DateTime.Parse(dr["Iade_Tarihi"].ToString());
                    }
                    ktp.Dosya = dr["Dosya"].ToString();
                    kitaplar.Add(ktp);
                }
                baglanti.Close();
            }
            catch (Exception x)
            {
                baglanti.Close();
                MessageBox.Show("Arama Yapılırken hata oluştu \nhata mesajı: " + x.Message);
            }
            return kitaplar;
        }
        public static void Listview_Ekle(ListView lst, List<Kitap> kitaplar)
        {
            foreach (Kitap k in kitaplar)
            {
                if (k.Iade_Tarihi.ToShortDateString() == "1.01.0001" || k.Iade_Tarihi.ToShortDateString() == "01.01.0001")
                {
                    string[] subitems = { k.Kitap_Adi, k.Yazar, k.Grup, k.Brans, k.Dil, k.Sayfa_Sayisi, k.Tur, k.Odunc_Alan, "" };
                    ListViewItem i = new ListViewItem();
                    i.Text = k.Id;
                    i.SubItems.AddRange(subitems);
                    lst.Items.Add(i);
                }
                else
                {
                    string[] subitems = { k.Kitap_Adi, k.Yazar, k.Grup, k.Brans, k.Dil, k.Sayfa_Sayisi, k.Tur, k.Odunc_Alan, k.Iade_Tarihi.ToShortDateString() };
                    ListViewItem i = new ListViewItem();
                    i.Text = k.Id;
                    i.SubItems.AddRange(subitems);
                    lst.Items.Add(i);
                    
                }
            }           
        }
    }
}
