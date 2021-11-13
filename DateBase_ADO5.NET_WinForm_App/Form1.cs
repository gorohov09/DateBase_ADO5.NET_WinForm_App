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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO Student VALUES (N'{textFirstName.Text}',N'{textLastName.Text}','{textAveScore.Text}')";
            if (textFirstName.Text == "" || textLastName.Text == "" || textAveScore.Text == "")
            {
                MessageBox.Show("Вы оставили пустыми поля", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                return;
            }
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if ((textFirstName.Text != "") && (textLastName.Text != "") && (textAveScore.Text != ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET FirstName = N'{textFirstName.Text}', LastName = N'{textLastName.Text}', AverageScore = N'{textAveScore.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text != "") && (textLastName.Text != "") && (textAveScore.Text == ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET FirstName = N'{textFirstName.Text}', LastName = N'{textLastName.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text != "") && (textLastName.Text == "") && (textAveScore.Text != ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET FirstName = N'{textFirstName.Text}', AverageScore = N'{textAveScore.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text == "") && (textLastName.Text != "") && (textAveScore.Text != ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET LastName = N'{textLastName.Text}', AverageScore = N'{textAveScore.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text == "") && (textLastName.Text == "") && (textAveScore.Text != ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET AverageScore = N'{textAveScore.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text == "") && (textLastName.Text != "") && (textAveScore.Text == ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET LastName = N'{textLastName.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else if ((textFirstName.Text != "") && (textLastName.Text == "") && (textAveScore.Text == ""))
            {
                cmd.CommandText = $"UPDATE Student " +
                              $"SET FirstName = N'{textLastName.Text}' " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else
            {
                MessageBox.Show("Вы оставили пустыми поля", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                return;
            }
            
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (textId.Text != "")
            {
                cmd.CommandText = "DELETE FROM Student " +
                              $"WHERE StudentId = {textId.Text}";
            }
            else
            {
                MessageBox.Show("Вы оставили пустым поле - Id", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
            }
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
    }
}
