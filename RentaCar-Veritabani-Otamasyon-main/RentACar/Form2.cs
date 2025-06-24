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

namespace RentACar
{
    public partial class Form2 : Form

    {
        SqlConnection con=new SqlConnection("server= DESKTOP-105P9VT\\MSSQLSERVER01; database= arackiralama; integrated security =true");
        
        public Form2()
        {
            InitializeComponent();
        } 



        private void Form2_Load(object sender, EventArgs e)
        {
            btn_don_yedek.Enabled = false;
        }

        private void btn_yedekle_Click(object sender, EventArgs e)
        {
            string database= con.Database.ToString();
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Lütfen dosya konumunu giriniz");
            }
            else
            {
                string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + textBox1.Text + "\\" + "database" + "-" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd,con);
                command.ExecuteNonQuery();
                MessageBox.Show("Yedekleme Başarılı");
                con.Close();
                btn_yedekle.Enabled = false;

                
            }
        }

        private void btn_yedek_ara_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dig = new FolderBrowserDialog();
            if(dig.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dig.SelectedPath;
                btn_yedekle.Enabled = true;
            }
        }
        
        private void btn_yedekten_ara_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Filter = "SQL SERVER database backup files |*.bak";
            dig.Title = "Database restore";
            if(dig.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dig.FileName;
                btn_don_yedek.Enabled = true;
            }
            btn_don_yedek.Enabled = true;
        }

        private void btn_don_yedek_Click(object sender, EventArgs e)
        {
            
            string database = con.Database.ToString();
            try
            {
                con.Open();
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER_WITH ROLLBACK IMADIATE");
                SqlCommand cmd1 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();
                string str2 = "USE MASTER RESTORE DATABASE[" + database + "] FROM DISK='" + textBox2.Text + "'WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, con);
                cmd2.ExecuteNonQuery();
                string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Yedekten Dönme Başarılı");
                con.Close();
                
               
            }
            catch 
            {
                MessageBox.Show("yedekten dönme başarılı");


            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adminpanel k = new Adminpanel();
            this.Hide();
            k.Show();
        }
    }
}
