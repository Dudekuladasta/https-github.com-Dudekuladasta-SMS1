<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ModelRegistration.aspx.cs" Inherits="BulkSMSFacility.Admin.ModelRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <style type="text/css">
        .style4
        {
            text-align: center;
        }
        .style5
        {
            width: 170px;
            text-align: right;
            height: 33px;
        }
        .style6
        {
            font-family: "Agency FB";
            text-align: center;
            height: 33px;
        }
        .style7
        {
            text-align: left;
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <%--            <div class="MidContainer">--%>
            <%--<div class="Heading"><h4>Model Registration</h4>
                    </div>--%>
            <div style="height: 12px; text-align: right;">
                <h5 style="padding-right: 2%">
                    <asp:Label ID="Lbl_Welcome" runat="server" Height="50px"></asp:Label></h5>
            </div>
            <%--<div style="height: 490px; width: 963px; margin-left: 19px; padding-left: 15%;" align="center">--%>
            <%--<fieldset class="FieldSet_90">--%>
            <%--<legend><b>Vehicle model master details</b></legend>--%>
            <table align="center">
                <tr align="center">
                    <td colspan="3">
                        <h3>
                            Model Registration</h3>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lbl_ModelCode" runat="server" Text="Model code "></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txt_ModelCode" runat="server" Height="25px" Width="180px" Style="text-transform: uppercase"
                            CssClass="TextBox_150" MaxLength="8"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:RequiredFieldValidator ID="rfv_ModelCode" runat="server" ErrorMessage="Please enter Model code"
                            ForeColor="Red" ValidationGroup="BulkSMS" ControlToValidate="txt_ModelCode"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lbl_ModelName" runat="server" Text="Model name "></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txt_ModelName" runat="server" Height="25px" Width="180px" Style="text-transform: uppercase"
                            CssClass="TextBox_150" MaxLength="15"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <asp:RequiredFieldValidator ID="rfv_ModelName" runat="server" ErrorMessage="Please enter Model name"
                            ControlToValidate="txt_ModelName" ForeColor="Red" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="style4">
                        <asp:Button ID="btn_submit" runat="server" Height="30px" Width="80px" BackColor="AliceBlue"
                            OnClick="btn_submit_Click" Text="Save" ValidationGroup="BulkSMS" />
                        <asp:Button ID="btn_update" runat="server" Text="Update" Height="30px" Width="80px"
                            BackColor="AliceBlue" OnClick="btn_update_Click" ValidationGroup="BulkSMS" />
                        <%--<asp:Button ID="btn_Delete" runat="server" Text="Delete" Visible="false" Height="30px" Width="80px"
                            BackColor="AliceBlue" OnClick="btn_Delete_Click" />--%>
                        <%--<asp:Button ID="btn_Clear" runat="server" Text="Clear" Height="30px" Width="80px"
                            BackColor="AliceBlue" OnClick="btn_Clear_Click" />--%>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" colspan="3">
                        <b>
                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label></b>
                    </td>
                </tr>
            </table>
            <div align="center">
                <table>
                    <asp:GridView ID="grd_ModelDetails" runat="server" AllowPaging="True" PageSize="10"
                        OnPageIndexChanging="grd_ModelDetails_PageIndexChanging1" CssClass="GridView"
                        AutoGenerateColumns="false" Width="50%" Height="57px" OnRowDeleting="grd_ModelDetails_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <asp:Label ID="lblSno" runat="server" Style="font-family: Calibri;" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modelcode">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelcode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("ModelCode")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modelname">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelname" runat="server" Style="font-family: Calibri;" Text='<%#Eval("ModelName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hpkUpdate" runat="server" ToolTip="Update" NavigateUrl='<%#"ModelRegistration.aspx?ModelCode="+Eval("ModelCode") %>'><img src="../Images/update.jpg" alt="Edit" height="20" width="40" /></asp:HyperLink>--%>
                                    <asp:HyperLink ID="hpkUpdate" runat="server" Text="Edit" Style="font-family: Calibri;"
                                        ToolTip="Update" NavigateUrl='<%#"ModelRegistration.aspx?ModelCode="+Eval("ModelCode") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_Delete" runat="server" CommandName="Delete" ToolTip="Delete"
                                        NavigateUrl='<%#"ModelRegistration.aspx?ModelCode="+Eval("ModelCode") %>' Text="Delete"
                                        OnClientClick="return confirm('Are you sure want to delete...?')"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </table>
            </div>
            <%--</fieldset>--%>
            <%--                </div>--%>
            <%--            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
