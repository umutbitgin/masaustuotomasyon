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
    public partial class Urun_Guncelle : Form
    {
        public int urunId;
        public Urun_Guncelle()
        {
            InitializeComponent();
        }

        private void Urun_Guncelle_Load(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From KATEGORI", baglantiOlustur);
            sda.Fill(kategori, "KATEGORI");
            comboBox1.ValueMember = "KATEGORIID";
            comboBox1.DisplayMember = "KAD";
            comboBox1.DataSource = kategori.Tables["KATEGORI"];

            string sql = " select * from URUN where URUNID='" + urunId + "' ";
            SqlConnection sqlconn = new SqlConnection(Program.bag_str);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows == true)
            {
                textBox1.Text = Convert.ToString(rd["URUNAD"]).Trim();
                textBox2.Text = Convert.ToString(rd["URUNACIKLAMA"]).Trim();
                textBox3.Text = Convert.ToString(rd["FIYAT"]).Trim();
                comboBox1.SelectedValue = rd["KATEGORIID"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //veri aktarma
            string sql = " update URUN set URUNAD='" + textBox1.Text + "' , " + " URUNACIKLAMA='" + textBox2.Text + "' , " + " FIYAT='" + textBox3.Text + "' , " + " KATEGORIID='" + comboBox1.SelectedValue + "' where URUNID=" + urunId;
            SqlConnection baglan = new SqlConnection(Program.bag_str);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            this.Close();
        }
    }
}
