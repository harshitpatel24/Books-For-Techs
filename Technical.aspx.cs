using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from add_book where pub_name like 'Technical'", conn);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        DataList1.DataSource = ds.Tables[0];
        DataList1.DataBind();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}