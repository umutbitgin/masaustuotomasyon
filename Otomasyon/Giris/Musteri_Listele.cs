using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giris
{
    public partial class Musteri_Listele : Form
    {
        public Musteri_Listele()
        {
            InitializeComponent();
        }

        public void fnk_liste_doldur()
        {
            //Listeleme
            string sql = " Select MUSTERID as 'MUSTERI ID' ,  MAD as 'MUSTERI ADI', MSOYAD as 'MUSTERI SOYADI', MTEL as 'MUSTERI TEL NO', MADRES as 'MUSTERI ADRESI', MTC as 'MUSTERI TC NO', ILID as 'MUSTERI SEHIRI',  ILCEID as 'MUSTERI ILCESI'   From MUSTERI ";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int musteriId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = " delete from MUSTERI where MUSTERID=" + musteriId;
            SqlConnection baglan = new SqlConnection(Program.bag_str);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            fnk_liste_doldur();
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yeni form açma ve veriyi çekme
            Musteri_Guncelle ac = new Musteri_Guncelle();
            ac.musteriId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ac.ShowDialog();
        }

        private void Musteri_Listele_Activated(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void Musteri_Listele_Load(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string sql = " Select MUSTERID as 'MUSTERI ID' ,  MAD as 'MUSTERI ADI', MSOYAD as 'MUSTERI SOYADI', MTEL as 'MUSTERI TEL NO', MADRES as 'MUSTERI ADRESI', MTC as 'MUSTERI TC NO', ILID as 'MUSTERI SEHIRI',  ILCEID as 'MUSTERI ILCESI'   From MUSTERI Where MAD LIKE '%" + textBox1.Text + "%'";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
