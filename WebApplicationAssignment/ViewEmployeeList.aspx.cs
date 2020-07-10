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
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dataGrid.DataSource = BindData();
                dataGrid.DataBind();               
            }
                        
        }
        public List<Employee> BindData()
        {
            DataAccess access = new DataAccess();
            List<Employee> emp;
            emp = access.GetDetailsFromDatabase();
            return emp;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}