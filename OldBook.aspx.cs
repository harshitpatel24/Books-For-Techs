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
using GlobalVariables;
public partial class Old_Books : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
    string uemail;
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
    }
    protected void submit_data(object sender, EventArgs e)
    {
        FileUpload img = (FileUpload)image1;
        FileUpload img2 = (FileUpload)image2;
        FileUpload img3 = (FileUpload)image3;
        FileUpload img4 = (FileUpload)image4;
        Byte[] imgByte = null;
        Byte[] imgByte2 = null;
        Byte[] imgByte3 = null;
        Byte[] imgByte4 = null;

        if (img.HasFile && img.PostedFile != null && img2.HasFile && img2.PostedFile != null && img3.HasFile && img3.PostedFile != null && img4.HasFile && img4.PostedFile != null)
        {
            string filename = img.PostedFile.FileName;
            string filePath = Path.GetFileName(filename);
            Stream fs = img.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            imgByte = br.ReadBytes((Int32)fs.Length);

            string filename2 = img2.PostedFile.FileName;
            string filePath2 = Path.GetFileName(filename2);
            Stream fs2 = img2.PostedFile.InputStream;
            BinaryReader br2 = new BinaryReader(fs2);
            imgByte2 = br2.ReadBytes((Int32)fs2.Length);

            string filename3 = img2.PostedFile.FileName;
            string filePath3 = Path.GetFileName(filename3);
            Stream fs3 = img3.PostedFile.InputStream;
            BinaryReader br3 = new BinaryReader(fs3);
            imgByte3 = br3.ReadBytes((Int32)fs3.Length);

            string filename4 = img2.PostedFile.FileName;
            string filePath4 = Path.GetFileName(filename4);
            Stream fs4 = img4.PostedFile.InputStream;
            BinaryReader br4 = new BinaryReader(fs4);
            imgByte4 = br4.ReadBytes((Int32)fs4.Length);


            cn.Open();
            String query = "insert into oldBook values (@user,@name,@description,@img1,@img2,@img3,@img4,@price)";
            SqlCommand cmd = new SqlCommand(query,cn);
            cmd.Parameters.Add("@user", SqlDbType.Int).Value = user_id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox_name.Text;
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = TextBox_description.Text;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = TextBox_price.Text;
            cmd.Parameters.Add("@img1", SqlDbType.VarBinary).Value = imgByte;
            cmd.Parameters.Add("@img2", SqlDbType.VarBinary).Value = imgByte2;
            cmd.Parameters.Add("@img3", SqlDbType.VarBinary).Value = imgByte3;
            cmd.Parameters.Add("@img4", SqlDbType.VarBinary).Value = imgByte4;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
            Label9.Text = "SuccessFully Uploaded";

        }
        else {
            Label9.Text = "Wrong Input";
        }

    }
}