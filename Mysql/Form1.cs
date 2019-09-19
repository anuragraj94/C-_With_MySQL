using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string strCon;
        public static MySqlConnection con;
        public static MySqlCommand cmd;
        public static MySqlDataAdapter da;
        public static DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'new_schemaDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.new_schemaDataSet.users);
            this.Text = "My SQL Testing";
            button1.Text = "Connection ?";
            button2.Text = "Show";
            button3.Text = "Next Page";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strCon = "server=localhost;persistsecurityinfo=True;database=new_schema;uid=root;pwd=Mysql@123456";
            con = new MySqlConnection(strCon);
            try
            {
                con.Open();
                MessageBox.Show("Connection Open...");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand("select * from Users", con);
                con.Open();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Show is showing some Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNext frmNext = new frmNext();
            frmNext.Show();
        }
        private void frmBITE_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("It's working");
            if (e.Control && e.KeyCode.ToString() == "L")
            {
                //frmNext objFormatLogger = new frmNext();
                //objFormatLogger.ShowDialog(this);
                frmNext frmNext = new frmNext();
                frmNext.Show();
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            this.Text = "working";
            //if (e.Control && e.KeyCode.ToString() == "L")
            //{              
            //    frmNext frmNext = new frmNext();
            //    frmNext.Show();
            //}
        }
    }
}
