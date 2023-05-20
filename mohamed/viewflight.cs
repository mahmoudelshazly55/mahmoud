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
namespace mohamed
{
    public partial class viewflight : Form
    {
        public viewflight()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmem\Documents\airlineDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            con.Open();
            string query = "select * from flight";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            //listBox1.DataSource = ds.Tables[0];
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void viewflight_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flightTPL fo = new flightTPL();
            fo.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter the flight id to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from flight where flightcde='"+ textBox1.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("flight delete is succefully ");
                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""|| comboBox2.Text == "" || comboBox1.Text == ""||dateTimePicker1.Text=="")
            { MessageBox.Show("Missing information"); }
            else
            {
                try
                {
                    con.Open();
                    string query = "update flight set fsoc='" + comboBox1.SelectedItem.ToString() + "',fDest='" + comboBox2.SelectedItem.ToString() + "',fDate='" + dateTimePicker1.Value.ToString() + "',fCap='" + textBox2.Text + "'where flightcde='" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("flight update successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
