using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Giris
{
    public partial class Urun_Listele : Form
    {
        public Urun_Listele()
        {
            InitializeComponent();
        }

        public void fnk_liste_doldur()
        {
            //Listeleme
            string sql = " Select URUNID as 'URUN ID' ,  KATEGORIID as 'KATEGORİ ID', URUNAD as 'URUN ADI', URUNACIKLAMA as 'URUN ACIKLAMA', FIYAT as 'FIYATI' From URUN ";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Urun_Listele_Load(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = " delete from URUN where URUNID=" + urunId;
            SqlConnection baglan = new SqlConnection(Program.bag_str);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            fnk_liste_doldur();
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void Urun_Listele_Activated(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yeni form açma ve veriyi çekme
            Urun_Guncelle ac = new Urun_Guncelle();
            ac.urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ac.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = " Select URUNID as 'URUN ID' ,  KATEGORIID as 'KATEGORİ ID', URUNAD as 'URUN ADI', URUNACIKLAMA as 'URUN ACIKLAMA', FIYAT as 'FIYATI' From URUN Where URUNAD LIKE '%" + textBox1.Text+ "%'";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
