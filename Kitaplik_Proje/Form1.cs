using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace Kitaplik_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        sqlbaglantisi1 bgl = new sqlbaglantisi1();  


        void listele()
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kitaplik", bgl.baglanti());   
            da.Fill(dt);    
            dataGridView1.DataSource = dt;  


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();

        }

         string durum = "";

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Kitaplik (KitapAD,Yazar,Tur,Sayfa,Durum) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            
            komut.Parameters.AddWithValue("@p1",TxtKitapAD.Text);
            komut.Parameters.AddWithValue("@p2", TxtYazar.Text);
            komut.Parameters.AddWithValue("@p3", CmbTur.Text);
            komut.Parameters.AddWithValue("@p4", TxtSayfa.Text);
            komut.Parameters.AddWithValue("@p5", durum);
            komut.ExecuteNonQuery();  
            bgl.baglanti().Close();
            MessageBox.Show("Kitap Sistemi Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();  

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            durum = "0";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            durum = "1";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtKitapID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtKitapAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtYazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbTur.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();    
            TxtSayfa.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "True")
            {
                radioButton2.Checked = true;    

            }
            else
            {
                radioButton1.Checked = true;   
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("delete from Tbl_Kitaplik where KitapID=@p1",bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", TxtKitapID.Text);
            cmd1.ExecuteNonQuery(); 
            bgl.baglanti().Close();
            MessageBox.Show("Veri Silindi");



        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Tbl_Kitaplik set KitapAD=@p1,Yazar=@p2,Tur=@p3,Sayfa=@p4,Durum=@p5 where KitapID = @p6",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p1",TxtKitapAD.Text);
            cmd2.Parameters.AddWithValue("@p2", TxtYazar.Text);
            cmd2.Parameters.AddWithValue("@p3", CmbTur.Text);
            cmd2.Parameters.AddWithValue("@p4", TxtSayfa.Text);
            if (radioButton1.Checked == true)
            {
                cmd2.Parameters.AddWithValue("@p5", "False");
            }
            if (radioButton2.Checked == true)
            {
                cmd2.Parameters.AddWithValue("@p5","True");
            }
            cmd2.Parameters.AddWithValue("@p6", TxtKitapID.Text);
            cmd2.ExecuteNonQuery(); 
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("select * from  Tbl_Kitaplik where KitapAD=@p1",bgl.baglanti());
            cmd3.Parameters.AddWithValue("@p1",TxtKitapBul.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("select * from Tbl_Kitaplik where KitapAD like '%"+ TxtKitapBul.Text + "%'",bgl.baglanti());
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter( cmd4);
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }
    }
}
