using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserEmail"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            //qs = "";
            //qs = qs + " SELECT          registration_no, vendor_name, approve_status ";
            //qs = qs + " FROM            uemed_vendor_master ";
            //qs = qs + " WHERE           registration_no = '" + Session["UserID"].ToString() + "' ";
            //if (con.State == System.Data.ConnectionState.Closed)
            //{ con.Open(); }
            //cmd = new SqlCommand(qs, con);
            //cmd.CommandTimeout = 0;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();

            //if (dt.Rows.Count != 0)
            //{
            //    row = null;
            //    row = dt.Rows[0];
            //    fldRegistrationNo.Text = row["registration_no"].ToString();
            //    fldVendorName.Text = row["vendor_name"].ToString();
            //    fldStatus.Text = row["approve_status"].ToString();

            //    if (row["approve_status"].ToString() == "N")
            //    {
            //        tab0.Visible = true;
            //        tab1.Visible = false;
            //        tab2.Visible = false;
            //        tab4.Visible = false;
            //        tab5.Visible = false;
            //        tab7.Visible = false;
            //        //tab8.Visible = false;
            //        tab9.Visible = false;
            //    }
            //    else if (row["approve_status"].ToString() == "U")
            //    {
            //        tab0.Visible = true;
            //        tab1.Visible = true;
            //        tab2.Visible = false;
            //        tab4.Visible = false;
            //        tab5.Visible = false;
            //        tab7.Visible = false;
            //        //tab8.Visible = false;
            //        tab9.Visible = false;
            //    }
            //    else if (row["approve_status"].ToString() == "D")
            //    {
            //        tab0.Visible = true;
            //        tab1.Visible = true;
            //        tab2.Visible = true;
            //        tab4.Visible = true;
            //        tab5.Visible = true;
            //        tab7.Visible = true;
            //        //tab8.Visible = true;
            //        tab9.Visible = true;
            //    }
            //    else
            //    {
            //        Response.Redirect("VMS_Vendor_ViewDetail.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("VMS_Vendor_Main_Page.aspx");
            //}
        }
    }
}
