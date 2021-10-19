using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_Email_Masterpage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserRoles"] == "Vendor")
        //{
        //    vwVendor1.Visible = true;
        //    vwVendor2.Visible = true;
        //    vwVendor4.Visible = true;

        //    vwAdmin1.Visible = false;
        //    vwAdmin2.Visible = false;
        //    vwAdmin3.Visible = false;
        //    lblUser.Text = Session["UserRoles"].ToString();
        //}

        //else if (Session["UserRoles"] == "Administrator")
        //{
        //    vwVendor1.Visible = false;
        //    vwVendor2.Visible = false;
        //    vwVendor4.Visible = false;

        //    vwAdmin1.Visible = true;
        //    vwAdmin2.Visible = true;
        //    vwAdmin3.Visible = true;
        //    lblUser.Text = Session["UserRoles"].ToString();
        //}
        //else
        //{
        //    vwVendor1.Visible = false;
        //    vwVendor2.Visible = false;
        //    vwVendor4.Visible = false;

        //    vwAdmin1.Visible = false;
        //    vwAdmin2.Visible = false;
        //    vwAdmin3.Visible = false;
        //}
    }
}
