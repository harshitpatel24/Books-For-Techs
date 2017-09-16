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
using System.Text;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections.Specialized;
using System.Net.Mime;

public partial class DonateBooks : System.Web.UI.Page
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

    }
    protected void submit_data(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=HARSHIT\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        cn.Open();
        String query = "insert into donation_table1 values (@userid,@bookname,@bookdescription,@contact,@emailID)";
        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = Globals.getGlobal();
        cmd.Parameters.Add("@bookname", SqlDbType.NVarChar, 50).Value = TextBox_Bookname.Text;
        cmd.Parameters.Add("@bookdescription", SqlDbType.NVarChar, 500).Value = TextBox_Bookdescription.Text;
        cmd.Parameters.Add("@contact", SqlDbType.NVarChar).Value = TextBox_contact_no.Text;
        cmd.Parameters.Add("@emailID", SqlDbType.NVarChar).Value = TextBox_emailID.Text;
        cmd.Connection = cn;
        cmd.ExecuteNonQuery();
        cn.Close();

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] {
		                    new DataColumn("Donor Email"),
                            new DataColumn("Book Name"),
		                    new DataColumn("Book Description")});
        dt.Rows.Add(TextBox_emailID.Text, TextBox_Bookname.Text , TextBox_Bookdescription.Text);
        SendPDFEmail(dt);


        result.Text = "Thank you for donating...Download donation reciept from your mail";
        TextBox_Bookname.Text = "";
        TextBox_Bookdescription.Text="";
        TextBox_contact_no.Text = "";
        TextBox_emailID.Text = "";
    }

    private void SendPDFEmail(DataTable dt)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                string companyName = "Online Book Shop";
                int orderNo = 1111;
                string email = "Email";
                string desc = "Description";
                string name = "Book Name";
                StringBuilder sb = new StringBuilder();
                sb.Append("<br /><br />");
                sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Donation Sleep</b></td></tr>");
                sb.Append("<tr><td colspan = '2'></td></tr>");
                sb.Append("<tr><td><b>Order No:</b>");
                sb.Append(orderNo);
                sb.Append("</td><td><b>Date: </b>");
                sb.Append(DateTime.Now);
                sb.Append(" </td></tr>");
                sb.Append("<tr><td colspan = '2'><b>Company Name :</b> ");
                sb.Append(companyName);
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("<br />");
                sb.Append("<table border = '1'>");
                sb.Append("<tr>");
                //foreach (DataColumn column in dt.Columns)
                //{
                    sb.Append("<td style = 'background-color: #D20B0C;color:black'>");
                    sb.Append(email);
                    sb.Append("</td>");
                    sb.Append("<td style = 'background-color: #D20B0C;color:black'>");
                    sb.Append(name);
                    sb.Append("</td>");
                    sb.Append("<td style = 'background-color: #D20B0C;color:black'>");
                    sb.Append(desc);
                    sb.Append("</td>");
                //}
                sb.Append("</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(row[column]);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("<br/><br/>");
                sb.Append("<b> Thank You For Your Valuable Donation");
                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                    
                    MailDefinition md = new MailDefinition();
                    md.From = "harshitus99@gmail.com";
                    md.IsBodyHtml = true;
                    //md.Subject = "Test of MailDefinition";
                    ListDictionary replacements = new ListDictionary();
                    replacements.Add("{name}", TextBox_emailID.Text);
                    replacements.Add("{book}",TextBox_Bookname.Text);
                    //replacements.Add("{url}", "/ICON.jpg");
                    //string body = "<div style='color:red;background:yellow'>Hello {name}<br><br><br> You're from {country}.</div><br><br> <div style='color:red;background:red'>Nice To Meet You.</div>";
                    string body = "<style type='text/css'>td {padding: 15px;}.auto-style1 {color: #00E600;}</style><div style='width:80%;height:80%;margin:auto;padding:20px;color:#00cc00;border:10px solid #00cc00;'><img src=\"cid:filename\"><div style='margin:50px;background-color:#f7ffe6;padding:30px'><center><h2>Thank you for the donation!</h2></center><table><tr><td>Donor Name:</td><td>{name}</td></tr><tr><td>Donation ID:</td><td>4355</td></tr><tr><td>Book Donated:</td><td>{book}</td></tr></table></div><b style='float:right;'>&copy;Copyright BooksForTechs</b></div>";
                    
                    MailMessage mm = md.CreateMailMessage(TextBox_emailID.Text, replacements, body, new System.Web.UI.Control());
                    //MailMessage mm = new MailMessage("harshitus99@gmail.com", "harshitpatel24@gmail.com");
                    mm.Subject = "Donation Sleep";
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "donationPDF.pdf"));
                    mm.IsBodyHtml = true;
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
                    


                    /*MailMessage mm = new MailMessage();
                    mm.From=new MailAddress("harshitus99@gmail.com");
                    mm.To.Add(new MailAddress(TextBox_emailID.Text));
                    mm.Subject = "Donation Reciept";
                    mm.Body = "Thank you for donating book...we appriciate your work.....please find an attachment which contains donation sleep";
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "donationPDF.pdf"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = "harshitus99@gmail.com";
                    NetworkCred.Password = "hvp2411997";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);*/
                }
            }
        }
    }

}