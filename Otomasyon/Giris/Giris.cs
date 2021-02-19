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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {

            try
            {
                // Sql bağalntısı oluşturma
                SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);
                baglantiOlustur.Open();

                //Tabloya bağlanma
                string sql = "Select * From KULLANICI Where KAD=@KAD And KSIFRE=@KSIFRE";

                SqlParameter prmKAD = new SqlParameter("KAD", txt_kad.Text.Trim());
                SqlParameter prmSIF = new SqlParameter("KSIFRE", txt_sifre.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, baglantiOlustur);

                cmd.Parameters.Add(prmKAD);
                cmd.Parameters.Add(prmSIF);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Giriş yapıldı.");

                    Ana ac = new Ana();
                    ac.Show();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Giriş hatalı.");
                }

            }
            catch
            {
                MessageBox.Show("Beklenmeyen bir hata oluştu.");
            }

        }   

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
