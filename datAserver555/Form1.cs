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
using System.IO;

namespace datAserver555
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=albin\SQLEXPRESS;Initial Catalog=idpass;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
            string username, password;
            username = id.Text;             //read the values from the textbox.
            password = paas.Text;

            try
            {
                string querry = "SELECT * FROM Login WHERE userid = '"+id.Text+ "' AND password = '" +paas.Text+"'";
                /* here Login is the name of the sql table ; Replace it using the name of your table. */
                SqlDataAdapter sda =new SqlDataAdapter(querry,conn);        //Setup the connection with the server.
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                // check the user exists or not.
                if (dataTable.Rows.Count > 0 )
                {
                    username = id.Text;
                    password = paas.Text;

                    menu menu = new menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    //check whether any of the inputs are empty.
                    if (string.IsNullOrEmpty(id.Text) && string.IsNullOrEmpty(paas.Text))
                    {
                        label3.Text = "enter the userid and password";
                    }
                    else if (string.IsNullOrEmpty(id.Text))
                    {                        
                        label3.Text = "enter the userid";
                    }
                    else if (string.IsNullOrEmpty(paas.Text))
                    {
                        label3.Text = "enter the password";
                    }
                    else
                    {
                        label3.Text = "Invalid credentials";
                    }
                    id.Clear();
                    paas.Clear(); 
                }

            }
            catch 
            {
                MessageBox.Show("Error");
            }
            finally 
            {
                conn.Close();               //Close the connection.
            }   

        }  
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go to the signup page.
            Form2 form = new Form2();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
            this.Hide();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void forget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //go to the forgot password page  page.
            Form3 form = new Form3();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
            this.Hide();

        }
    }
}
