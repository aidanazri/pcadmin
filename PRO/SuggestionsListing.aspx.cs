using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;

public static class Extensions
{
    /// <summary>
    /// Wraps matched strings in HTML span elements styled with a background-color
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
    /// <param name="cssClass">The Css color to apply</param>
    /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
    /// <returns>string</returns>
    public static string HighlightKeyWords(this string text, string keywords, string cssClass, bool fullMatch)
    {
        if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
            return text;
        var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (!fullMatch)
            return words.Select(word => word.Trim()).Aggregate(text,
                         (current, pattern) =>
                         Regex.Replace(current,
                                         pattern,
                                           string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                           cssClass,
                                           "$0"),
                                           RegexOptions.IgnoreCase));
        return words.Select(word => "\\b" + word.Trim() + "\\b")
                    .Aggregate(text, (current, pattern) =>
                              Regex.Replace(current,
                              pattern,
                                string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                cssClass,
                                "$0"),
                                RegexOptions.IgnoreCase));
    }
}

public partial class Listing : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
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

        DateTime now = DateTime.Now;

        lblUser.Text = Session["UserName"].ToString();
		//lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy");
        lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        btnClear.Visible = false;

        if (!Page.IsPostBack)
        {
            GridViewBind();
        }
    }

    public void GridViewBind()
    {
        String str;
                

        if (fldSearch.Text.Trim() != "")
        {
            //str = "SELECT           * "
            //      + "FROM           vwFeedback "
            //      + "WHERE          (Suggestion LIKE '%' + @search + '%') "
            //      + "ORDER BY       Date DESC ";

            str = "SELECT           * "
               + "FROM          feedback a, feedback_cat b "
               + "WHERE         a.feedback_id = b.feedback_id "
               + "AND           (wach_cadangan LIKE '%' + @search + '%') "
               //+ "AND           a.cadangan_id = c.cadangan_id "
               + "ORDER BY      Date desc, id DESC ";
        }
        else
        {
            str = "SELECT           * "
                  + "FROM          feedback a, feedback_cat b "
                  + "WHERE         a.feedback_id = b.feedback_id "
                  //+ "AND           a.cadangan_id = c.cadangan_id "
                  + "ORDER BY      Date desc, id DESC ";
        }

        SqlCommand xp = new SqlCommand(str, con);

        xp.Parameters.AddWithValue("@search", ((object)fldSearch.Text.Trim()) ?? DBNull.Value);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvSuggestionListing.DataSource = ds;
        gvSuggestionListing.DataBind();
        con.Close();

        for (int i = 0; i < gvSuggestionListing.Rows.Count; i++)
        {
            GridViewRow row = gvSuggestionListing.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                //row.Cells[6].Style.Add("background-color", "#FFECEC");
                /*row.Cells[7].Style.Add("background-color", "#FFECEC"); */
            }
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";
        
        GridViewBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;
        
        GridViewBind();
    }
    
    protected void gvSuggestionListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /* if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var Link = (HyperLink)e.Row.FindControl("hlDescription");

            Label Id = e.Row.FindControl("lblId") as Label;
            Label Phase = e.Row.FindControl("lblPhase") as Label;

            if (Phase.Text == "OPPORTUNITY RECORD")
            {
                Link.NavigateUrl = "OpportunityRecordDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "OPPORTUNITY GO / NO-GO")
            {
                Link.NavigateUrl = "OpportunityGoNoGoDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "PROPOSAL EVALUATION / SUBMISSION")
            {
                Link.NavigateUrl = "ProposalEvaluationDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "PROPOSAL CLOSE")
            {
                Link.NavigateUrl = "ProposalCloseDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "REGISTER NEW PROJECT")
            {
                Link.NavigateUrl = "RegisterProjectDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "PROJECT INITIATION")
            {
                Link.NavigateUrl = "ProjectInitiationDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "PROJECT EXECUTION")
            {
                Link.NavigateUrl = "ProjectMonthlyUpdateDetail.aspx?Id=" + Id.Text;
            }
            else if (Phase.Text == "PROJECT CLOSE")
            {
                Link.NavigateUrl = "ProjectClosingDetail.aspx?Id=" + Id.Text;
            }            
            else
            {
                //Response.Write(Phase.Text);
            }
            
        } */
    }

    protected void gvSuggestionListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSuggestionListing.PageIndex = e.NewPageIndex;
      
    }


    protected void lblfBID_DataBinding(object sender, EventArgs e)
    {
        Label lt = (Label)sender;
        //lt.Text = "<a href='tech_viewRequestForm.aspx?requestID=" + Eval("requestID") + "&page=s_pendingRequest'>" + Eval("requestID") + "</a>";
        lt.Text = "<a href='SuggestionsDetails.aspx?page=viewDetails&cadanganID=" + Eval("cadangan_ID") + "'>" + Eval("cadangan_ID") + "</a>";

    }

    protected void lblStatus_DataBinding(object sender, EventArgs e)
    {
        Label lt = (Label)sender;
        lt.Text = " " + Eval("status").ToString();
        lt.Width = 100;

        if (Eval("status").ToString().Trim() == "New" || Eval("status").ToString().Trim() == "NEW")
        {
            lt.BackColor = System.Drawing.ColorTranslator.FromHtml("#9cd0fd");
            lt.Text = "<a href='SuggestionsDetails.aspx?page=viewDetails&cadanganID=" + Eval("cadangan_ID") + "'>" + Eval("Status") + "</a>";
        }

        else if (Eval("status").ToString().Trim() == "INFO" || Eval("status").ToString().Trim() == "Info")
        {
            lt.BackColor = System.Drawing.ColorTranslator.FromHtml("#55c671");
            lt.Text = "<a href='SuggestionsDetails.aspx?page=viewDetails&cadanganID=" + Eval("cadangan_ID") + "'>" + Eval("Status") + "</a>";
        }

        else if (Eval("status").ToString().Trim() == "N/A")
        {
            lt.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff6c33");
            
            lt.Text = "<a style='color:#fffff' href='SuggestionsDetails.aspx?page=viewDetails&cadanganID=" + Eval("cadangan_ID") + "'>" + Eval("Status") + "</a>";
        }
        else
        {
            lt.BackColor = System.Drawing.ColorTranslator.FromHtml("#696250");
           // lt.Text = "<a style='color:#FFF' href='tech_viewRequestForm.aspx?page=pendingRequest&requestID=" + Eval("requestID") + "'>" + Eval("status") + "</a>";
            lt.Text = "<a style='color:#FFF' href='SuggestionsDetails.aspx?page=viewDetails&cadanganID=" + Eval("cadangan_ID") + "'>" + Eval("status") + "</a>";
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    
    private static DataTable GetData(string query)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["WACHConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}