using ExcelDataReader;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using excel = Microsoft.Office.Interop.Excel;

namespace RentACar
{
    public partial class frnCustomerList : Form
    {
        private string connectionSentence = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";

        public frnCustomerList()
        {
            InitializeComponent();
        }

        private void frnCustomerList_Load(object sender, EventArgs e)
        {
            CustomerList();
        }
        public void CustomerList()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand(" exec sp_customers ",connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)//güncelle butonu
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Update Customerss set TcNo=@TcNo,NameSurname=@NameSurname,PhoneNumber=@PhoneNumber,Mail=@Mail,Adress=@Adress  ", connection);
            command.Parameters.AddWithValue("@TcNo", txtTc.Text);
            command.Parameters.AddWithValue("@NameSurname", txtNameSurname.Text);
            command.Parameters.AddWithValue("@PhoneNumber", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@Mail", txtMail.Text);
            command.Parameters.AddWithValue("@Adress", txtAdress.Text);
            command.ExecuteNonQuery();
            CustomerList();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)//delete butonu
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from Customerss  where TcNo='" +dataGridView1.CurrentRow.Cells["TcNo"].Value.ToString() + "'",connection);
            command.ExecuteNonQuery();
            CustomerList();
            connection.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           txtNameSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAdress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = dtc[sayfalar_combo.SelectedIndex];
            dataGridView1.DataSource = dt;

        }
        DataTableCollection dtc;

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog() { Filter = "Excel dosyaları 97-2023|*.xlsx|Excel Dosyaları|*.xlsx", Title = "EXCEL DOSYALARI" })
            {
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    dosya_adi_text.Text = openfile.FileName;
                    using (var stream = File.Open(openfile.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = excelreader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (x) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            }
                            );
                            dtc = result.Tables;
                            sayfalar_combo.Items.Clear();
                            foreach (DataTable table in dtc) sayfalar_combo.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            app.Visible = true;
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)kitap.Worksheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = dataGridView1[i, j].Value;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            string commandSentence = "SELECT * FROM Silinen_Customerss";

            SqlCommand command = new SqlCommand(commandSentence, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
