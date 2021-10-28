<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<!-- Required meta tags -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="../Img/uem_logo.jpg"/>
    <title>WACH FEEDBACK SYSTEM (1st trigger jenkins)</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />

       <!-- Bootstrap CSS -->
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/all.min.css" rel="stylesheet" />
    <link href="Content/tempusdominus-bootstrap-4.css" rel="stylesheet" />

</head>
<body>  
    <form id="formLogin" runat="server">

    

    <div class="container">
        <div class="row">
            <img src="../Img/wach_banner.png" class="img-responsive"/>
        </div>

        <div style="padding-top:50px" runat="server" visible="false">
        

        <div class="row" runat="server" visible="false">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Login Authentication</div>
                          <table border="0">
		         <tr><td>
                 <img class="img-fluid" src="img/logo_kkm.png" alt="" width="60" height="70" style="max-width: 100%;height: auto;">
                 <td>
                 Hospital Wanita & Kanak-kanak Kuala Lumpur<br><i>Women & Childrens Hospital Kuala Lumpur</i>
                 </td>
                 </td>
                 </tr>
                 </table>
                    <div class="panel-body">
                        <div class="row">
                            <div id="errMain1" runat="server">
                                <asp:Label ID="errfldMain1" runat="server" CssClass="input-xs" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <label class="control-label input-xs" for="fldUserID">&nbsp;&nbsp;&nbsp;User ID</label><asp:Label ID="errDvfldUserID" runat="server" Text='Required !' CssClass="input-xs" ForeColor="Red"></asp:Label>
                        </div>

                        <div id="dvUserID" runat="server" class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class='input-group input-group-lg'>
                                        <span class="input-group-addon input-lg"><span class="glyphicon glyphicon-user"></span></span><asp:TextBox ID="fldUserID1" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="control-label input-xs" for="fldPass">&nbsp;&nbsp;&nbsp;Password</label><asp:Label ID="errDvfldPass1" runat="server" Text='Required !' CssClass="input-xs" ForeColor="Red"></asp:Label>
                        </div>

                        <div id="dvPass" runat="server" class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class='input-group input-group-lg'>
                                        <span class="input-group-addon input-lg"><span class="glyphicon glyphicon-lock"></span></span><asp:TextBox ID="fldPass1" runat="server" CssClass="form-control input-lg" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="style-primary" />
                                
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="form-control btn btn-primary btn-sm" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
            
        <div class="container" style="border-style:groove;text-align:center;height:auto;width:auto" >
            <div class="row" runat="server" visible="true">

                 <div class="col-md-4 col-md-offset-4">
                   <br />
                 <table border="0">
		         <tr><td>
                 <img class="img-responsive" src="img/logo_kkm.png" alt="" width="60" height="70" style="max-width: 100%;height: auto;">
                 <td>  Hospital Wanita & Kanak-kanak Kuala Lumpur<br/><i>Women & Children Hospital Kuala Lumpur</i>                 </td>
                     
                 </td>
                 </tr>
                 </table>
                    <br />
                    <label class="form-control-sm">Sign in with your organizational account</label>
                    <br />
                      <div class="row">
                            <div id="errMain" runat="server">
                                <asp:Label ID="errfldMain" runat="server" CssClass="input-xs" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    <div class="form-group">
                        <asp:TextBox ID="fldEmail" runat="server" CssClass="form-control form-control-sm" Placeholder="Please enter Email Address"></asp:TextBox>
                        <div class="invalid-feedback" ID="errDvfldEmail" runat="server">Valid Email Address is required.</div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="fldPass" runat="server" CssClass="form-control form-control-sm" TextMode="Password" Placeholder="Please enter Email Password"></asp:TextBox>
                        <div class="invalid-feedback" ID="errDvfldPass" runat="server">Valid Password is required.</div>
                    </div>
                    <asp:Label ID="lblTest" runat="server" CssClass=" form-control-sm text-danger" /> 
                    <br />
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" OnClientClick="return validateErr();" />
                    <br />
                    <label class="text-black-50 form-control-sm">Copyright &copy; 2019 UEM Edgenta Berhad</label>
                    <br />
                    <br />
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
  
    <script type="text/javascript">
    function validateErr() {
        var chckErr = true;

        document.getElementById('<%=fldEmail.ClientID%>').className = "form-control form-control-sm";
        document.getElementById('<%=fldPass.ClientID%>').className = "form-control form-control-sm";

        if (document.getElementById('<%=fldEmail.ClientID%>').value == "") {
            document.getElementById('<%=fldEmail.ClientID%>').className = "form-control form-control-sm is-invalid";
            chckErr = false;
        }
         if (document.getElementById('<%=fldPass.ClientID%>').value == "") {
            document.getElementById('<%=fldPass.ClientID%>').className = "form-control form-control-sm is-invalid";
            chckErr = false;
        }

        return chckErr; 
    }
</script>

</body>
</html>
