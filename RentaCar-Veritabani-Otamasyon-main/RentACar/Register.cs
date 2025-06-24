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

namespace RentACar
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private string connectionSentence = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
             
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            try
            {
                string kullanici_adi = txtusname.Text;
                string sifre = txtpassw.Text;



                
                string insertDataQuery = "INSERT INTO Calisanlar (kullanici_adi, sifre) VALUES (@kullanici_adi, @sifre)";
                SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection);
                insertDataCommand.Parameters.AddWithValue("@kullanici_adi", kullanici_adi);
                insertDataCommand.Parameters.AddWithValue("@sifre", sifre);
                insertDataCommand.ExecuteNonQuery();

                MessageBox.Show("Kayıt Başarılı");
                Adminpanel a = new Adminpanel();
                this.Hide();
                a.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminpanel k = new Adminpanel();
            this.Hide();
            k.Show();

        }

        private void bttn_sef_ekle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            try
            {
                string kullanici_adi = textBox1.Text;
                string sifre =textBox2.Text;




                string insertDataQuery = "INSERT INTO Sefler (kullanici_ad, sifre) VALUES (@kullanici_ad, @sifre)";
                SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection);
                insertDataCommand.Parameters.AddWithValue("@kullanici_ad", kullanici_adi);
                insertDataCommand.Parameters.AddWithValue("@sifre", sifre);
                insertDataCommand.ExecuteNonQuery();

                MessageBox.Show("Kayıt Başarılı");
                Adminpanel a = new Adminpanel();
                this.Hide();
                a.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }


    
}



