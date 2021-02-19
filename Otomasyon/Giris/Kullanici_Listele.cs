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
    public partial class Kullanici_Listele : Form
    {
        public Kullanici_Listele()
        {
            InitializeComponent();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void fnk_liste_doldur()
        {
            //Listeleme
            string sql = " Select KULLANICIID as 'KULLANICI ID' , KAD as 'KULLANICI ADI', " + " KSIFRE as 'KULLANICI ŞİFRESİ' " + "From KULLANICI ";
            
            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Kullanici_Listele_Load(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void silToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int kullaniciId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string sql = " delete from KULLANICI where KULLANICIID=" + kullaniciId;
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
            Kullanici_Guncelle ac = new Kullanici_Guncelle();
            ac.kulId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ac.ShowDialog();
        }

        private void Kullanici_Listele_Activated(object sender, EventArgs e)
        {
            fnk_liste_doldur();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = " Select KULLANICIID as 'KULLANICI ID' , KAD as 'KULLANICI ADI', " + " KSIFRE as 'KULLANICI ŞİFRESİ' " + "From KULLANICI Where KAD LIKE '%" + textBox1.Text + "%'";

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
