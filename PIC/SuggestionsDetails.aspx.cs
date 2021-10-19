using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.IO;

public partial class admin_SuggestionsDetails : System.Web.UI.Page
{
    String qs = "";

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindStatus();
            getCurrentFeedbackDetail();
			
			if (fldStatus.Text == "CLOSED")
			{
				ddlWACHStatus.Enabled = false;
				btnUpdateWACH.Visible = false;
				btnClear.Visible = false;
			}
			else
            {
                ddlWACHStatus.Enabled = true;
                btnUpdateWACH.Visible = true;
                btnClear.Visible = true;
            }
        }

    }


    public DataSet GetData(string queryString)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString;
        DataSet ds = new DataSet();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }

    protected void bindStatus()
    {
        // Bind data to the dropdownlist control.
        ddlStatus.Items.Insert(0, new ListItem("NEW", "NEW"));
        ddlStatus.Items.Insert(1, new ListItem("INFO", "INFO"));
        ddlStatus.Items.Insert(2, new ListItem("REVIEWED", "REVIEWED"));
        ddlStatus.Items.Insert(3, new ListItem("CLOSED", "CLOSED"));

        ddlWACHStatus.Items.Insert(0, new ListItem("-", "-"));
        ddlWACHStatus.Items.Insert(1, new ListItem("N/A", "N/A"));
      
    }

    protected void getCurrentFeedbackDetail()
    {
        qs = " SELECT    * ";
        qs = qs + " FROM      feedback a, feedback_cat b ";
        qs = qs + " WHERE     a.feedback_id = b.feedback_id";
        qs = qs + " AND       a.cadangan_ID = '" + Request.QueryString["cadanganID"] + "'";



        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        DataRow row1 = dt1.Rows[0];
        con.Close();

        fldFbID.Text = row1["cadangan_ID"].ToString();
        fldStatus.Text = row1["Status"].ToString();
        fldCategory.Text = row1["Feedback_BI"].ToString();
        fldSuggestions.Text = row1["wach_cadangan"].ToString();

        ddlStatus.SelectedValue = row1["status"].ToString(); ;
        fldRemarks.Text = row1["remarks"].ToString();
        //fldRequestID1.Text = row1["requestID"].ToString();
        //fldStatus1.Text = row1["status"].ToString();
        //// fldRequestorStaffNo.Text = row1["requestorStaffNo"].ToString();
        //fldRequestorStaffName.Text = row1["requestorStaffname"].ToString();
        //fldDesignation.Text = row1["requestorDesignation"].ToString();
        //ddlLocation.Text = row1["location"].ToString().Trim();
        //fldLocationName.Text = row1["department"].ToString().Trim();
        //fldEmail.Text = row1["email"].ToString().Trim();
        //ddlCategory.Text = row1["requestCategory"].ToString();
        //fldAsset.Text = row1["assetNo"].ToString();
        //fldAssetName.Text = row1["description"].ToString();
        //fldReqDateTime1.Text = Convert.ToDateTime(row1["requestDatetime"].ToString()).ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(row1["requestDatetime"].ToString()).ToString("hh:mm");
        //fldReqDetails.Text = row1["requestDetails"].ToString().Trim();
        ////fldMobile.Text = row1["mobileNo"].ToString().Trim();
        //fldContactNo.Text = row1["mobileNo"].ToString().Trim();


        // fldDepartment1.Text = row1["department"].ToString().Trim();


    }


    protected void btnUpdateWACH_Click(object sender, EventArgs e)
    {

        qs = "";
        qs = qs + "UPDATE feedback ";
        qs = qs + "SET ";
        qs = qs + "WACHstatus = @pWACHStatus ";
        qs = qs + "WHERE cadangan_id = @pcadangan_id ";


        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pcadangan_id", Request.QueryString["cadanganID"]);
        cmd.Parameters.AddWithValue("@pWACHStatus", ddlWACHStatus.SelectedItem.Text);

        cmd.ExecuteNonQuery();
        con.Close();

        //Redirect to page
        Response.Redirect("SuggestionsListing.aspx");
    }

}

