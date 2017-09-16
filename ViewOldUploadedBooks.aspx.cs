using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using GlobalVariables;
public partial class ViewOldUploadedBooks : System.Web.UI.Page
{
    static int user_id;
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
        SqlCommand cmd = new SqlCommand("select * from oldBook", conn);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();

        conn.Close();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("getid"))
        {
            int book_id = Int32.Parse(e.CommandArgument.ToString());
            //Globals.setGlobal(seller_id);
            Response.Redirect("DisplayBook.aspx?book_id="+ book_id);
        }
        else if (e.CommandName.Equals("getidforaddtocart"))
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "insert into addcart values(@userid,@bookid,@mode)";
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.getGlobal();
            com.Parameters.Add("@bookid", SqlDbType.Int).Value = Int32.Parse(e.CommandArgument.ToString());
            com.Parameters.Add("@mode", SqlDbType.NVarChar, 50).Value = "o";
            com.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item added')", true);
        }
    }
}