<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SuggestionsDetails.aspx.cs" Inherits="admin_SuggestionsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

     <link rel="icon" type="image/png" href="../Img/uem_logo.jpg"/>
    <title>WACH FEEDBACK SYSTEM</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />

       <!-- Bootstrap CSS -->
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/all.min.css" rel="stylesheet" />
    <link href="Content/tempusdominus-bootstrap-4.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

        <div class="container">

              <div class="row justify-content-md-center">
            <div class="col col-lg-4">
                 <h4>&nbsp;<i class="glyphicon glyphicon-inbox"></i>&nbsp;&nbsp;Suggesstion Details</h4>
            </div>
           <div class="col col-lg-8">
                 <table border="0">
		         <tr><td>
                 <img class="img-fluid" src="../Img/logo_kkm.png" alt="" width="60" height="70" style="max-width: 100%;height: auto;">
                 <td>
                 Hospital Wanita & Kanak-kanak Kuala Lumpur<br><i>Women & Children Hospital Kuala Lumpur</i>
                 </td>
                 </td>
                 </tr>
                 </table>
           </div>

       </div>

        <div class="panel-body">

            <form>

                <div class="col-md-12 col-sm-12">

                <div class="form-group col-md-6 col-md-5"><label class="control-label input-xs" for="fldFbID">Feedback ID</label>
                     <asp:TextBox ID="fldFbID" runat="server" CssClass="form-control input-xs" Enabled="false"></asp:TextBox>
                        </div>
                
                
                <div class="form-group col-md-6 col-md-2"><label class="control-label input-xs" for="fldStatus">Status</label>
                       <asp:Textbox ID="fldStatus" runat="server" CssClass="form-control input-xs" Enabled="false" ></asp:Textbox>
                        </div>
                   
                    <div class="form-group col-md-6 col-md-5"><label class="control-label input-xs" for="fldStatus">Category</label>
                       <asp:TextBox ID="fldCategory" runat="server" CssClass="form-control input-xs"  Enabled="false" ></asp:TextBox>
                        </div>
                
            </div>

                   <div class="col-md-12 col-sm-12">

                <div class="form-group col-md-6 col-md-6"><label class="control-label input-xs" for="fldSuggestions">Suggestions</label>
                     <asp:TextBox ID="fldSuggestions" runat="server" CssClass="form-control input-xs" Enabled="false" TextMode="MultiLine" Rows="4" ></asp:TextBox>
                        </div>
                
             </div>

                <div class="col-md-12 col-sm-12">

                    <div class="form-group col-md-6 col-md-4"><label class="control-label input-xs" for="ddlStatus">Status</label>
                     <asp:Dropdownlist ID="ddlStatus" runat="server" CssClass="form-control input-xs" Enabled="false"></asp:Dropdownlist>
                          <br />

                       <label class="control-label input-xs" for="ddlWACHStatus">WACH Status</label>
                     <asp:Dropdownlist ID="ddlWACHStatus" runat="server" CssClass="form-control input-xs" ></asp:Dropdownlist>
                        </div>

                    <div class="form-group col-md-6 col-sm-10"><label class="control-label input-xs" for="fldRemarks">Remarks</label>
                     <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-xs" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                        </div>

                </div>
                  

                                  <div align="center">
            <asp:LinkButton runat="server" align="center" CssClass="btn btn-success btn-sm" Width="150" ID="btnUpdateWACH" OnClick="btnUpdateWACH_Click" ValidationGroup="ValidateClick" OnClientClick = "return confirm('Are you sure you want to update this suggestions?');"><span class="glyphicon glyphicon-floppy-disk"></span>  UPDATE</asp:LinkButton>
            <asp:LinkButton runat="server" align="center" CssClass="btn btn-danger btn-sm" Width="150" ID="btnClear" ValidationGroup="ValidateClick" Visible="false"><span class="glyphicon glyphicon-remove"></span>  CLEAR</asp:LinkButton>
                               </div>

            </form>

            </div>




        </div>
            
</asp:Content>

