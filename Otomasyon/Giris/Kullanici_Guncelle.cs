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
    public partial class Kullanici_Guncelle : Form
    {
        //veri aktarmak için 
        public int kulId;
        public Kullanici_Guncelle()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = " select * from KULLANICI where KULLANICIID='" + kulId + "' "; 
            SqlConnection sqlconn = new SqlConnection(Program.bag_str); 
            sqlconn.Open(); 
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text; 
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read(); 

            if (rd.HasRows == true) 
            { 
                textBox1.Text = Convert.ToString(rd[1]).Trim();
                textBox2.Text = Convert.ToString(rd[2]).Trim(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //veri aktarma
            string sql = " update KULLANICI set KAD='" + textBox1.Text + "' , " + " KSIFRE='" + textBox2.Text + "' where KULLANICIID=" + kulId;
            SqlConnection baglan = new SqlConnection(Program.bag_str);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
