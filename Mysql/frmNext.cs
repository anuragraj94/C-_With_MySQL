using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mysql
{
    public partial class frmNext : Form
    {
        public frmNext()
        {
            InitializeComponent();
        }
        public static string strCon;
        public static MySqlConnection con;
        public static MySqlCommand cmd;
        public static MySqlDataAdapter da;
        public static DataTable dt = new DataTable();
        public static bool bCon=false;
        int i = 1;

        private void frmNext_Load(object sender, EventArgs e)
        {
            string sPath = @"C:\ProgramData\MySQL\MySQL Server 8.0\Data\";
            string dbPath1 = "smartloggerdb_template";
            string dbPath2 = "smartlogger_backup_template";
            this.Text = "User Details";
            strCon = "server=localhost;persistsecurityinfo=True;database=new_schema;uid=root;pwd=Mysql@123456";
            con = new MySqlConnection(strCon);           
            lblMsg.Text="";
            LoadGrid();
            try
            {
                File.Copy(sPath + dbPath1, @"C:\Users\AE TELELINK\Desktop\New folder", true);
            }
            catch (Exception ex)
            {

                throw;
            }            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {                
                cmd = new MySqlCommand("insert into tblUserDetails values("+i+"," + txtUName.Text + "," + txtPassword.Text + "," + txtEmail.Text + "," + txtMobile.Text + ")", con);
                con.Open();
                if (bCon==false)
                {
                    bCon = true;
                }                          
                if (cmd.ExecuteNonQuery()==1)
                {
                    lblMsg.Text = "Insertion Successful.....";                    
                }
                else
                {
                    lblMsg.Text = "Something is wrong";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.ToString();
            }
            txtUName.Text = "";
            txtPassword.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
        }
        private void LoadGrid()
        {
            try
            {
                cmd = new MySqlCommand("select User_Name,Password,Email,Mobile from tblUserDetails", con);
                if (bCon!=true)
                {
                    con.Open();
                }
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
                bCon = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Show is showing some Error");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGrid();
            lblMsg.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            lblMsg.Text = "";
        }       
    }
}
