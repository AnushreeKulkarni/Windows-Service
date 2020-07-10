using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsServiceAssignment.BusinessLayer;
using WindowsServiceAssignment.DataAccessLayer;

namespace WebApplicationAssignment
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            DataAccess access = new DataAccess();
            int id = Convert.ToInt32(txtInput.Text);
            Employee emp;
            emp = access.GetEmployee(id);
            try
            {
                txtID.Text = emp.EmployeeID;
                txtName.Text = emp.EmployeeName;
                txtEmail.Text = emp.EmployeeEmail;
                ddlPlaces.Items.Add("Please Select");
                ddlPlaces.Items.Add(emp.EmployeePlace[0].Places);
                ddlPlaces.Items.Add(emp.EmployeePlace[1].Places);
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess access = new DataAccess();
            int id = Convert.ToInt32(txtInput.Text);
            Employee emp;
            emp = access.GetEmployee(id);
            try
            {
                if (ddlPlaces.SelectedValue.ToString() == emp.EmployeePlace[0].Places)
                {
                    ddlAddresses.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                    ddlAddresses.Items.Add(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses.Items.Add(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                }
                else
                {
                    ddlAddresses.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                    ddlAddresses.Items.Add(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses.Items.Add(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }


        }

        protected void ddlAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewEmployeeList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditRecord.aspx");
        }
    }
}