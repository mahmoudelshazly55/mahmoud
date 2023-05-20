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

namespace mohamed
{
    public partial class view_passenger : Form
    {
        public view_passenger()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmem\Documents\airlineDB.mdf;Integrated Security=True;Connect Timeout=30");
       private void populate()
        {
            con.Open();
            string query = "select * from passnger";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            //listBox1.DataSource = ds.Tables[0];
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
            
        }
        private void view_passenger_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();
            fo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("enter the passenger id to delete");
            }
            else
            {
                try {
                    con.Open();
                    string query = "delete from passnger where id=" + textBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("passenger delete is succefully ");
                    con.Close();
                    populate();
                } catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text= dataGridView1.SelectedRows[0].Cells[3].Value.ToString(); 
            comboBox2.SelectedItem= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox3.SelectedItem= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
           // textBox5.Text= dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedItem = "";
            comboBox3.SelectedItem = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox3.Text == "" || comboBox2.Text == "" || textBox5.Text == "")
            { MessageBox.Show("Missing information"); }
            else
            {
                try
                {
                    con.Open();
                    string query = "update passnger set passname='" + textBox2.Text + "',passportnum='" + textBox3.Text + "',passaddress='" + textBox4.Text + "',passnationality='" + comboBox2.SelectedItem.ToString() + "',Gender='" + comboBox3.SelectedItem.ToString() + "',phone='" + textBox5.Text + "'where id=" + textBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("passenger update successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
