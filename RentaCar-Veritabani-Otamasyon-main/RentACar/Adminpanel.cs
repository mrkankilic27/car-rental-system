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
    public partial class Adminpanel : Form
    {
        public Adminpanel()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain k = new frmMain();
            this.Hide();
            k.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register t = new Register();
            this.Hide();
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 l = new Form2();
            this.Hide();
            l.Show();
        }
    }
}
