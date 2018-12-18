using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private string connectionstring;
        private MySqlConnection Connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionstring = "server=localhost;Database=hosteldb;Uid=root;Pwd=amarangamutima1212";
            Connection = new MySqlConnection(connectionstring);
            Connection.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Usernametext = textBox1.Text;
            var passwordtext = textBox2.Text;
            var selectcommand = new MySqlCommand();
            selectcommand.CommandText = "SELECT *FROM users where username=@username and password=@password";
            selectcommand.Parameters.AddWithValue("@username", Usernametext);
            selectcommand.Parameters.AddWithValue("password", passwordtext);
            selectcommand.Connection = Connection;
            MySqlDataReader dataReader = selectcommand.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("login successful");

            }
            else
            {
                MessageBox.Show("   dd");
            }
        }
    }
}
