<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-Tender (Test)</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>  
    <form id="formLogin" runat="server">

    <div class="container">
        <div class="row">
            <img src="Img/etender.png" class="img-responsive"/>
        </div>
    </div>

    <br />

    <div class="container">
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">Welcome to E-Tender <asp:LinkButton id="signout" runat="server" text="Signout" OnClick="signout_Click" /></div>
            <div class="panel-body">
                al,dd
                <div class="row">
                    <div class="col-xs-12 col-xs-1">
                    </div>
                    <div class="col-xs-12 col-xs-10">
                        <asp:Table ID="Table3" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Height="50">
                                    </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table ID="Table4" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center">
                                    <asp:ImageButton ID="btnTP" runat="server" ImageUrl="Img/Icon/img_TP.jpg" AlternateText="Tender Participation" ImageAlign="Bottom" OnClick="btnTP_Click" BorderStyle="Solid"/>
                            <br /><asp:Label ID="lblTP" runat="server" class="control-label input-xs" ForeColor="Red" Text="TENDER PARTICIPATION" Font-Bold="true"></asp:Label>    
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Img/Icon/img_TO.jpg" AlternateText="Tender Outsourcing" ImageAlign="Bottom" Enabled="false" BorderStyle="Solid"/>
                            <br /><asp:Label ID="Label1" runat="server" class="control-label input-xs" ForeColor="#666666" Text="TENDER OUTSOURCING"></asp:Label>  
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center">
                                    <asp:ImageButton ID="btnCS" runat="server" ImageUrl="Img/Icon/img_CS.jpg" AlternateText="Costing Sheet" ImageAlign="Bottom" OnClick="btnCS_Click" Enabled="true" BorderStyle="Solid"/>
                            <br /><asp:Label ID="Label2" runat="server" class="control-label input-xs" ForeColor="Red" Text="COSTING SHEET" Font-Bold="true"></asp:Label>  
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div> 
                    <div class="col-xs-12 col-xs-1">
                    </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-xs-3">
                    </div>
                    <div class="col-xs-12 col-xs-6">
                        <asp:Table ID="Table1" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center">
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="Img/Icon/img_VR.jpg" AlternateText="Vendor Registration" ImageAlign="Bottom" Enabled="false" BorderStyle="Solid"/>
                        <br /><asp:Label ID="Label3" runat="server" class="control-label input-xs" ForeColor="#666666" Text="VENDOR REGISTRATION"></asp:Label>   
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Center">
                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="Img/Icon/img_CM.jpg" AlternateText="Contract Management" ImageAlign="Bottom" Enabled="false" BorderStyle="Solid"/>
                        <br /><asp:Label ID="Label4" runat="server" class="control-label input-xs" ForeColor="#666666" Text="CONTRACT MANAGEMENT"></asp:Label>    
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table ID="Table2" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Height="50">
                                    </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div> 
                    <div class="col-xs-12 col-xs-3">
                    </div>
                    </div>
                </div>
                
                
            </div>
        </div>               


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="Scripts/jquery-2.2.3.min.js" />
        <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
    </Scripts>
    </asp:ScriptManager>

    </form>
  
</body>
</html>
