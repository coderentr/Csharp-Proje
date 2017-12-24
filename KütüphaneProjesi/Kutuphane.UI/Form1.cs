using Kütüphane.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kutuphane.BLL;

namespace Kutuphane.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BLL.BaseRepository<Ogrenci> or = new BaseRepository<Ogrenci>(); 
        public void Doldur()
        {
            dgVeriler.DataSource = or.SelectAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            Doldur();
        }
        public bool C_Belirle()
        {
            if (radioButton1.Checked)
            {
                return true;
            }
            else if (radioButton2.Checked)
            {
                return false;
            }
            return true;
        }
        public void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Clear();
                }
            }
            radioButton1.Checked = true;

        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

            Ogrenci o = new Ogrenci();
            o.AdSoy = txtAdSoy.Text;
            o.Cinsiyet = C_Belirle();
            o.D_Tarihi = dateTimePicker1.Value;
            o.Puan = Convert.ToInt16(txtPuan.Text);
            o.Sinif =Convert.ToInt16( txtSinif.Text);
            or.Insert(o);
            Doldur();
            Temizle();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id =(int) dgVeriler.SelectedRows[0].Cells[0].Value;
            or.Delete(id);
            Doldur();

        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgVeriler.SelectedRows[0].Cells[0].Value;
        }
    }
}
