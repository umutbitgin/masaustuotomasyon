using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Giris
{
    public partial class Satış : Form
    {
        public Satış()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);
            baglantiOlustur.Open();
            
            string sql = "INSERT INTO SATIS (URUNID,SADET,STARIH,STUTAR,SMIKTAR,MUSTERIID) VALUES ('" + Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value) + "','" + textBox1.Text + "','" + DateTime.Now + "','" + (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(dataGridView2.CurrentRow.Cells["FIYATI"].Value)) + "','" + textBox2.Text + "','" + dataGridView1.CurrentRow.Cells[0].Value + "')";

            SqlCommand cmd = new SqlCommand(sql, baglantiOlustur);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglantiOlustur.Close();

            string sql3 = " Select SATISID as 'SATIS ID' ,  URUNID as 'URUN ID', SADET as 'SATIS ADETI', STARIH as 'SATIS TARIHI', STUTAR as 'SATIS TUTARI', SMIKTAR as 'SATIS NOTU', MUSTERIID as 'MUSTERI ID' From SATIS ";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, con);
            DataSet ds3 = new DataSet();
            con.Open();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Satış_Load(object sender, EventArgs e)
        {
            string sql = " Select MUSTERID as 'MUSTERI ID' ,  MAD as 'MUSTERI ADI', MSOYAD as 'MUSTERI SOYADI', MTEL as 'MUSTERI TEL NO', MADRES as 'MUSTERI ADRESI', MTC as 'MUSTERI TC NO', ILID as 'MUSTERI SEHIRI',  ILCEID as 'MUSTERI ILCESI'   From MUSTERI ";

            SqlConnection con = new SqlConnection(Program.bag_str);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            string sql2 = " Select URUNID as 'URUN ID' ,  KATEGORIID as 'KATEGORİ ID', URUNAD as 'URUN ADI', URUNACIKLAMA as 'URUN ACIKLAMA', FIYAT as 'FIYATI' From URUN ";

            SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
            DataSet ds2 = new DataSet();
            con.Open();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con.Close();


            string sql3 = " Select SATISID as 'SATIS ID' ,  URUNID as 'URUN ID', SADET as 'SATIS ADETI', STARIH as 'SATIS TARIHI', STUTAR as 'SATIS TUTARI', SMIKTAR as 'SATIS MIKTARI', MUSTERIID as 'MUSTERI ID' From SATIS ";

            SqlDataAdapter da3 = new SqlDataAdapter(sql3, con);
            DataSet ds3 = new DataSet();
            con.Open();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
            con.Close();


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
