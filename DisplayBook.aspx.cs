using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using GlobalVariables;
public partial class _Default : System.Web.UI.Page
{
    static int user_id;
    int book_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        user_id = Globals.getGlobal();
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand command = new SqlCommand("Select email from signup where id=@id", conn);
        command.Parameters.AddWithValue("@id", user_id);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string email = String.Format("{0}", reader["email"]);
                user_lbl.Text = email;
            }
        }
        conn.Close();

        book_id = Int32.Parse(Request.QueryString["book_id"]);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        
        DataTable ds = new DataTable();
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from oldBook where old_book_id = @bookid", conn);
        cmd.Parameters.AddWithValue("@bookid", book_id);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
        conn.Close();

        
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}