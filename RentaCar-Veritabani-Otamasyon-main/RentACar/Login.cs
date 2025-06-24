using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RentACar
{
    public partial class Login : Form
    {
        
        private string connectionString = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = txtuname.Text;
            string pass = txtpass.Text;

            if (AuthenticateAdmin(uname, pass))
            {
                MessageBox.Show("Admin Login Success");
                Adminpanel k = new Adminpanel();
                this.Hide();
                k.Show();
                /*MessageBox.Show("Login Success");
                frmMain m = new frmMain();
                this.Hide();
                m.Show();*/
            }
            else  
            {
                //uname.Equals("Admin") && pass.Equals("123
                /*MessageBox.Show("Admin Login Success");
                Adminpanel k = new Adminpanel();
                this.Hide();
                k.Show();*/
                MessageBox.Show("Admin şifresini veya kullanıcı adını yanlış girdiniz veya bu yetkiye sahip olmayan kullanıcı ile giriş yapmaya çalıştınız.");
                txtuname.Clear();
                txtpass.Clear();
                txtuname.Focus();

            }
            
        }
        private bool AuthenticateAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Adminler WHERE kullanici_adi = @kullanici_adi AND sifre = @sifre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullanici_adi", username);
                    command.Parameters.AddWithValue("@sifre", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }


            private bool AuthenticateUser(string username, string password)
         {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Calisanlar WHERE kullanici_adi = @kullanici_adi AND sifre = @sifre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullanici_adi", username);
                    command.Parameters.AddWithValue("@sifre", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private bool AuthenticateChef(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Sefler WHERE kullanici_ad = @kullanici_ad AND sifre = @sifre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullanici_ad", username);
                    command.Parameters.AddWithValue("@sifre", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string uname = textBox2.Text;
            string pass = textBox1.Text;
            if (AuthenticateUser(uname, pass))
            {
                MessageBox.Show("Login Success");
                Form3 m = new Form3();
               
                this.Hide();
                m.Show();
            }
            else if (AuthenticateAdmin(uname, pass))

                //uname.Equals("Admin") && pass.Equals("123")

            {
                MessageBox.Show("Giriş Başarılı");
                frmMain m = new frmMain();
                this.Hide();
                m.Show();
                /* MessageBox.Show("Admin Girişi Başarılı");
                 Adminpanel k = new Adminpanel();
                 this.Hide();
                 k.Show();*/

            }
            else
            {
                MessageBox.Show("Giriş Başarısız Lütfen Çalışan  Kullanıcı adı ve şifresi giriniz.");
                textBox2.Clear();
                textBox1.Clear();
                textBox2.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string uname = textBox6.Text;
            string pass = textBox5.Text;
            if (AuthenticateChef(uname, pass))
            {
                MessageBox.Show("Login Success");
                frmMain m = new frmMain();
                this.Hide();
                m.Show();
            }
            else if (uname.Equals("Admin") && pass.Equals("123"))
            {
                MessageBox.Show("Admin Girişi Başarılı");
                Adminpanel k = new Adminpanel();
                this.Hide();
                k.Show();

            }
            else
            {
                MessageBox.Show("Girişi Başarısız Lütfen Şef Kullanıcı adı ve şifresi giriniz.");
                textBox6.Clear();
                textBox5.Clear();
                textBox6.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            groupBox1.Visible = false; 
            groupBox2.Visible=false;
            groupBox4.Visible=false;
           
        }

        private void btn_admin_girisi_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
        }

        private void btn_calisan_girisi_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
        }

        private void btn_sef_girisi_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }
    }
}
