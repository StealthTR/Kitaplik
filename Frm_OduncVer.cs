using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplık
{
    public partial class Frm_OduncVer : Form
    {
        public Frm_OduncVer()
        {
            InitializeComponent();
        }
        internal string id;
        private void Frm_OduncVer_Load(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = DateTime.Today;
            monthCalendar1.SelectionEnd = DateTime.Today;
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionStart >= DateTime.Today)
            {
                int gun = Convert.ToInt32((monthCalendar1.SelectionStart - DateTime.Today).TotalDays);
                textBox1.Text = gun + " Gün sonra iade edilecek.";
            }
            else
            {
                textBox1.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim()=="")
            {
                MessageBox.Show("Ödünç alan boş geçilemez");
            }
            else
            {
                Kitap ktp = new Kitap();
                ktp.Kitap_Getir(id);
                ktp.odunc_alan = textBox2.Text;
                ktp.iade_tarihi = monthCalendar1.SelectionStart;
                ktp.Kitap_Guncelle();
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
 