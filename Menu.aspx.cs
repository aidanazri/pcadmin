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

public partial class Menu : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ETenderConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Default.aspx", true);
        }
    }

    protected void btnTP_Click(object sender, EventArgs e)
    {        
        //Select from db
        qs = "";
        qs = qs + " SELECT          * ";
        qs = qs + " FROM            tblLogin ";
        qs = qs + " WHERE           StaffNo = '" + Session["UserID"] + "' ";
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
            //No record           
        }
        else
        {
            row = null;
            row = dt.Rows[0];
        
            Session["UserID"] = row["StaffNo"].ToString();
            Session["UserName"] = row["StaffName"].ToString();
            Session["UserRoles"] = row["Role"].ToString();
			Session["email"] = row ["emailid"].ToString();

            if (row["Role"].ToString() == "Admin")
            { Response.Redirect("PTP/Tender_Listing_ALL.aspx"); }
                    else if (row["Role"].ToString() == "Finance")
            { Response.Redirect("PTP/Tender_Listing_Fin.aspx"); }
                    else if (row["Role"].ToString() == "HBU")
            { Response.Redirect("PTP/Tender_Listing_HBU.aspx"); }
                    else
            {
                if (row["Role"].ToString() == "PIC" && row["Division"].ToString() == "AL")
                { Response.Redirect("PTP/Tender_Listing_PIC.aspx"); }
                else
                { Response.Redirect("PTP/Tender_Listing.aspx"); }
            }
        
        }
    }

    
    protected void btnCS_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CS/Tender_CS_Upload_Excel.aspx");
    }
	
	protected void signout_Click(object sender, EventArgs e)
	{
		qs = "";
        qs = qs + " SELECT          * ";
        qs = qs + " FROM            tblLogin ";
        qs = qs + " WHERE           StaffNo = '" + Session["UserID"] + "' ";
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
            //No record           
        }
        else
        {
            row = null;
            row = dt.Rows[0];
        
           Session["UserID"] = row ["StaffNo"].ToString();
		   Response.Redirect("http://testing.opusbhd.com/appsEdgenta/Dashboard.aspx?&Key=" + Session["UserID"].ToString());
	}
	}
	
	
}