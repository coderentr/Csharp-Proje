using Mus_Takip.BLL;
using Mus_Takip.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mus_Takip.IO
{
    public partial class UcusGoster : Form
    {
        public UcusGoster()
        {
            InitializeComponent();
        }
        UcusRepository ur = new UcusRepository();
        Ucuslar güncelle;
        MusDBEntities ent = new MusDBEntities();
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Dt_Ucuslar.SelectedRows[0].Cells[0].Value);
            güncelle = ur.SelectByID(id);
            txtNereden.Text = güncelle.Nereden;
            txtNereye.Text = güncelle.Nereye;
            dtTarih.Value =Convert.ToDateTime( güncelle.Kalkis_Tar);
            mtxtSaat.Text = güncelle.Kalkis_Saat ;
            txtFiyat.Text = güncelle.Bilet_Fiyati.ToString();
        }
        public void goster()
        {
            int id = Convert.ToInt16(Dt_Ucuslar.SelectedRows[0].Cells[0].Value);
            var a = (from i in ent.Ucuslar
                     where i.Musteri_No == id
                     select i).ToList();
            Dt_Ucuslar.DataSource = a;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            güncelle.Nereden = txtNereden.Text;
            güncelle.Nereye = txtNereye.Text;
            güncelle.Kalkis_Tar = dtTarih.Value;
            güncelle.Kalkis_Saat = mtxtSaat.Text;
            güncelle.Bilet_Fiyati =Convert.ToInt16(txtFiyat.Text);
            ur.Update(güncelle);
            goster();
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
