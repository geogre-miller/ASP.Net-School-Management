using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Subjects : System.Web.UI.Page
{
    string constring = "server=127.0.0.1; user=root; database=qlth; password=";
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection Sqlcon = new SqlConnection(constring))
        {
            string query = "select *from Product";
            Sqlcon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(query, Sqlcon);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}