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
    public partial class Musteri_Guncelle : Form
    {
        public int musteriId;
        public Musteri_Guncelle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            //veri aktarma
            string sql = "Update MUSTERI Set MAD='" + txt_ad.Text + "', MSOYAD='" + txt_soyad.Text + "', MTEL='" + txt_telno.Text + "', MADRES='" + txt_adres.Text + "', MTC='" + txt_tcno.Text + "', ILID='" + cmb_sehir.SelectedValue + "', ILCEID='" + cmb_ilce.SelectedValue + "' Where MUSTERID=" + musteriId;

            SqlConnection baglan = new SqlConnection(Program.bag_str);
            baglan.Open();
            SqlCommand cmd = new SqlCommand(sql, baglan);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglan.Close();
            this.Close();
        }

        private void Musteri_Guncelle_Load(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From IL", baglantiOlustur);
            sda.Fill(kategori, "IL");
            cmb_sehir.ValueMember = "ILID";
            cmb_sehir.DisplayMember = "IL";
            cmb_sehir.DataSource = kategori.Tables["IL"];

            string sql = " select * from MUSTERI where MUSTERID='" + musteriId + "' ";
            SqlConnection sqlconn = new SqlConnection(Program.bag_str);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows == true)
            {
                txt_ad.Text = Convert.ToString(rd["MAD"]).Trim();
                txt_soyad.Text = Convert.ToString(rd["MSOYAD"]).Trim();
                txt_telno.Text = Convert.ToString(rd["MTEL"]).Trim();
                txt_adres.Text = Convert.ToString(rd["MADRES"]).Trim();
                txt_tcno.Text = Convert.ToString(rd["MTC"]).Trim();
                cmb_sehir.SelectedValue = rd["ILID"];
                cmb_ilce.SelectedValue = rd["ILCEID"];
            }
        }

        private void cmb_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From ILCELER Where IL='" + cmb_sehir.Text + "'", baglantiOlustur);
            sda.Fill(kategori, "ILCELER");
            cmb_ilce.ValueMember = "ILCEID";
            cmb_ilce.DisplayMember = "ILCE";
            cmb_ilce.DataSource = kategori.Tables["ILCELER"];

           
        }
    }
}
