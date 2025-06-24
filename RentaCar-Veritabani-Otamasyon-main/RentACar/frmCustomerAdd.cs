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
    public partial class frmCustomerAdd : Form
    {
        public frmCustomerAdd()
        {
            InitializeComponent();
        }

        private string connectionSentence = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";
        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//kaydetme butonu

        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Customerss Values(@TcNo,@NameSurname,@PhoneNumber,@Mail,@Adress)",connection);

            command.Parameters.AddWithValue("@TcNo", txtTc.Text);
            command.Parameters.AddWithValue("@NameSurname", txtNameSurname.Text);
            command.Parameters.AddWithValue("@PhoneNumber", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@Mail", txtMail.Text);
            command.Parameters.AddWithValue("@Adress", txtAdress.Text);


            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kayıt Başarılı");
                txtTc.Clear();
                txtNameSurname.Clear();
                maskedTextBox1.Clear();
                txtMail.Clear();
                txtAdress.Clear();

            }
            catch (Exception)
            {

                MessageBox.Show("Tc no yu 11 haneli giriniz...");
            }


            
            

        }
    }
}
