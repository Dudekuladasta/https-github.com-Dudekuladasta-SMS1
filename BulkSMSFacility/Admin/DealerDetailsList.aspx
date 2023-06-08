<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="DealerDetailsList.aspx.cs" Inherits="BulkSMSFacility.Admin.DealerDetailsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 392px;
        }
        .style3
        {
            width: 963px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>--%>
            <%--<div class="MidContainer">--%>
            <%--<div class="Heading"><h4>Dealer details</h4> </div>--%>
            <div style="height: 12px; text-align: right;">
                <h5 style="padding-right: 2%">
                    <asp:Label ID="Lbl_Welcome" runat="server" Height="50px"></asp:Label></h5>
            </div>
            <div style="height: 490px; width: 963px; margin-left: 19px; padding-left: 15%;" align="center">
                <%--<fieldset class="FieldSet_90">--%>
                <%--<legend><b>Dealer details</b></legend>--%>
                <table class="style1" align="center">
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <h3>
                                Dealer details</h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Dealer Code : &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Dealercode" runat="server" CssClass="TextBox_150" Style="text-transform: uppercase"
                                Height="28px" Width="174px" MaxLength="5"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" BackColor="AliceBlue" Height="30px" OnClick="btn_Search_Click"
                                Text="Search" Width="80px" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center" colspan="3">
                            <b>
                                <asp:Label ID="lblSuccess" runat="server" Text="" Visible=""></asp:Label></b>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:GridView ID="grd_Dealerdetails" runat="server" CssClass="GridView" AutoGenerateColumns="false"
                                AllowPaging="True" OnPageIndexChanging="grd_Dealerdetails_PageIndexChanging"
                                PageSize="15" OnRowDeleting="grd_Dealerdetails_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sno" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerid" runat="server" Style="font-family: Calibri;" Text='<%#Eval("Dealerid")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealercode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerCode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealername">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealerlocation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerLocation" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerLocation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DealerPIC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerPIC" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerPIC")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DealerMobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerMobileNumber" runat="server" Style="font-family: Calibri;"
                                                Text='<%#Eval("DealerMobileNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmployeeName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employeecode" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeecode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EmployeeCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DepartmentName" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartmentName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hpkUpdate" runat="server" Text="Edit" ToolTip="Edit" NavigateUrl='<%#"DealerRegistration.aspx?Dealerid="+Eval("Dealerid") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Delete" runat="server" CommandName="Delete" Text="Delete"
                                                ToolTip="Delete" OnClientClick="return confirm('Are you sure want to delete...?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="grd_Search" runat="server" CssClass="GridView" AutoGenerateColumns="false"
                                AllowPaging="True" PageSize="15" OnRowDeleting="grd_Search_RowDeleting" OnPageIndexChanging="grd_Search_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sno" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerid" runat="server" Style="font-family: Calibri;" Text='<%#Eval("Dealerid")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealercode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerCode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealername">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dealerlocation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerLocation" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerLocation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DealerPIC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerPIC" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerPIC")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DealerMobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDealerMobileNumber" runat="server" Style="font-family: Calibri;"
                                                Text='<%#Eval("DealerMobileNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmployeeName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employeecode" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeecode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EmployeeCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DepartmentName" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartmentName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <%--<asp:HyperLink ID="hpkUpdate" runat="server" Style="font-family: Calibri;" ToolTip="Update"
                                                        NavigateUrl='<%#"DealerRegistration.aspx?Dealerid="+Eval("Dealerid") %>'></asp:HyperLink>--%>
                                            <asp:HyperLink ID="hpkUpdate" runat="server" Text="Update" ToolTip="Update" NavigateUrl='<%#"DealerRegistration.aspx?Dealerid="+Eval("Dealerid") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnk_Delete" runat="server" Style="font-family: Calibri;" CommandName="Delete"
                                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure want to delete...?')"></asp:LinkButton>--%>
                                            <asp:LinkButton ID="lnk_Delete" runat="server" CommandName="Delete" Text="Delete"
                                                ToolTip="Delete" OnClientClick="return confirm('Are you sure want to delete...?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="left">
                            <asp:Button ID="btn_ExportExcel" runat="server" BackColor="AliceBlue" Height="30px"
                                OnClick="btn_ExportExcel_Click" Text="Download" Width="80px" Style="margin-left: 738px"
                                Visible="False" />
                        </td>
                    </tr>
                </table>
                <%-- </fieldset>--%>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <br />
    <br />
    <br />
    <%--<table>
        <tr>
            <td align="left">
                <asp:Button ID="btn_ExportExcel" runat="server" BackColor="AliceBlue" Height="30px"
                    OnClick="btn_ExportExcel_Click" Text="Download" Width="80px" Style="margin-left: 1050px"
                    Visible="False" />
            </td>
        </tr>
    </table>--%>
</asp:Content>
