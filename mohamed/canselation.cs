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
    public partial class canselation : Form
    {
        public canselation()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmem\Documents\airlineDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillcancellation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select tid from Ticket", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("tid", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "tid";
            comboBox1.DataSource = dt;
            con.Close();
        }
        private void fetshfcode()
        {
            con.Open();
            string query = "select * from Ticket where tid=" + comboBox1.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["flightcode"].ToString();
                
            }
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from cancellation";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            //listBox1.DataSource = ds.Tables[0];
            
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void canselation_Load(object sender, EventArgs e)
        {
            fillcancellation();
            populate();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetshfcode();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "")
                { MessageBox.Show("Missing information"); }
                else
                {
                    try
                    {
                        con.Open();
                        string query = "insert into cancellation values(" + textBox1.Text + ",'" + comboBox1.SelectedValue.ToString() + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("cancellation Booked successfully");
                        con.Close();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("enter the ticket id to delete");
                }
                else
                {
                    try
                    {
                        con.Open();
                        string query = "delete from Ticket where tid='" + comboBox1.SelectedValue.ToString() + "';";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ticket delete is succefully ");
                        con.Close();
                        
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);

                    }
                }
            }
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticket vi = new ticket();
            vi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home H = new Home();
            H.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
    }
}
