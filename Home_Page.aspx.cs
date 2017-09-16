using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using GlobalVariables;

public partial class Home_Page : System.Web.UI.Page
{
    static int user_id;
    protected void Page_Load(object sender, EventArgs e)
    {
     
        /*Label1.Text = Request.QueryString["email"];
        uemail = Request.QueryString["email"];

        if (uemail.Equals("Guest"))
        {

        }
        else
        {  */


        user_id = Globals.getGlobal();
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand command = new SqlCommand("Select email from signup where id=@id", conn);
        command.Parameters.AddWithValue("@id", user_id);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string email= String.Format("{0}", reader["email"]);
                Label1.Text = email;
                }
            }

            conn.Close();
        }
        
    
    
}