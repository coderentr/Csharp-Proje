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
    public partial class UcusEkranı : Form
    {
        MusDBEntities ent = new MusDBEntities();
        UcusRepository Ur = new UcusRepository();
        public UcusEkranı()
        {
            InitializeComponent();
        }
      
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var id = (from i in ent.Musteriler
                      orderby i.Musteri_No descending
                      select i.Musteri_No).FirstOrDefault();

            Ucuslar u = new Ucuslar();
            u.Nereden = txtNereden.Text;
            u.Nereye = txtNereye.Text;
            u.Kalkis_Tar = dtTarih.Value;
            u.Kalkis_Saat = mtxtSaat.Text;
            u.Bilet_Fiyati = Convert.ToInt16(txtFiyat.Text);
            u.Musteri_No = Convert.ToInt16(id);
            Ur.insert(u);
            MessageBox.Show("Uçuş Kaydedildi");
            this.Hide();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
