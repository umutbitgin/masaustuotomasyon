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
    public partial class Kullanici_Kayit : Form
    {
        public Kullanici_Kayit()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);
                baglantiOlustur.Open();

                string sql = "Insert Into KULLANICI (KAD,KSIFRE) Values ('" + textBox1.Text + "','" + textBox2.Text + "')";

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

        private void Kullanici_Kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
