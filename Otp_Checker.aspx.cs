using GlobalVariables;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Otp_Checker : System.Web.UI.Page
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
                Label10.Text = email;
            }
        }

        conn.Close();

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";
        string characters = "";
        characters += alphabets + small_alphabets + numbers;
        int length = 5;
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        MailDefinition md = new MailDefinition();
        md.From = "harshitus99@gmail.com";
        md.IsBodyHtml = true;
        //md.Subject = "Test of MailDefinition";
        ListDictionary replacements = new ListDictionary();
        replacements.Add("{name}", Label10.Text);
        replacements.Add("{otp}", otp);
        //replacements.Add("{url}", "/ICON.jpg");
        //string body = "<div style='color:red;background:yellow'>Hello {name}<br><br><br> You're from {country}.</div><br><br> <div style='color:red;background:red'>Nice To Meet You.</div>";
        string body = "<style type='text/css'>td {padding: 15px;}.auto-style1 {color: #00E600;}</style><div style='width:80%;height:80%;margin:auto;padding:20px;color:#00cc00;border:10px solid #00cc00;'><img src=\"cid:filename\"><div style='margin:50px;background-color:#f7ffe6;padding:30px'><center><h2>Thank you for using our service!</h2></center><table><tr><td>Your Email:</td><td>{name}</td></tr><tr><td>Your OTP:</td><td>{otp}</td></tr></table></div><b style='float:right;'>&copy;Copyright BooksForTechs</b></div>";

        MailMessage mm = md.CreateMailMessage(Label10.Text, replacements, body, new System.Web.UI.Control());
        //MailMessage mm = new MailMessage("harshitus99@gmail.com", "harshitpatel24@gmail.com");
        mm.Subject = "OTP for Online Book Store";
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential();
        NetworkCred.UserName = "harshitus99@gmail.com";
        NetworkCred.Password = "hvp2411997";
        smtp.UseDefaultCredentials = true;
        smtp.Credentials = NetworkCred;
        smtp.Port = 587;
        smtp.Send(mm);
        Label8.Text = "New OTP sent to registered email";
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand cmd = new SqlCommand("update signup Set otp=@otp where email=@email", conn);
        cmd.Parameters.AddWithValue("@otp", otp);
        cmd.Parameters.AddWithValue("@email", Label10.Text);
        cmd.ExecuteNonQuery();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string otpfromuser = TextBox2.Text;
        SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        conn.Open();
        SqlCommand command = new SqlCommand("Select otp from signup where email=@email", conn);
        command.Parameters.AddWithValue("@email", Label10.Text);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string otpfromdb = reader.GetString(0);
                if (otpfromdb.Equals(otpfromuser))
                {
                    reader.Close();
                    SqlCommand cmd = new SqlCommand("update signup Set status=@status where email=@email", conn);
                    cmd.Parameters.AddWithValue("@status", "Y");
                    cmd.Parameters.AddWithValue("@email", Label10.Text);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Home_Page.aspx");
                }
                else
                {
                    Label8.Text = "wrong otp try again";
                }
            }
        }
    }
}