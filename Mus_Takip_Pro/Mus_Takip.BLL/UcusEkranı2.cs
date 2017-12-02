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

namespace Mus_Takip.BLL
{
    public partial class UcusEkranı2 : Form
    {
        public UcusEkranı2()
        {
            InitializeComponent();
        }
      
        UcusRepository Ur = new UcusRepository();
        MusDBEntities ent = new MusDBEntities(); 

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Ucuslar u = new Ucuslar();
            u.Nereden = txtNereden.Text;
            u.Nereye = txtNereye.Text;
            u.Kalkis_Tar = dtTarih.Value;
            u.Kalkis_Saat = mtxtSaat.Text;
            u.Bilet_Fiyati = Convert.ToInt16(txtFiyat.Text);
            u.Musteri_No = Convert.ToInt16(lblID.Text);
            Ur.insert(u);
            MessageBox.Show("Uçuş kaydedildi.");
            this.Hide();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
