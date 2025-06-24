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
using System.Windows.Forms.VisualStyles;
using DataTable = System.Data.DataTable;
using excel = Microsoft.Office.Interop.Excel;

namespace RentACar
{
    public partial class formCarList : Form
    {
        private string connectionSentence = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";

        public formCarList()
        {
            InitializeComponent();
        }
        public void Car_List()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();

            String commandSentence = "exec sp_cars";
            SqlCommand command = new SqlCommand(commandSentence, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        private void formCarList_Load(object sender, EventArgs e)
        {
            Car_List();
        }
        public void Car_Update()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            string commandSentence = "Update Cars set Brand=@Brand,Series=@Series,Model=@Model,Color=@Color,Kilometer=@Kilometer,Fuel=@Fuel,RentMoney=@RentMoney where NumberPlate=@NumberPlate";
            SqlCommand command = new SqlCommand(commandSentence, connection);
            command.Parameters.AddWithValue("@NumberPlate", txtlicenseplate.Text);
            command.Parameters.AddWithValue("@Brand", cmbBrand.Text);
            command.Parameters.AddWithValue("@Series", cmbSeries.Text);
            command.Parameters.AddWithValue("@Model", txtModel.Text);
            command.Parameters.AddWithValue("@Color", txtColor.Text);
            command.Parameters.AddWithValue("@Kilometer", txtKilometer.Text);
            command.Parameters.AddWithValue("@Fuel", cmbFuil.Text);
            command.Parameters.AddWithValue("@RentMoney", txtRentAmount.Text);
            command.Parameters.AddWithValue("@State", cmbState.SelectedIndex);
            command.ExecuteNonQuery();
            connection.Close();
            Car_List();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Car_Update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtlicenseplate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbBrand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbSeries.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtModel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtColor.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtKilometer.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cmbFuil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtRentAmount.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();


            string commandSentence = "Delete from Cars where NumberPlate='" + dataGridView1.CurrentRow.Cells["NumberPlate"].Value.ToString() + "'";
            SqlCommand command = new SqlCommand(commandSentence, connection);

            command.ExecuteNonQuery();
            connection.Close();
            Car_List();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        DataTableCollection dtc;

        private void btn_ice_aktar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog() { Filter = "Excel dosyaları 97-2023|*.xlsx|Excel Dosyaları|*.xlsx", Title = "EXCEL DOSYALARI" })
            {
                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    txt_dosya_konum.Text = openfile.FileName;
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
                            cmb_sayfalar.Items.Clear();
                            foreach (DataTable table in dtc) cmb_sayfalar.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void btb_disa_aktar_Click(object sender, EventArgs e)
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
        

        private void cmb_sayfalar_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = dtc[cmb_sayfalar.SelectedIndex];
            dataGridView1.DataSource = dt;
        }

        private void cmbFuil_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            string commandSentence = "SELECT * FROM SilinenArabalar";
            
            SqlCommand command = new SqlCommand(commandSentence, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
