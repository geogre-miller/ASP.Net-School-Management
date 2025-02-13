﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.EOperations;
using MySql.Web;
using DAL.Entities;
using BLL.BOperations;
using MySql.Data.MySqlClient;
using System.Data;

public partial class AddEmployee : System.Web.UI.Page
{

    MySqlConnection con = new MySqlConnection("server=127.0.0.1; user=root; database=lms; password=");
    EEmployee emp = new EEmployee();
    EOperation empHandler = new EOperation();

    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateId();
    }

    protected void AddEmp_Click(object sender, EventArgs e)
    {
        try
        {
            emp.ID = Convert.ToInt32(EID.Text);
            emp.FNAME = EFname.Text;
            emp.LNAME = ELname.Text;
            emp.EMAIL = EEmail.Text;
            emp.PASSWORD = EPass.Text;
            emp.DOB = Convert.ToDateTime(EDOB.Text).Date;
            emp.TELEPHONE = ETel.Text;
            emp.MOBILENO = EMoblie.Text;
            emp.DOJ = Convert.ToDateTime(EDOJ.Text).Date;
            emp.STATUS = EStatus.Text;
            emp.GENDER = EGender.Text;
            emp.ROLE = int.Parse(empHandler.GetEmployeeRoleId(ERole.Text));
            emp.SALARY = decimal.Parse(Esalary.Text);

            if (empHandler.AddNewEmployee(emp) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('Employee Record Inserted!')", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }

        #region ClearInputs
        //Loop through all the control present on the web page/form        
        foreach (Control ctrl in form2.Controls)
        {
            //check for all the TextBox controls on the page and clear them
            if (ctrl.GetType() == typeof(TextBox))
            {
                ((TextBox)(ctrl)).Text = string.Empty;
            }
            //check for all the Label controls on the page and clear them
            else if (ctrl.GetType() == typeof(Label))
            {
                ((Label)(ctrl)).Text = string.Empty;
            }
            //check for all the DropDownList controls on the page and reset it to the very first item e.g. "-- Select One --"
            else if (ctrl.GetType() == typeof(DropDownList))
            {
                ((DropDownList)(ctrl)).SelectedIndex = 0;
            }
            //check for all the CheckBox controls on the page and unchecked the selection
            else if (ctrl.GetType() == typeof(CheckBox))
            {
                ((CheckBox)(ctrl)).Checked = false;
            }
            //check for all the CheckBoxList controls on the page and unchecked all the selections
            else if (ctrl.GetType() == typeof(CheckBoxList))
            {
                ((CheckBoxList)(ctrl)).ClearSelection();
            }
            //check for all the RadioButton controls on the page and unchecked the selection
            else if (ctrl.GetType() == typeof(RadioButton))
            {
                ((RadioButton)(ctrl)).Checked = false;
            }
            //check for all the RadioButtonList controls on the page and unchecked the selection
            else if (ctrl.GetType() == typeof(RadioButtonList))
            {
                ((RadioButtonList)(ctrl)).ClearSelection();
            }
        }
        #endregion

        GenerateId();
    }

    void GenerateId()
    {
        try
        {
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT IFNULL(MAX(E_ID),0)+1 FROM Employee", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EID.Text = dt.Rows[0][0].ToString();
            ERole.DataSource = empHandler.GetEmployeeRole();
            ERole.DataTextField = "Role_Name";
            ERole.DataBind();
            con.Close();
        }
        catch (MySqlException ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}