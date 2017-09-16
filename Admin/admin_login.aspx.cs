using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Admin_admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ID= WebConfigurationManager.AppSettings["LoginID"];
        string password = WebConfigurationManager.AppSettings["Password"];

        if (txtlogin.Text == ID && txtpass.Text == password)
        {
            Session["admin_panel"] = "admin panel";
            Response.Redirect("add_book.aspx");
        }
        else
        {
            Label1.Text = "Invalid Login ID/Password";
        }
    }
}