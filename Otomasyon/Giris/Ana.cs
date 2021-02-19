using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giris
{
    public partial class Ana : Form
    {

        public Ana()
        {
            InitializeComponent();
        }

        private void Ana_Load(object sender, EventArgs e)
        {

        }

        private void kullanıcıKaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kullanici_Kayit ac = new Kullanici_Kayit();
            ac.ShowDialog();
        }

        private void kullanıcıGüncelleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kullanici_Listele ac = new Kullanici_Listele();
            ac.ShowDialog();
        }

        private void kullanıcıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri_Kayit ac = new Musteri_Kayit();
            ac.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri_Listele ac = new Musteri_Listele();
            ac.ShowDialog();
        }

        private void ürünKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Urun_Kayit ac = new Urun_Kayit();
            ac.ShowDialog();
        }

        private void ürünListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Urun_Listele ac = new Urun_Listele();
            ac.ShowDialog();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satış ac = new Satış();
            ac.ShowDialog();
        }
    }
}
