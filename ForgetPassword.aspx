<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>peti cadangan</title>
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
        <div id="dvForgetpassword" runat="server" class="panel panel-primary">
            <div class="panel-heading">Forget Password</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <div id="lblErrRegNo" runat="server" class="alert-sm alert-danger" role="alert">Error! Invalid Username has been entered.</div>
                        <div id="lblErrEmail" runat="server" class="alert-sm alert-danger" role="alert">Error! Invalid Email Address has been entered.</div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-md-offset-2">
                         <label class="control-label input-sm"><font color="Red">* Required.</font></label>
                    </div>
                </div>
                <div class="row">
                    <div id="dvRegID" runat="server" class="form-group">
                        <div class="col-md-3 col-md-offset-2">
                            <label class="control-label input-sm" for="fldRegID">Username <font color="Red">*</font></label>
                        </div>
                        <div class="col-md-5 col-md-offset-0">
                            <asp:TextBox ID="fldRegID" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div id="dvCompanyEmail" runat="server" class="form-group">
                        <div class="col-md-3 col-md-offset-2">
                            <label class="control-label input-sm" for="fldStatus">Email Address <font color="Red">*</font></label>
                        </div>
                        <div class="col-md-5 col-md-offset-0">
                            <asp:TextBox ID="fldCompanyEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <hr />

                <div align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success btn-sm" Width="150" OnClick="btnSubmit_Click" /> 
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" Width="150" OnClick="btnCancel_Click"/>
                </div>

            </div>
        </div>

        <div id="dvResetSuccessfully" runat="server" class="panel panel-primary">
            <div class="panel-body">
                <div class="row">
                    <br />
                    <div runat="server" class="form-group">
                        <center>

                        <b>Your password has been reset successfully!</b>
                        <br /><br />
                        Your new password has been sent to your email address.
                        <br /><br />
                        <a href="Default.aspx"><i>Click here to return to the login page</i></a>

                        </center>
                         
                    </div>
                </div>
            </div>
        </div>


    </div>
    </div>

    <script>
        $(function () {
            $('#<%=fldRegID.ClientID%>').keypress(function (e) {
                var txt = String.fromCharCode(e.which);
                console.log(txt + ' : ' + e.which);
                if (!txt.match(/[A-Za-z0-9]/)) {
                    return false;
                }
            });
        });
    </script>

    </form>
</body>
</html>


