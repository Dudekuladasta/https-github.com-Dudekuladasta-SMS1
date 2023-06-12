<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="BulkSMSFacility.LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="/resources/demos/style.css">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript">

        function preventBack() { window.history.forward(); }

        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Login Page</title>
    <%--<link href="CSS/main.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .style4
        {
            height: 29px;
        }
        
        .style6
        {
            height: 8px;
        }
        .style7
        {
            height: 23px;
        }
    </style>
    <%--<script type = "text/javascript" >
        function preventBack() { window.history.forward(); }

        setTimeout("preventBack()", 0);

        window.onunload = function () { null };

</script>--%>
</head>
<body style="height: 462px">
    <form id="form1" runat="server">
    <br />
    <div>
        <img src="../Images/Toyota1.jpg" style="height: 17%; width: 10%; margin-left: 1px;" /></div>
    <div class="Heading" style="background-color: rgb(140, 212, 239); height: 27px;"><h3 align="center">SMS Application</h3>
        <%--<label style="padding-left: 45%; color: Black; font-weight: 800; text-align: center;">
            SMS Application
        </label>--%>
    </div>
    <div style="height: 20px; text-align: right;">
    </div>
    <div style="height: 100px; width: 400px; margin-left: 19px;" align="center">
    </div>
    <div class="MidContainerSmall">
        <div style="align: Center;">
            <b><span style="padding-left: 41%; color: Black;">LOGIN </span></b>
        </div>
        <div>
            <table style="padding-left: 20px" align="center">
                <tr>
                    <td class="style2">
                        &nbsp;
                    </td>
                    <td class="style4">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <b>Username :</b>
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="Txt_uname" runat="server" CssClass="TextBox_150" Height="25px" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:RequiredFieldValidator ID="rfv_username" runat="server" ErrorMessage="Please Enter UserName"
                            ControlToValidate="Txt_uname" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                    </td>
                    <td class="style6">
                    </td>
                    <td class="style6">
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <b>Password :</b>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="Txt_pwd" runat="server" CssClass="TextBox_150" TextMode="Password"
                            Height="25px" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Please Enter password"
                            ControlToValidate="Txt_pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                    </td>
                    <td class="style6">
                    </td>
                    <td class="style6">
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;
                    </td>
                    <td class="style4" align="Right">
                        <asp:Button ID="btnlogin" runat="server" Text="Login" Height="30px" Width="80px"
                            BackColor="AliceBlue" OnClick="btnlogin_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style2" colspan="3">
                        <td>
                            &nbsp;
                        </td>
                </tr>
            </table>
            <div align="center">
                <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label></div>
        </div>
    </div>
    </form>
</body>
</html>
