using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsServiceAssignment.DataAccessLayer;
using WindowsServiceAssignment.BusinessLayer;
using System.Web.WebSockets;
using System.Linq.Expressions;
using System.Threading;

namespace WebApplicationAssignment
{
    public partial class EditRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            DataAccess access = new DataAccess();
            int id = Convert.ToInt32(txtInput.Text);
            Employee emp;
            emp = access.GetEmployee(id);
            try
            {
                lblName.Visible = true;
                txtName.Visible = true;
                lblEmail.Visible = true;
                txtEmail.Visible = true;
                lblPlaces1.Visible = true;
                ddlPlaces1.Visible = true;
                lblAddress1.Visible = true;
                ddlAddresses1.Visible = true;
                lblAddress2.Visible = true;
                ddlAddresses2.Visible = true;
                lblPlaces2.Visible = true;
                ddlPlaces2.Visible = true;
                lblAddress3.Visible = true;
                ddlAddresses3.Visible = true;
                lblAddress4.Visible = true;
                ddlAddresses4.Visible = true;
                btnSave.Visible = true;
                ddlPlaces1.Items.Add("Please Select");
                ddlPlaces1.Items.Add(emp.EmployeePlace[0].Places);
                ddlPlaces1.Items.Add(emp.EmployeePlace[1].Places);
                ddlPlaces2.Items.Add("Please Select");
                ddlPlaces2.Items.Add(emp.EmployeePlace[0].Places);
                ddlPlaces2.Items.Add(emp.EmployeePlace[1].Places);
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtInput.Text);
                string Name = txtName.Text;
                string Email = txtEmail.Text;
                string PlaceOne = ddlPlaces1.SelectedValue;
                string AddressOne = ddlAddresses1.SelectedValue;
                string AddressTwo = ddlAddresses2.SelectedValue;
                string PlaceTwo = ddlPlaces2.SelectedValue;
                string AddressThree = ddlAddresses3.SelectedValue;
                string AddressFour = ddlAddresses4.SelectedValue;
                DataAccess access = new DataAccess();
                access.UpdateEmployee(id, Name, Email, PlaceOne, AddressOne, AddressTwo, PlaceTwo, AddressThree, AddressFour);
                lblStatus.Visible = true;
            }
            catch(Exception ex)
            {
                Response.Redirect(ex.Message);
            }
                 //Thread.Sleep(5000);       
                //Response.Redirect("MainPage.aspx");
        }

        protected void ddlPlaces1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess access = new DataAccess();
            int id = Convert.ToInt32(txtInput.Text);
            Employee emp;
            emp = access.GetEmployee(id);
            try
            {
                if (ddlPlaces1.SelectedValue.ToString() == emp.EmployeePlace[0].Places)
                {
                    ddlAddresses1.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses1.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                    ddlAddresses2.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses2.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);

                    ddlAddresses1.Items.Add(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses1.Items.Add(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                    ddlAddresses2.Items.Add(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses2.Items.Add(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                }
                else if(ddlPlaces1.SelectedValue.ToString() == emp.EmployeePlace[1].Places)
                {

                    ddlAddresses1.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses1.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                    ddlAddresses2.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses2.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);

                    ddlAddresses1.Items.Add(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses1.Items.Add(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                    ddlAddresses2.Items.Add(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses2.Items.Add(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void ddlPlaces2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess access = new DataAccess();
            int id = Convert.ToInt32(txtInput.Text);
            Employee emp;
            emp = access.GetEmployee(id);
            try
            {
                if (ddlPlaces2.SelectedValue.ToString() == emp.EmployeePlace[0].Places)
                {
                    ddlAddresses3.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses3.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                    ddlAddresses4.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses4.Items.Remove(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);

                    ddlAddresses3.Items.Add(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses3.Items.Add(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                    ddlAddresses4.Items.Add(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses4.Items.Add(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                }
                else if (ddlPlaces2.SelectedValue.ToString() == emp.EmployeePlace[1].Places)
                {

                    ddlAddresses3.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses3.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);
                    ddlAddresses4.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[0].Pincodes);
                    ddlAddresses4.Items.Remove(emp.EmployeePlace[0].EmployeeAddress[1].Pincodes);

                    ddlAddresses3.Items.Add(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses3.Items.Add(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);
                    ddlAddresses4.Items.Add(emp.EmployeePlace[1].EmployeeAddress[0].Pincodes);
                    ddlAddresses4.Items.Add(emp.EmployeePlace[1].EmployeeAddress[1].Pincodes);

                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
    }
    }
