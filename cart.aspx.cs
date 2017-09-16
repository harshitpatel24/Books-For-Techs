using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using GlobalVariables;

public partial class cart : System.Web.UI.Page
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
        double price=0;
        DataTable ds = new DataTable();
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from oldBook where old_book_id in(select bookid from addcart where mode='o' and userid=@uid)",conn);
        cmd.Parameters.AddWithValue("@uid", user_id);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                float p = reader.GetSqlMoney(8).ToInt64();
                price += p;
            }
        }

        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
        conn.Close();

        DataTable ds1 = new DataTable();
        SqlConnection conn1 = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn1.Open();
        SqlCommand cmd1 = new SqlCommand("select * from add_book,addcart where add_book.book_id in(select bookid from addcart where mode='n' and userid=@uid) and addcart.bookid=add_book.book_id and userid=@userid", conn1);
        cmd1.Parameters.AddWithValue("@uid", user_id);
        cmd1.Parameters.AddWithValue("@userid", user_id);
        using (SqlDataReader reader = cmd1.ExecuteReader())
        {
            while (reader.Read())
            {
                double p = reader.GetSqlMoney(6).ToDouble();
                float qty = reader.GetInt32(11);
                price += p * qty;
            }
        }

        SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
        adp1.Fill(ds1);
        DataList2.DataSource = ds1;
        DataList2.DataBind();
        conn.Close();

        Label4.Text = price.ToString();
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("bookidforminus"))
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            int bid = Convert.ToInt16(commandArgs[0]);
            int uid = Convert.ToInt16(commandArgs[1]);
            int qty=0;
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            SqlCommand com1 = new SqlCommand("Select * from addcart where bookid=@id and userid=@userid", conn);
            com1.Parameters.AddWithValue("@id", bid);
            com1.Parameters.AddWithValue("@userid", uid);
            using (SqlDataReader reader1 = com1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    qty = Convert.ToInt16(reader1.GetValue(4));
                }
            }
            qty -= 1;
            if (qty == 0)
            {
                SqlCommand cmd = new SqlCommand("delete from addcart where bookid=@bid and userid=@uid", conn);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update addcart Set qty=@qty where bookid=@bid and userid=@uid", conn);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            

            //Globals.setGlobal(seller_id);
            Response.Redirect("cart.aspx");
        }
        else if (e.CommandName.Equals("bookidforplus"))
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            int bid = Convert.ToInt16(commandArgs[0]);
            int uid = Convert.ToInt16(commandArgs[1]);
            int qty = 0;
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            SqlCommand com1 = new SqlCommand("Select * from addcart where bookid=@id and userid=@userid", conn);
            com1.Parameters.AddWithValue("@id", bid);
            com1.Parameters.AddWithValue("@userid", uid);
            using (SqlDataReader reader1 = com1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    qty = Convert.ToInt16(reader1.GetValue(4));
                }
            }
            qty += 1;
            SqlCommand cmd = new SqlCommand("update addcart Set qty=@qty where bookid=@bid and userid=@uid", conn);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@bid", bid);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.ExecuteNonQuery();

            //Globals.setGlobal(seller_id);
            Response.Redirect("cart.aspx");
        }
    }
   
}