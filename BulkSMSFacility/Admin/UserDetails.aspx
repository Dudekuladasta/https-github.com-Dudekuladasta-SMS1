<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="BulkSMSFacility.Admin.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 36px;
        }
        .style3
        {
            width: 130px;
        }
        .style6
        {
            height: 36px;
            width: 130px;
        }
        .style7
        {
            height: 36px;
            width: 225px;
        }
        .style8
        {
            height: 36px;
            text-align: center;
        }
        .style9
        {
            height: 14px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <%--            <div class="MidContainer">--%>
            <%--<div class="Heading" style="padding-left:1%;"><h4>User Registration</h4>
                    </div>--%>
            <div style="height: 12px; text-align: right;">
                <h5 style="padding-right: 2%">
                    <asp:Label ID="Lbl_Welcome" runat="server" Height="50px"></asp:Label></h5>
            </div>
            <%--                <div style="height: 490px; width: 963px; padding-left: 17%;" align="center">--%>
            <%--<fieldset class="FieldSet_90">--%>
            <%--<legend><b>User details</b></legend>--%>
            <table align="center">
                <tr>
                    <td class="style9" colspan="3">
                        <h3>
                            User Registration</h3>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lbl_Username" runat="server" Text="Username :"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txt_Username" runat="server" CssClass="TextBox_150" Height="25px"
                            Width="180px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:RequiredFieldValidator ID="rfv_ModelCode" runat="server" ControlToValidate="txt_Username"
                            ErrorMessage="Please enter Username" ForeColor="Red" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lbl_Password" runat="server" Text="Password :"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txt_Password" runat="server" Height="25px" Width="180px" CssClass="TextBox_150"></asp:TextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="rfv_ModelName" runat="server" ErrorMessage="Please enter Password"
                            ControlToValidate="txt_Password" ForeColor="Red" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        Status :
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="DDL" Width="70px">
                            <%--<asp:ListItem Selected="True" Value="0">Status</asp:ListItem>
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="Rfv_Status" runat="server" ControlToValidate="ddlStatus"
                            Width="200px" ErrorMessage="Please select Status" ForeColor="Red" InitialValue="0"
                            ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8" colspan="3" align="center" style="padding-right: 30%">
                        <asp:Button ID="btn_save" runat="server" Font-Names="Georgia" Height="30px" Text="Save"
                            ValidationGroup="BulkSMS" Width="80px" OnClick="btn_save_Click" />
                        <asp:Button ID="btn_update" runat="server" Font-Names="Georgia" Height="30px" Text="Update"
                            Width="80px" OnClick="btn_update_Click" ValidationGroup="BulkSMS" />
                        <%--  <asp:Button ID="btn_Delete" runat="server" Font-Names="Georgia" Height="30px" Text="Delete"
                            Width="99px" OnClick="btn_Delete_Click" />--%>
                        <%--<asp:Button ID="btn_Clear" runat="server" Font-Names="Georgia" Height="30px" Text="Clear"
                            Width="80px" OnClick="btn_Clear_Click" />--%>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" colspan="3">
                        <b>
                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label></b>
                    </td>
                </tr>
            </table>
            <table style="width: 606px;" align="center">
                <tr>
                    <td style="padding-left: 20%">
                        <asp:GridView ID="grd_UserDetails" runat="server" AllowPaging="True" PageSize="10"
                            CssClass="GridView" AutoGenerateColumns="false" Width="70%" Height="107px" OnPageIndexChanging="grd_UserDetails_PageIndexChanging1"
                            OnRowDeleting="grd_UserDetails_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="UserId" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserid" runat="server" Style="font-family: Calibri;" Text='<%#Eval("Userid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("username")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPassword" runat="server" Style="font-family: Calibri;" Text='<%#Eval("Passwrd")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Style="font-family: Calibri;" Text='<%#Eval("UserActive")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hpkUpdate" runat="server" Text="Edit" Style="font-family: Calibri;"
                                            ToolTip="Update" NavigateUrl='<%#"UserDetails.aspx?Userid="+Eval("Userid") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk_Delete" runat="server" CommandName="Delete" ToolTip="Delete"
                                            Text="Delete" NavigateUrl='<%#"UserDetails.aspx?Userid="+Eval("Userid") %>' OnClientClick="return confirm('Are you sure want to delete...?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--</fieldset>--%>
            <%--                </div>--%>
            <%--            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
