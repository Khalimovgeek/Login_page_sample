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

namespace datAserver555
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
    
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            // this will close the whole app when this window is closed.
            Application.Exit();
        }

        public static string set = "";
        
        SqlConnection conn = new SqlConnection(@"Data Source=server;Initial Catalog=idpass;Integrated Security=True");
        /* enter the name of  your data server by replacing the term  'server' on the above line.*/
        private void button1_Click(object sender, EventArgs e)
        {
            string username, Req, Ans;
            username=id.Text;
            Req = recovery.Text;         //read the values from the textbox.
            Req=Req.ToLower();          
            Ans = Answer.Text;
           
            conn.Open();
            string querry = "SELECT * FROM Login WHERE userid = '" + id.Text + "' AND recoveryq = '" + Req + "' AND answer='"+Ans+"'";
            // here login is the name of the sql table ; Replace it using the name of your table .
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);      //Setup the connection with the server.
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            set=id.Text;
            if (dataTable.Rows.Count == 0)
            {
                conn.Close();           //Close the connection.
                label5.Text = "check the crediantials";
            }
            else
            {
                conn.Close ();              //Close the connection.
               
                Form4 form4 = new Form4();          //go to the next page.
                form4.StartPosition = FormStartPosition.Manual;
                form4.Location = this.Location;
                form4.Show();
                this.Hide();
            }
        }
       
    }
}

