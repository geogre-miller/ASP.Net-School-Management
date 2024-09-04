using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class EditAttendance : System.Web.UI.Page
{
    string constring = "server=127.0.0.1; user=root; database=lms; password=";
    protected void Page_Load(object sender, EventArgs e)
    {
        using (MySqlConnection Sqlcon = new MySqlConnection(constring))
        {   
            try
            {
                string query = "select * from `attendance`";
                Sqlcon.Open();
                MySqlDataAdapter sqlData = new MySqlDataAdapter(query, Sqlcon);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            } catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }

    protected void Gstd_Click(object sender, EventArgs e)
    {

    }

    protected void EditAtt_Click(object sender, EventArgs e)
    {

    }
}