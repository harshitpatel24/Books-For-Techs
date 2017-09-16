using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System;
using System.Data;
public partial class Admin_Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string pub = txtpubname.Text;
            string sql = "insert into add_publication values ('"+txtpubname.Text+"')";
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            lblresult.Text ="Publication Enter Successfully" + pub;
            Response.Redirect("add_publication.aspx");
        }
        catch
        {
            lblresult.Text = "Try Again";
        }
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }
} 
