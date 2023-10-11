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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;

namespace datAserver555
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormClosed += Form2_FormClosed;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {

            string username, password1, password2,Recovery,Ans;
            username = id.Text;
            password1 = textBox2.Text;          
            password2 = textBox3.Text;          //read the values from the textbox.
            Recovery = Req.Text;
            Ans=textBox1.Text;
            
                SqlConnection conn = new SqlConnection(@"Data Source=server;Initial Catalog=idpass;Integrated Security=True");
            /* enter the name of  your data server by replacing 'server' on the above line.
            Below if else ladder is for checking whether any of the inputs are empty.*/
            if (string.IsNullOrEmpty(id.Text) && string.IsNullOrEmpty(password1) && string.IsNullOrEmpty(password2))
                {
                    label5.Text = "userid and password cannot be null";
                }
                else if (string.IsNullOrEmpty(id.Text))
                {
                    label5.Text = "userid cannot be null";
                }
                else if (string.IsNullOrEmpty(password1) && string.IsNullOrEmpty(password2))
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
                else if (string.IsNullOrEmpty(Recovery))
                {
                    label5.Text = "enter the recovery question";
                }
                else if (string.IsNullOrEmpty(Ans))
                {
                    label5.Text = "enter the recovery answer ";
                }
                else
                {
                    // verify the entered password.
                    if (password1 != password2)
                    {
                        label5.Text = "passwords doesnot match, tryagain";
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        label5.ResetText();
                   
                        conn.Open();
                        SqlCommand check = new SqlCommand(@"SELECT * FROM [dbo].[Login] WHERE ([userid] = @username)", conn);
                         /* here [dbo].[Login] is the name of the sql table ; Replace it using the name of your table . */
                        check.Parameters.AddWithValue(@"username", id.Text);
                        SqlDataReader reader = check.ExecuteReader();
                            // check the user already exists or not.
                        if (!reader.HasRows)
                        {
                        conn.Close();
                        /* here [dbo].[Login] is the name of the sql table ; Replace it using the name of your table . */
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Login]
                        ([userid]
                        ,[password]
                        ,[recoveryq]
                        ,[answer])       
                     VALUES           
                            ('" + username + "','" + password1 + "','" + Recovery + "','" + Ans + "')", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                            this.Hide();
                            MessageBox.Show("Registration succesful; click to redirect to login page.");
                            MessageBoxButtons buttons = MessageBoxButtons.OK;

                            Form1 form = new Form1();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                        label5.Text = "user already exist";
                        id.Clear();
                        conn.Close();
                        }

                    
                    }
                    
                        
    
                }
                    
                    

            /*
            

                

                
                           
            

            */

        }
    }

}

