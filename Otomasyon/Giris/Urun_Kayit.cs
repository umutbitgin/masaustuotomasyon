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
    public partial class Urun_Kayit : Form
    {
        public Urun_Kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);
                baglantiOlustur.Open();

                string sql = "Insert Into URUN (URUNAD,URUNACIKLAMA,FIYAT,KATEGORIID) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedValue +"')";

                SqlCommand cmd = new SqlCommand(sql, baglantiOlustur);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglantiOlustur.Close();

                MessageBox.Show("İşlem Başarılı");
                this.Close();
            }
            else
            {
                MessageBox.Show("Boşluk Bırakmayınız");
            }
        }

        private void Urun_Kayit_Load(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From KATEGORI", baglantiOlustur);
            sda.Fill(kategori, "KATEGORI");
            comboBox1.ValueMember = "KATEGORIID";
            comboBox1.DisplayMember = "KAD";
            comboBox1.DataSource = kategori.Tables["KATEGORI"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
