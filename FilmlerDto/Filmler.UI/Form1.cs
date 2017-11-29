using Filmler.BLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmler.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        YonetmenRepository yrepo = new YonetmenRepository();
        FilmRepository frepo = new FilmRepository();
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = yrepo.selectAllList();
            comboBox1.DisplayMember = "YonetmenAdiSoyadi";
            comboBox1.ValueMember = "YonetmenId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = (int)comboBox1.SelectedValue;
            listBox1.DataSource = frepo.selectByfilmId(id);
            listBox1.DisplayMember = "FilmAdi";
            listBox1.ValueMember = "yayinTarihi";
        }
    }
}
