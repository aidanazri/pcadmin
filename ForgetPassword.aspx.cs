using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPassword : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ETenderConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Reset error
            lblErrRegNo.Visible = false;
            lblErrEmail.Visible = false;
            dvResetSuccessfully.Visible = false;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvRegID.Attributes.Add("class", "form-group");
        dvCompanyEmail.Attributes.Add("class", "form-group");
        lblErrRegNo.Visible = false;
        lblErrEmail.Visible = false;
        dvResetSuccessfully.Visible = false;

        if (fldRegID.Text.Trim() == "")
        {
            chckErr = false;
            dvRegID.Attributes.Add("class", "form-group has-error");
        }

        if (IsValidEmail(fldCompanyEmail.Text.Trim()) == false)
        {
            chckErr = false;
            dvCompanyEmail.Attributes.Add("class", "form-group has-error");
        }

        if (chckErr == true)
        {          
            //Checking data exist or not
            qs = "";
            qs = qs + " SELECT          * ";
            qs = qs + " FROM            tblLogin ";
            qs = qs + " WHERE           StaffNo = '" + fldRegID.Text.Trim() + "' ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count != 0)
            {
                //Data exist
                row = null;
                row = dt.Rows[0];
                
                if (row["emailid"].ToString().Trim().ToUpper() == fldCompanyEmail.Text.Trim().ToUpper())
                {
                    //Generate password
                    String genPass = CreatePassword(8);

                    //Send email notification
                    try
                    {
                        //Email to admin
                        string bodyMail = null;
                        bodyMail = "";
                        bodyMail = bodyMail + "<table border='0' style='font-family: verdana,arial,sans-serif;font-size:12px;color:#333333;'>";
                        bodyMail = bodyMail + "<td colspan='3'><br/><br/><b>E-Tender System - New Password Reset</b><br/></td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'>Your login for E-Tender System as below :</td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'><b>Username :</b> " + row["StaffNo"].ToString().Trim() + "</td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'><b>Password :</b> " + genPass + "</td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'><a href='http://etendertest.uemedgenta.com/Default.aspx'>Proceed to E-Tender System</a>" + "<br /><br /></td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'></td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "<tr>";
                        bodyMail = bodyMail + "<td colspan='3'><i><br /><br /><br/>This is a system generated email, do not reply to this email</i></td>";
                        bodyMail = bodyMail + "</tr>";
                        bodyMail = bodyMail + "</table>";

                        MailMessage mailMessage = new MailMessage();
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Port = 25;
                        smtpClient.Host = "relay.uemedgenta.com";
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new System.Net.NetworkCredential("q43VD8L2dM@uemedgenta.com", "j6%Gk77%aM");
                        mailMessage.To.Add(row["emailid"].ToString());
                        mailMessage.From = new MailAddress("system@uemedgenta.uemnet.com");
                        mailMessage.Subject = "E-Tender System - New Password Reset";
                        mailMessage.Body = bodyMail;
                        mailMessage.IsBodyHtml = true;
                        smtpClient.Send(mailMessage);
                    }
                    catch
                    {
                        //do nothing
                    }

                    //Update database
                    qs = "";
                    qs = qs + " UPDATE  tblLogin ";
                    qs = qs + " SET ";
                    qs = qs + " Pwd = @ppassword ";
                    qs = qs + " WHERE    StaffNo = @pregistration_no ";
                    if (con.State == System.Data.ConnectionState.Closed)
                    { con.Open(); }
                    cmd = new SqlCommand(qs, con);
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@pregistration_no", fldRegID.Text);
                    cmd.Parameters.AddWithValue("@ppassword", genPass);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //View display
                    dvForgetpassword.Visible = false;
                    dvResetSuccessfully.Visible = true;
                }
                else
                {
                    //Reset display
                    lblErrEmail.Visible = true;
                    dvResetSuccessfully.Visible = false;
                    dvForgetpassword.Visible = true;
                }
                
            }
            else
            {
                lblErrRegNo.Visible = true;
            }
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    public bool IsValidEmail(string strIn)
    {
        Boolean invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names.
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }

        if (invalid)
            return false;

        // Return true if strIn is in valid e-mail format.
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private string DomainMapper(Match match)
    {
        Boolean invalid = false;

        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }

    public string CreatePassword(int length)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }

}