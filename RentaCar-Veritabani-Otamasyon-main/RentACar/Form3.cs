using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frnCustomerList customerList = new frnCustomerList();
            customerList.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerAdd frmCustomer = new frmCustomerAdd();
            frmCustomer.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            frmCarAdd carAdd = new frmCarAdd();
            carAdd.ShowDialog();
        }

        private void btnCarLıst_Click(object sender, EventArgs e)
        {
            formCarList carList = new formCarList();
            carList.ShowDialog();

        }
    }
}
