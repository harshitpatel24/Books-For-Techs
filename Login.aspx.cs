using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using GlobalVariables;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net;

public partial class Login : System.Web.UI.Page
{
    //SqlConnection cn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
    string obj;
    bool flag1 = false;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string first = TextBox1.Text;
        string last = TextBox2.Text;
        string email = TextBox3.Text;
        string pass = TextBox4.Text;
        string pass2 = TextBox5.Text;

        if (first.Equals(null) || last.Equals(null) || email.Equals(null) || pass.Equals(null) || pass2.Equals(null) || first.Equals("") || last.Equals("") || email.Equals("") || pass.Equals("") || pass2.Equals(""))
        {
            Label8.Text = "* Please Fill All the Data";
        }
        else
        {
            if (pass.Equals(pass2))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql = "insert into signup values(@firstname,@lastname,@email,@password,@otp,@status)";
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.Add("@firstname", SqlDbType.NVarChar, 50).Value = first;
                com.Parameters.Add("@lastname", SqlDbType.NVarChar, 50).Value = last;
                com.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
                com.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = pass;
                com.Parameters.Add("@otp", SqlDbType.NVarChar, 50).Value = "";
                com.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = "N";
                com.ExecuteNonQuery();
                conn.Close();

                Label8.Text = "Sign Up Successfull ! Proceed for Login";
            }
            else
            {
                Label8.Text = "*Password must be same";
            }
        }
            
        }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox6.Text != null && TextBox7.Text != null)
        {
            string uemail = TextBox6.Text;
            string upass = TextBox7.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            SqlCommand command = new SqlCommand("Select id,password,otp,status from signup where email=@email", conn);
            command.Parameters.AddWithValue("@email", uemail);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                    while (reader.Read())
                    {
                        int uid = reader.GetInt32(0);
                        string dbpass = reader.GetString(1);
                        //string dbpass = String.Format("{0}", reader["password"]);
                        if (dbpass.Equals(upass))
                        {
                            if (reader.GetString(3).Equals("N"))
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
                                replacements.Add("{name}", TextBox6.Text);
                                replacements.Add("{otp}", otp);
                                //replacements.Add("{url}", "/ICON.jpg");
                                //string body = "<div style='color:red;background:yellow'>Hello {name}<br><br><br> You're from {country}.</div><br><br> <div style='color:red;background:red'>Nice To Meet You.</div>";
                                string body = "<style type='text/css'>td {padding: 15px;}.auto-style1 {color: #00E600;}</style><div style='width:80%;height:80%;margin:auto;padding:20px;color:#00cc00;border:10px solid #00cc00;'><img src=\"cid:filename\"><div style='margin:50px;background-color:#f7ffe6;padding:30px'><center><h2>Thank you for using our service!</h2></center><table><tr><td>Your Email:</td><td>{name}</td></tr><tr><td>Your OTP:</td><td>{otp}</td></tr></table></div><b style='float:right;'>&copy;Copyright BooksForTechs</b></div>";

                                MailMessage mm = md.CreateMailMessage(TextBox6.Text, replacements, body, new System.Web.UI.Control());
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
                                reader.Close();
                                SqlCommand cmd = new SqlCommand("update signup Set otp=@otp where id=@id", conn);
                                cmd.Parameters.AddWithValue("@otp", otp);
                                cmd.Parameters.AddWithValue("@id", uid);
                                cmd.ExecuteNonQuery();
                                Globals.setGlobal(uid);
                                Response.Redirect("Otp_Checker.aspx");
                                //Response.Redirect("Home_Page.aspx?email=" + uemail);
                            }
                            else
                            {
                                Globals.setGlobal(uid);
                                Response.Redirect("Home_Page.aspx");
                            }
                        }
                        else
                        {
                            Label9.Text = "Incorrect Password";
                        }
                    }
                }
           conn.Close();
        }
        else
        {
            Label9.Text = "Invalide User/Password";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home_Page.aspx?email=" + "Guest");
    }
}