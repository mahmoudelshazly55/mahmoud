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
    public partial class ticket : Form
    {
        public ticket()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmem\Documents\airlineDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void fillpassenger()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from passnger", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(rdr);
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = dt;
            con.Close();
        }
        private void fillflight()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select flightcde from flight", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("flightcde", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "flightcde";
            comboBox1.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from Ticket";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            //listBox1.DataSource = ds.Tables[0];

            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        private void ticket_Load(object sender, EventArgs e)
        {
            fillpassenger();
            fillflight();
            populate();

        }
        string passname, passport, passnation;

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" ||comboBox1.Text == "" || comboBox2.Text == "")
            { MessageBox.Show("Missing information"); }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into Ticket values(" + textBox1.Text + ",'" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Booked successfully");
                    con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
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

        private void fetshpassenger()
        {
            con.Open();
            string query = "select * from passnger where id=" + comboBox2.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                passname = dr["passname"].ToString();
                passport = dr["passportnum"].ToString();
                passnation = dr["passnationality"].ToString();
                textBox2.Text = passname;
                textBox6.Text = passport;
                textBox4.Text = passnation;
            }
            con.Close();
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetshpassenger();

        }
    }
}
