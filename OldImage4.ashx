<%@ WebHandler Language="C#" Class="OldImage4" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class OldImage4 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        SqlDataReader rdr = null;

        SqlConnection connection = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        string sql = "SELECT image4 FROM oldBook WHERE old_book_id =" + context.Request.QueryString["id"];
        SqlCommand cmd = new SqlCommand(sql, connection);
        connection.Open();
        rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            context.Response.ContentType = "image/jpg";
            context.Response.BinaryWrite((byte[])rdr["image4"]);
        }
        rdr.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}