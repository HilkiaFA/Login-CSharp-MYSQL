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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
        /*ganti sesuai nama database username database dan password anda*/
        string connString = "server=127.0.0.1;database=login;uid=admin;password=admin";
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM login where username='" + txt_username.Text + "'AND password='" + txt_password.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@username", txt_username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_password.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login sukses");
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("gagal" + ex.Message);
                }
        }
    }
}
