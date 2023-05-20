using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohamed
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flightTPL vi = new flightTPL();
            vi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 vi = new Form1();
            vi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           ticket vi = new ticket();
            vi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canselation vi = new canselation();
            vi.Show();
            this.Hide();
        }
    }
}
