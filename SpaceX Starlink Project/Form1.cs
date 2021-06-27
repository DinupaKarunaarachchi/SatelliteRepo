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

namespace SpaceX_Starlink_Project
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\spacex.mdf;Integrated Security=True;Connect Timeout=30");
       
        int ID;
        string name;
        string longitude;
        string elevation;
        string latitude;
        string healthstatus;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            healthstatus = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            

            ID = int.Parse(textBox1.Text);
            name = textBox2.Text;
            longitude = Convert.ToString(textBox3.Text);
            elevation = Convert.ToString(textBox4.Text);
            latitude = Convert.ToString(textBox5.Text);



            string query = "INSERT INTO Satellites (satid,satname,longtitute,latitute,elevation,health) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful");
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se.ToString());
            }
            finally
            {
                con.Close();
            }

            display();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Excelent");
            comboBox1.Items.Add("Good");
            comboBox1.Items.Add("Weak");
        }

        public void display()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SATELLITES",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Satellites WHERE satid = "+ textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
            finally
            {
                con.Close();
            }
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Satellites SET satname='" + textBox2.Text + "',longtitute='" + textBox3.Text + "',latitute='" + textBox5.Text + "',elevation='" + textBox4.Text + "',health='" + comboBox1.Text + "' WHERE satid='" + textBox1.Text + "' ",con);
            cmd.ExecuteNonQuery();
            con.Close();
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Satellites";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful");
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error......" + se.ToString());
            }
            finally
            {
                con.Close();
            }
            display();
        }
    }
}
