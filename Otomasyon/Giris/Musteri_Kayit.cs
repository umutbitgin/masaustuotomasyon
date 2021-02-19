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
    public partial class Musteri_Kayit : Form
    {
        public Musteri_Kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text.Trim() != "" && txt_soyad.Text.Trim() != "")
            {
                SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);
                baglantiOlustur.Open();

                string sql = "INSERT INTO MUSTERI (MAD,MSOYAD,MTEL,MADRES,MTC,ILID,ILCEID) VALUES ('" + txt_ad.Text + "','" + txt_soyad.Text + "','" + txt_telno.Text + "','" + txt_adres.Text + "','" + txt_tcno.Text + "','" + cmb_sehir.SelectedValue + "','" + cmb_ilce.SelectedValue + " ')";

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

        private void Musteri_Kayit_Load(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From IL", baglantiOlustur);
            sda.Fill(kategori, "IL");
            cmb_sehir.ValueMember = "ILID";
            cmb_sehir.DisplayMember = "IL";
            cmb_sehir.DataSource = kategori.Tables["IL"];
        }

        private void cmb_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglantiOlustur = new SqlConnection(Program.bag_str);

            DataSet kategori = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From ILCELER Where IL='"+cmb_sehir.Text+"'", baglantiOlustur);
            sda.Fill(kategori, "ILCELER");
            cmb_ilce.ValueMember = "ILCEID";
            cmb_ilce.DisplayMember = "ILCE";
            cmb_ilce.DataSource = kategori.Tables["ILCELER"];
        }

        private void txt_adres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_soyad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
