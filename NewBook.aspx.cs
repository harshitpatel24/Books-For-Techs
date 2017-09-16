using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using GlobalVariables;
public partial class _Default : System.Web.UI.Page
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
            reader.Close();
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
        SqlCommand cmd = new SqlCommand("select * from add_book", conn);
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
            Response.Redirect("DisplayNewBook.aspx?book_id=" + book_id);
        }
        else if (e.CommandName.Equals("getidforaddcart"))
        {
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=true");
            conn.Open();
            int book_id = Int32.Parse(e.CommandArgument.ToString());
            SqlCommand com1 = new SqlCommand("Select bookid,qty from addcart where bookid=@id and userid=@userid", conn);
            com1.Parameters.AddWithValue("@id", book_id);
            com1.Parameters.AddWithValue("@userid", Globals.getGlobal());
            using (SqlDataReader reader1 = com1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book is already added to the cart...the quantity is increased by 1')", true);
                    int qty = Convert.ToInt16(reader1.GetValue(1).ToString());
                    qty += 1;
                    SqlCommand cmd1 = new SqlCommand("update addcart Set qty=@qty where bookid=@bookid", conn);
                    cmd1.Parameters.AddWithValue("@qty", qty);
                    cmd1.Parameters.AddWithValue("@bookid", book_id);
                    cmd1.ExecuteNonQuery();
                    reader1.Close();
                }
                else
                {
                    
                    string sql = "insert into addcart values(@userid,@bookid,@mode,@qty)";
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.getGlobal();
                    com.Parameters.Add("@bookid", SqlDbType.Int).Value = Int32.Parse(e.CommandArgument.ToString());
                    com.Parameters.Add("@mode", SqlDbType.NVarChar, 50).Value = "n";
                    com.Parameters.Add("@qty", SqlDbType.Int).Value = 1;
                    com.ExecuteNonQuery();
                    conn.Close();
                    
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Item added')", true);
                }
            }


        }
    }
}

    
