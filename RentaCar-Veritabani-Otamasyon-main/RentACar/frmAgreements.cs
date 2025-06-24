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
    public partial class frmAgreements : Form
    {
        public frmAgreements()
        {
            InitializeComponent();
        }
        private string connectionSentence = @"Data Source=DESKTOP-105P9VT\MSSQLSERVER01;Initial Catalog=arackiralama;Integrated Security=True";

        public void CarList()
        {
            /*SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Cars where State='Bos'", connection);
            SqlDataReader dr = command.ExecuteReader();
           /* while (dr.Read())
            {
                //cbxCars.Items.Add(dr["NumberPlate"]);
            }*/

        }
        private void frmAgreements_Load(object sender, EventArgs e)
        {
            CarList();
            AgreementList();
        }
        public void AgreementList()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Agreement", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

        }

       

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            TimeSpan differenceDays = DateTime.Parse(datetimeCenter.Text) - DateTime.Parse(datetimeExit.Text);
            int CalculateDays = differenceDays.Days;
            txtDate.Text = CalculateDays.ToString();
            
            
            
            txtAmount.Text = (CalculateDays * int.Parse(txtRentMoney.Text)).ToString();
            


        }

        private void cbxRentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select RentMoney  from Cars", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                if (cbxRentType.SelectedIndex==0)
                {
                    txtAmount.Text = (int.Parse(dr["RentMoney"].ToString()) * 1).ToString();
                }
                else if (cbxRentType.SelectedIndex == 1)
                {
                    txtAmount.Text = (int.Parse(dr["RentMoney"].ToString()) * 0.80).ToString();
                }
                else if (cbxRentType.SelectedIndex == 2)
                {
                    txtAmount.Text = (int.Parse(dr["RentMoney"].ToString()) * 0.50).ToString();
                }

            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();

            /* string commandSentence = "Insert Into Agreement Values (@tcno,@AdSoyad,@Telefon,@ehliyetno,@ehliyettarih,@plaka,@Marka,@Seri,@Model,@Renk,@kirasekli,@kiraücreti,@kiralanangünsayisi,@tutar,@cikistarih,@dönüstarih)";
             SqlCommand command = new SqlCommand(commandSentence, connection);
             command.Parameters.AddWithValue("@tcno", txtTc.Text);
             command.Parameters.AddWithValue("@AdSoyad", txtNameSurname.Text);
             command.Parameters.AddWithValue("@Telefon", txtTel.Text);
             command.Parameters.AddWithValue("@ehliyetno", txtDrivingLicenceNo.Text);
             command.Parameters.AddWithValue("@ehliyettarih", txtDrivingDate.Text);
             command.Parameters.AddWithValue("@plaka", textBox1.Text);
             command.Parameters.AddWithValue("@Marka", txtBrand.Text);
             command.Parameters.AddWithValue("@Seri", txtSeries.Text);
             command.Parameters.AddWithValue("@Model", txtModel.Text);
             command.Parameters.AddWithValue("@Renk", txtColor.Text);
             command.Parameters.AddWithValue("@kirasekli", cbxRentType.SelectedItem);
             command.Parameters.AddWithValue("@kiraücreti", txtRentMoney.Text);
             command.Parameters.AddWithValue("@kiralanangünsayisi", txtDate.Text);
             command.Parameters.AddWithValue("@tutar", txtAmount.Text);
             command.Parameters.AddWithValue("@cikistarih", datetimeExit.Value);
             command.Parameters.AddWithValue("@dönüstarih", datetimeCenter.Value);

             string commandSentenceUp = "update Cars set State= 'Dolu' where NumberPlate ='" + textBox1.Text + "'";




             SqlCommand commandUp = new SqlCommand(commandSentenceUp, connection);

             commandUp.ExecuteNonQuery();

             try
             {
                 command.ExecuteNonQuery();
                 MessageBox.Show("Kayıt Başarılı");
             }
             catch (Exception)
             {

                 MessageBox.Show("Alanlar boş geçilemez");
             }
             */

            try
            {
                
                string checkStateQuery = "SELECT State FROM Cars WHERE NumberPlate = @Plaka";
                SqlCommand checkStateCommand = new SqlCommand(checkStateQuery, connection);
                checkStateCommand.Parameters.AddWithValue("@Plaka", textBox1.Text);

                string carState = checkStateCommand.ExecuteScalar() as string;

                if (carState != null && carState.Equals("Dolu"))
                {
                    MessageBox.Show("Araç zaten kiralanmış durumda. Başka bir araç seçiniz.");
                    return;
                }

                
                string commandSentenceUp = "UPDATE Cars SET State = 'Dolu' WHERE NumberPlate = @Plaka";
                SqlCommand commandUp = new SqlCommand(commandSentenceUp, connection);
                commandUp.Parameters.AddWithValue("@Plaka", textBox1.Text);
                commandUp.ExecuteNonQuery();

                
                string commandSentence = "INSERT INTO Agreement VALUES (@tcno, @AdSoyad, @Telefon, @ehliyetno, @ehliyettarih, @plaka, @Marka, @Seri, @Model, @Renk, @kirasekli, @kiraücreti, @kiralanangünsayisi, @tutar, @cikistarih, @dönüstarih)";
                SqlCommand command = new SqlCommand(commandSentence, connection);
                command.Parameters.AddWithValue("@tcno", txtTc.Text);
                command.Parameters.AddWithValue("@AdSoyad", txtNameSurname.Text);
                command.Parameters.AddWithValue("@Telefon", txtTel.Text);
                command.Parameters.AddWithValue("@ehliyetno", txtDrivingLicenceNo.Text);
                command.Parameters.AddWithValue("@ehliyettarih", txtDrivingDate.Text);
                command.Parameters.AddWithValue("@plaka", textBox1.Text);
                command.Parameters.AddWithValue("@Marka", txtBrand.Text);
                command.Parameters.AddWithValue("@Seri", txtSeries.Text);
                command.Parameters.AddWithValue("@Model", txtModel.Text);
                command.Parameters.AddWithValue("@Renk", txtColor.Text);
                command.Parameters.AddWithValue("@kirasekli", cbxRentType.SelectedItem);
                command.Parameters.AddWithValue("@kiraücreti", txtRentMoney.Text);
                command.Parameters.AddWithValue("@kiralanangünsayisi", txtDate.Text);
                command.Parameters.AddWithValue("@tutar", txtAmount.Text);
                command.Parameters.AddWithValue("@cikistarih", datetimeExit.Value);
                command.Parameters.AddWithValue("@dönüstarih", datetimeCenter.Value);

                command.ExecuteNonQuery();

                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            connection.Close();
            AgreementList();
            CarList();
            
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Customerss where TcNo like '" +txtTcSearch.Text + "'", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                txtTc.Text = dr["TcNo"].ToString();
                txtNameSurname.Text = dr["NameSurname"].ToString();
                txtTel.Text = dr["PhoneNumber"].ToString();
                
            }
        }
        DataTableCollection dtc;
        private void btnVehicleDelivery_Click(object sender, EventArgs e)//araç teslim
        {

            using (OpenFileDialog openfile = new OpenFileDialog() { Filter = "Excel dosyaları 97-2023|*.xlsx|Excel Dosyaları|*.xlsx", Title = "EXCEL DOSYALARI" })
            {
                if (openfile.ShowDialog()==DialogResult.OK)
                {
                    dosya_adi.Text = openfile.FileName;
                    using (var stream = File.Open(openfile.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader excelreader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result=excelreader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable=(x)=> new ExcelDataTableConfiguration() { UseHeaderRow=true}
                            }    
                            );
                            dtc = result.Tables;
                            sayfa_secim_combo.Items.Clear();
                            foreach(DataTable table in dtc) sayfa_secim_combo.Items.Add(table.TableName);
                        }
                    }
                }
            }








            /*DataGridViewRow line = dataGridView1.CurrentRow;
            DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
            int pay = int.Parse(line.Cells["RentMoney"].Value.ToString());
            int amount = int.Parse(line.Cells["Amount"].Value.ToString());
            DateTime exit = DateTime.Parse(line.Cells["ExitDate"].Value.ToString());
            TimeSpan days = today - exit;
            int Day = days.Days;
            int totalAmount = Day - pay;

            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            string commandSentence = "Delete from Agreement where LicensePlate= '" + line.Cells["LicensePlate"].Value.ToString() + "'";
            SqlCommand command = new SqlCommand(commandSentence, connection);
            command.ExecuteNonQuery();


            string commandSentenceUp = "update Cars set State = 'Bos' where NumberPlate = '" + line.Cells["NumberPlate"].Value.ToString() + "'";
            SqlCommand commandUp = new SqlCommand(commandSentence, connection);
            commandUp.ExecuteNonQuery();

            string commandSentenceSales = "Insert Into Sales Values (@TcNo,@NameSurname,@LicensePlate,@RentType,@RentMoney,@Amount,@ExitDate,@ReturnDate)";
            SqlCommand commandSales = new SqlCommand(commandSentenceSales, connection);
            commandSales.Parameters.AddWithValue("@TcNo", line.Cells["TcNo"].Value.ToString());
            commandSales.Parameters.AddWithValue("@NameSurname", line.Cells["NameSurname"].Value.ToString());
            commandSales.Parameters.AddWithValue("@LicensePlate", line.Cells["LicensePlate"].Value.ToString());
            commandSales.Parameters.AddWithValue("@day", Day);
            commandSales.Parameters.AddWithValue("@RentType", line.Cells["RentType"].Value.ToString());
            commandSales.Parameters.AddWithValue("@RentMoney", pay);
            commandSales.Parameters.AddWithValue("@Amount", totalAmount);
            commandSales.Parameters.AddWithValue("@ExitDate", line.Cells["ExitDate"].Value.ToString());
            commandSales.Parameters.AddWithValue("@ReturnDate", line.Cells["ReturnDate"].Value.ToString());
            commandSales.ExecuteNonQuery();

            MessageBox.Show("Araç Teslim Edildi");*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Cars where NumberPlate like '" + textBox1.Text + "'", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                txtBrand.Text = dr["Brand"].ToString();
                txtSeries.Text = dr["Series"].ToString();
                txtModel.Text = dr["Model"].ToString();
                txtColor.Text = dr["Color"].ToString();

            }
        }

        private void sayfa_secim_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = dtc[sayfa_secim_combo.SelectedIndex];
            dataGridView1.DataSource = dt;  
        }

        private void btn_disa_aktar_Click(object sender, EventArgs e)
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
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for(int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j+1, i+1];
                    alan2.Cells[2, 1] = dataGridView1[i,j].Value;
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dosya_adi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
