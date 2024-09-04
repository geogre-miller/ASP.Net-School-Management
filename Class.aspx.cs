using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient; // Changed from System.Data.SqlClient to MySql.Data.MySqlClient

public partial class _Class : System.Web.UI.Page
{
    string constring = "server=127.0.0.1; user=root; database=lms; password=";
    protected void Page_Load(object sender, EventArgs e)
    {
        using (MySqlConnection Sqlcon = new MySqlConnection(constring)) // Changed to MySqlConnection
        {
            string query = "select * from Product"; // Adjusted spacing in query
            Sqlcon.Open();
            MySqlDataAdapter sqlData = new MySqlDataAdapter(query, Sqlcon); // Changed to MySqlDataAdapter
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}