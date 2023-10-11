using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datAserver555
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.FormClosed += Form4_FormClosed;
            
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            // this will close the whole app when this window is closed.
        }

        private void Setinput(string input)
        {
            var recivedinput = input;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string password1, password2;
            password1 = textBox2.Text;      //read the values from the textbox.
            password2 = textBox3.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=server;Initial Catalog=idpass;Integrated Security=True");
            /* enter the name of  your data server by replacing 'server' on the above line.
            Below if else ladder is for checking whether any of the inputs are empty.*/
            if (string.IsNullOrEmpty(password1) && string.IsNullOrEmpty(password2))
            {
                label5.Text = "password cannot be null";
            }
            else if (string.IsNullOrEmpty(password2))
            {
                label5.Text = "enter the password as above";
            }
            else if (string.IsNullOrEmpty(password1))
            {
                label5.Text = "enter the password on both!";
            }
            else
            {
                if (password1 != password2)
                {
                    label5.Text = "passwords doesnot match, tryagain";
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    label5.ResetText();
                    conn.Open();        //Setup the connection with the server.
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Login] SET [password] = '"+password1+"' WHERE [userid]='"+Form3.set+"'", conn);
                    /* here [dbo].[Login] is the name of the sql table replace it using the name of your table */
                    cmd.ExecuteNonQuery();
                    conn.Close();  //Close the connection
                    MessageBox.Show("password changed");
                    //go to the login page.
                    Form1 form = new Form1();
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = this.Location;
                    form.Show();
                    this.Hide();
                }


                }
          } 
    }
}
