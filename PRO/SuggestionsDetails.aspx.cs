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
            getCurrentFeedbackRating();
			
		    //if (fldStatus.Text == "CLOSED")                
            if (ddlStatus.Text == "CLOSED")
            {
				ddlStatus.Enabled = false;
				fldRemarks.Enabled = false;
				btnUpdateDetails.Visible = false;
				btnClear.Visible = false;
			}
		else
            {
                ddlStatus.Enabled = true;
                fldRemarks.Enabled = true;
                btnUpdateDetails.Visible = true;
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
        ddlStatus.Items.Insert(2, new ListItem("N/A", "N/A"));
        ddlStatus.Items.Insert(3, new ListItem("CLOSED", "CLOSED"));


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
        //fldStatus.Text = row1["Status"].ToString();
        fldCategory.Text = row1["Feedback_BI"].ToString();
        fldSuggestions.Text = row1["wach_cadangan"].ToString();


        ddlStatus.SelectedValue = row1["status"].ToString(); ;
        fldRemarks.Text = row1["remarks"].ToString();

        fldDate.Text = Convert.ToDateTime(row1["date"].ToString()).ToString("dd/MM/yyyy"); 
        fldName.Text = row1["nama"].ToString();
        fldPhone.Text = row1["telefon"].ToString();
        fldEmail.Text = row1["email"].ToString();

        qs = " SELECT    rating ";
        qs = qs + " FROM      rating ";
        qs = qs + " WHERE     cadangan_ID = '" + Request.QueryString["cadanganID"] + "'";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        DataRow row2 = dt2.Rows[0];
        con.Close();

        fldRating.Text = row2["rating"].ToString();
    }

    protected void getCurrentFeedbackRating()
    {
        qs = " SELECT    * ";
        qs = qs + " FROM     sub_feedback ";
        qs = qs + " WHERE    cadangan_ID = '" + Request.QueryString["cadanganID"] + "'";


        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        DataRow row1 = dt1.Rows[0];
        DataColumn col1 = dt1.Columns[0];
        con.Close();

            if (dt1.Rows.Count > 0)
            //foreach (DataRow row in dt1.Rows)
            {
            //row1 = dt1.Rows[0];
            DataColumn col = dt1.Columns["q_id"];
            //for (int i = 0; i < dt1.Rows.Count; i++)
            foreach (DataRow row in dt1.Rows)
            {
                
                //row1 = dt1.Rows[0];

                if (row["q_id"].ToString().Trim() == "1")
                    cbAccident.Checked = true;
                else
                    cbAccident.Checked = false;

                if (row["q_id"].ToString().Trim() == "2")
                    cbQuality.Checked = true;
                else
                    cbQuality.Checked = false;

                if (row["q_id"].ToString().Trim() == "3")
                    cbService.Checked = true;
                else
                    cbService.Checked = false;

                if (row["q_id"].ToString().Trim() == "7")
                    cbWaste.Checked = true;
                else
                    cbWaste.Checked = false;

            }



        }
        //else 
        //{
        //    cbAccident.Checked = false;
        //    cbQuality.Checked = false;
        //    cbService.Checked = false;
        //    cbWaste.Checked = false;
        //}

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SuggestionsListing.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlStatus.Text = "NEW";
        fldRemarks.Text = "";
    }

        protected void btnUpdateSuggestions_Click(object sender, EventArgs e)
    {
        string query = "UpdateSuggestionsDetails";
        string cadangan_ID = Request.QueryString["cadanganID"];
        int cadanganID = Convert.ToInt32(cadangan_ID);

        string conString = ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(conString))
        {

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cadangan_ID", SqlDbType.NVarChar).Value = Request.QueryString["cadanganID"];
                cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = ddlStatus.SelectedItem.Text;
                cmd.Parameters.Add("@remarks", SqlDbType.NVarChar).Value = fldRemarks.Text;
                //        cmd.Parameters.Add("@contentID", SqlDbType.Int).Value = contentID;
                //        cmd.Parameters.Add("@menutitle", SqlDbType.NVarChar).Value = menutitle.Text;
                //        cmd.Parameters.Add("@webcontent", SqlDbType.NText).Value = webcontent.Text;
                //        cmd.Parameters.Add("@FileName1", SqlDbType.NVarChar).Value = urlStr;
                //        cmd.Parameters.Add("@FileName2", SqlDbType.NVarChar).Value = urlStr2;
                //        cmd.Parameters.Add("@FileName3", SqlDbType.NVarChar).Value = urlStr3;
                //        cmd.Parameters.Add("@publish", SqlDbType.Bit).Value = true;
                //        cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = ddlUnit.SelectedItem.Text;
                //        cmd.Parameters.Add("@modifyBy", SqlDbType.NVarChar).Value = Session["usr_name"].ToString();
                //        cmd.Parameters.Add("@modifyDate", SqlDbType.DateTime).Value = DateTime.Now;
                //        cmd.Parameters.Add("@remarks", SqlDbType.NVarChar).Value = fldRemarks.Text;


                //        //if (TsaasCategory.Visible == true)
                //        //    cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = ddlCategory.SelectedValue.ToString();
                //        //else
                //        //    cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            Response.Redirect("SuggestionsListing.aspx");

            //Response.Redirect("listed.aspx?menuID=" + Request.QueryString["menuID"].ToString() + "&location=frontpage.aspx");

        }

    }

}