using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Boolean checkvalidlogin = false;
    DataRow row = null;
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Reset error
//update new comment
            errDvfldUserID.Visible = false;
            errDvfldPass.Visible = false;
            errfldMain.Text = "";

            errDvfldEmail.Visible = false;
            errDvfldPass.Visible = false;

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        errDvfldUserID.Visible = false;
        errDvfldPass.Visible = false;
        errfldMain.Text = "";
        dvUserID.Attributes.Add("class", "row");
        dvPass.Attributes.Add("class", "row");

        errDvfldEmail.Visible = false;
        errDvfldPass.Visible = false;

        if (fldEmail.Text == "")
        {
            chckErr = false;
            errDvfldEmail.Visible = true;
            dvUserID.Attributes.Add("class", "row has-error");
        }

        if (fldPass.Text == "")
        {
            chckErr = false;
            errDvfldPass.Visible = true;
            dvPass.Attributes.Add("class", "row has-error");
        }

        if (chckErr == true)
        {
            //Check user id existing
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          user_access ";
            queryString = queryString + " WHERE         user_email = '" + fldEmail.Text.Trim() + "' ";
            queryString = queryString + " AND           user_role IS NOT NULL ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 0)
            {
                //Error no user id
                errfldMain.Text = "You do not have permission to access this system! Please contact System Administrator!";
            }
            else
            {
                row = null;
                row = dt.Rows[0];

                using (MD5 md5Hash = MD5.Create())
                {
                    string md5pass = GetMd5Hash(md5Hash, fldPass.Text);

                    //Check for password
                    if (row["user_pwd"].ToString() == fldPass.Text || row["user_pwd"].ToString() == md5pass)
                    {
                        Session["UserEmail"] = row["user_email"].ToString();
                        Session["UserName"] = row["user_name"].ToString();
                        
                        if (row["user_role"].ToString() == "Admin" || row["user_role"].ToString() == "PRO" || row["user_role"].ToString() == "HOS")
                        {
                            Response.Redirect("PRO/SuggestionsListing.aspx");
                        }

                        if (row["user_role"].ToString() == "PIC" || row["user_role"].ToString() == "PROHAWK" || row["user_role"].ToString() == "JOHN" || row["user_role"].ToString() == "FM")
                        {
                            Response.Redirect("PRO/SuggestionsListing.aspx");
				//Response.Redirect("PIC/SuggestionsListing.aspx");
                        }
                        else
                        {
                            Response.Redirect("../Default.aspx");
                        }
                        
                    }
                    else
                    {
                        //Error wrong password
                        errfldMain.Text = "Password invalid";
                    }
                }
            }
        }
    }

    public static string GetMd5Hash(MD5 md5Hash, string input)
    {
        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes and create a string. 
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data and format each one as a hexadecimal string. 
        int i = 0;
        for (i = 0; i <= data.Length - 1; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
    }
}