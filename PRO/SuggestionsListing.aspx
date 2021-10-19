<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SuggestionsListing.aspx.cs" Inherits="Listing" %>

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
                 <h4>&nbsp;<i class="glyphicon glyphicon-inbox"></i>&nbsp;&nbsp;Suggestion Details</h4>
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


            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm" Visible="false">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

             <asp:Table ID="tblSearch" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell Height="40" Wrap="false">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox> 
                            &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnSearch_Click" ImageAlign="Middle"/>                                
                            &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnClear_Click" ImageAlign="Middle" Visible="false"/>
                            
                        </div>
                    </asp:TableCell>
                    
                </asp:TableRow>    
            </asp:Table>
    
        <hr />


    <asp:GridView ID="gvSuggestionListing" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="ID" ShowHeaderWhenEmpty="True" PageSize="15" Width="100%" OnRowDataBound="gvSuggestionListing_RowDataBound" OnPageIndexChanging="gvSuggestionListing_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="2%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="2%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField> 

                 <asp:TemplateField HeaderText="Feedback ID" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFbID" runat="server" Text='<%# Eval("cadangan_ID")%>' CssClass="input-xs" OnDataBinding="lblfBID_DataBinding"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date", "{0:dd/MM/yyyy}").ToString() %>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="7%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="7%">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Feedback_BI").ToString() != "" ? Eval("Feedback_BI").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Suggestion" ItemStyle-Width="10%" ItemStyle-CssClass="form-control-sm text-sm-center" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" HeaderStyle-Wrap="false" ItemStyle-Wrap="true">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("wach_cadangan").ToString() != "" ? Eval("wach_cadangan").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
        

                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                     <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-xs" Text='<%# Eval("status")%>' ></asp:TextBox>
                    </EditItemTemplate>
                     <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() %>' OnDataBinding="lblStatus_DataBinding" CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

               <%--   <asp:TemplateField HeaderText="Status by WACH" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() %>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                      
            </Columns>
               
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
                 <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
            </asp:GridView>


    
  </div>
</asp:Content>
    


