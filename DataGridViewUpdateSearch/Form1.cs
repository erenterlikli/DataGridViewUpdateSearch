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

namespace DataGridViewUpdateSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True");
        private void Goster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goster("Select * from Hastane.dbo.randevu");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Hastane.dbo.randevu(hasta,bolum,tarih,saat,doktor) Values(@hastaad,@bolumad,@tarihi,@saati,@doktorad)",baglan);
            komut.Parameters.AddWithValue("@hastaad", textBox1.Text);
            komut.Parameters.AddWithValue("@bolumad", comboBox1.Text);
            komut.Parameters.AddWithValue("@tarihi", textBox2.Text);
            komut.Parameters.AddWithValue("@saati", textBox3.Text);
            komut.Parameters.AddWithValue("@doktorad", textBox4.Text);

            komut.ExecuteNonQuery();
            Goster("Select * from Hastane.dbo.randevu");
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = " ";
            textBox1.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Hastane.dbo.randevu where hasta=@hastaad", baglan);
            komut.Parameters.AddWithValue("@hastaad", textBox5.Text);
            komut.ExecuteNonQuery();
            Goster("Select * from Hastane.dbo.randevu");
            baglan.Close();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int alan = dataGridView1.SelectedCells[0].RowIndex;
            string hasta = dataGridView1.Rows[alan].Cells[0].Value.ToString();
            string bolum = dataGridView1.Rows[alan].Cells[1].Value.ToString();
            string tarih = dataGridView1.Rows[alan].Cells[2].Value.ToString();
            string saat = dataGridView1.Rows[alan].Cells[3].Value.ToString();
            string doktor = dataGridView1.Rows[alan].Cells[4].Value.ToString();

            textBox1.Text = hasta;
            comboBox1.Text = bolum;
            textBox2.Text = tarih;
            textBox3.Text = saat;
            textBox4.Text = doktor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Hastane.dbo.randevu set bolum='" + comboBox1.Text + "',tarih='" + textBox2.Text + "',saat='" + textBox3.Text + "',doktor='" + textBox4.Text + "'where hasta='" + textBox1.Text + "' ", baglan);
            komut.ExecuteNonQuery();
            Goster("Select *from Hastane.dbo.randevu");
            baglan.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Hastane.dbo.randevu where hasta like '%" + textBox6.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            textBox6.Clear();

        }
    }
}
