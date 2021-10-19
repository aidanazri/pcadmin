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

public partial class PM_Masterpage : System.Web.UI.MasterPage
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        qs = "";
        qs = qs + " SELECT          * ";
        qs = qs + " FROM            user_access ";
        qs = qs + " WHERE           user_email = '" + Session["UserEmail"] + "' ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count == 0)
        {
            //Error no user id
        }
        else
        {
            row = null;
            row = dt.Rows[0];

            if (row["user_role"].ToString() == "Admin")
            {
                lblRole.Text = "Administrator";
                vwAdmin1.Visible = true;
                //vwAdmin2.Visible = true;
                //vwAdmin3.Visible = true;
      
            }

            else if (row["user_role"].ToString() == "PRO")
            {

                lblRole.Text = "Hospital PRO";
                vwAdmin1.Visible = true;
                //vwAdmin2.Visible = false;
                //vwAdmin3.Visible = false;

                
            }
            else if (row["user_role"].ToString() == "HOS")
            {
                lblRole.Text = "HOS";
                vwAdmin1.Visible = true;
                //vwAdmin2.Visible = false;
                //vwAdmin3.Visible = false;

            }
	    else if (row["user_role"].ToString() == "PROHAWK")
            {
                lblRole.Text = "PROHAWK";
                vwAdmin1.Visible = true;
            }
		else if (row["user_role"].ToString() == "JOHN")
            {
                lblRole.Text = "JOHN";
                vwAdmin1.Visible = true;
            }
		else if (row["user_role"].ToString() == "FM")
            {
                lblRole.Text = "FM";
                vwAdmin1.Visible = true;
            }
        }
    }
}
