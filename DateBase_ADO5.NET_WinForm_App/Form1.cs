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

namespace DateBase_ADO5.NET_WinForm_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        private void GetList()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\andre\source\repos\DateBase_ADO5.NET_WinForm_App\DateBase_ADO5.NET_WinForm_App\dbSchool.mdf;Integrated Security=True");
            da = new SqlDataAdapter("SELECT * FROM Student", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Student");
            DataGridViewTable.DataSource = ds.Tables["Student"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
