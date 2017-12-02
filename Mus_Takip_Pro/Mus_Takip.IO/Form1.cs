using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mus_Takip.DAL;
using Mus_Takip.BLL;

namespace Mus_Takip.IO
{
    public partial class Form1 : Form
    {
        MusDBEntities ent = new MusDBEntities();
        MusRepository Mr = new MusRepository();
        Musteriler güncelle;
        public Form1()
        {
            InitializeComponent();
        }
        private void Goster()
        {
            dtMusteriler.DataSource = Mr.SelectAll();
        }
        public void temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Clear();
                }
            }
            mtxtTel.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Goster();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler { Ad_Soy = txtAd.Text, TC = txtTC.Text, Puan = Convert.ToInt16(txtPuan.Text), D_Tarihi = Convert.ToDateTime(dtDogTar.Text), Tel_No = mtxtTel.Text, E_Mail = txtMail.Text };
            Mr.insert(m);
            Goster();
            temizle();
            DialogResult dialogResult = MessageBox.Show("Uçuş Ekleme", "Müşteriye uçuş eklemek istiyormusunuz? ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UcusEkranı ue = new UcusEkranı();
                ue.Show();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = true;
            btnGuncelle.Visible = false;
            güncelle.Ad_Soy = txtAd.Text;
            güncelle.Puan = Convert.ToInt16(txtPuan.Text);
            güncelle.TC = txtTC.Text;
            güncelle.E_Mail = txtMail.Text;
            güncelle.D_Tarihi = Convert.ToDateTime(dtDogTar.Text);
            güncelle.Tel_No = mtxtTel.Text;
            Mr.Update(güncelle);
            Goster();
            temizle();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dtMusteriler.DataSource = Mr.arama(txtAra.Text);
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGuncelle.Visible = true;
            btnEkle.Visible = false;
            int id = Convert.ToInt16(dtMusteriler.SelectedRows[0].Cells[0].Value);
            güncelle = Mr.SelectByID(id);
            txtAd.Text = güncelle.Ad_Soy;
            txtTC.Text = güncelle.TC;
            txtMail.Text = güncelle.E_Mail;
            txtPuan.Text = Convert.ToInt16(güncelle.Puan).ToString();
            mtxtTel.Text = güncelle.Tel_No;
            dtDogTar.Value = Convert.ToDateTime(güncelle.D_Tarihi);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dtMusteriler.SelectedRows[0].Cells[0].Value);
            Mr.delete(id);
            Goster();
        }

        private void uçuşEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UcusEkranı2 ue = new UcusEkranı2();
            int id = Convert.ToInt16(dtMusteriler.SelectedRows[0].Cells[0].Value);
            ue.lblID.Text = id.ToString();
            //var a = (from i in ent.Ucuslar
            //         where i.Musteri_No == id
            //         select i).ToList();
            //ue.dtUcuslar.DataSource = a;
            ue.Show();
        }

        private void uçuşlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UcusGoster ug = new UcusGoster();
            int id = Convert.ToInt16(dtMusteriler.SelectedRows[0].Cells[0].Value);
            var a = (from i in ent.Ucuslar
                     where i.Musteri_No == id
                     select i).ToList();
            ug.Dt_Ucuslar.DataSource = a;
            ug.Show();
        }
    }
}
