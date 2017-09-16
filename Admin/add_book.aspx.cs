using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
public partial class Admin_Default : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FileUpload img = (FileUpload)imgUpload;
        Byte[] imgByte = null;
        if (img.HasFile && img.PostedFile != null)
        {
        string filename = img.PostedFile.FileName;
                string filePath = Path.GetFileName(filename); 
                Stream fs = img.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                imgByte = br.ReadBytes((Int32)fs.Length);

            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "insert into add_book values (@bookname,@item,@author,@sem,@img,@price)" ;
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.Add("@bookname", SqlDbType.NVarChar,50).Value = txtname.Text; 
            com.Parameters.Add("@item",SqlDbType.NVarChar,50).Value =DropDownList1.SelectedItem.ToString() ;
            com.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = txtauthor.Text;
            //com.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = txtdesc.Text;
            com.Parameters.Add("@sem", SqlDbType.Int).Value = txtsem.Text;
            com.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgByte;
            //com.Parameters.Add("@qty", SqlDbType.Int).Value = TextBox1.Text;
            com.Parameters.Add("@price", SqlDbType.Money).Value =  Convert.ToDecimal (txtprice.Text);
            
            
            com.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("add_book.aspx");
        }
        else
        {
            txtname.Text = "111";
        }
        
    }

 
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

}