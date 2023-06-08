<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewSMSHistory.aspx.cs" Inherits="BulkSMSFacility.Admin.ViewSMSHistory"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ register assembly="ProudMonkey.Common.Controls" namespace="ProudMonkey.Common.Controls"
        tagprefix="cc1" %>
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <script type="text/javascript">
        $(function () {
            $("input[id$='txt_FromDate']").datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("input[id$='txt_Todate']").datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--    <div class="MidContainer">--%>
    <%--<div class="Heading"><h4>View SMS History</h4></div>--%>
    <table class="style1" align="center">
        <div style="height: 12px; text-align: right;">
            <h5 style="padding-right: 2%">
                <asp:Label ID="Lbl_Welcome" runat="server" Height="50px"></asp:Label></h5>
        </div>
        <%--<asp:UpdatePanel ID="UU1" runat="server">
                <ContentTemplate>--%>
        <br />
        <tr>
            <td colspan="7" style="text-align: center">
                <h3>
                    View SMS History</h3>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Status&nbsp&nbsp
            </td>
            <td>
                <asp:DropDownList ID="ddl_Status" runat="server" Height="29px" Width="174px">
                    <asp:ListItem>DELIVERED</asp:ListItem>
                    <asp:ListItem>UNDELIVERED</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp&nbspFrom Date&nbsp
            </td>
            <td>
                <asp:TextBox ID="txt_FromDate" runat="server" Height="29px" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp&nbsp To Date &nbsp
            </td>
            <td>
                <asp:TextBox ID="txt_Todate" runat="server" Height="30px" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp&nbsp
                <asp:Button ID="btn_Search" Text="Search" runat="server" Height="30px" Width="80px"
                    BackColor="AliceBlue" OnClick="btn_Search_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_FromDate"
                    ForeColor="Red" ErrorMessage="Please enter valid date format" ValidationExpression="^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Todate"
                    ForeColor="Red" ErrorMessage="Please enter valid date format" ValidationExpression="^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: center">
                <cc1:MessageBox ID="MessageBox1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="grd_SMSHistory" runat="server" CssClass="GridView" AutoGenerateColumns="false" PageSize="15"
                    Width="952px" AllowPaging="True" OnPageIndexChanging="grd_SMSHistory_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl no" Visible="false">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SMSId">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblSmSId" runat="server" Text='<%#Eval("SMSId") %>'></asp:Label>--%>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sender">
                            <ItemTemplate>
                                <asp:Label ID="lblSenderId" Style="font-family: Calibri;" runat="server" Text='<%#Eval("SMSSender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sent Time">
                            <ItemTemplate>
                                <asp:Label ID="lblSentDateTime" Style="font-family: Calibri;" runat="server" Text='<%#Eval("SMSSentdateandTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dealer">
                            <ItemTemplate>
                                <asp:Label ID="lblSMSEnquiryNumber" Style="font-family: Calibri;" runat="server"
                                    Text='<%#Eval("DealerName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Receiver Mobile No.">
                            <ItemTemplate>
                                <asp:Label ID="lblSMSMobile" runat="server" Style="font-family: Calibri;" Text='<%#Eval("SMSMobile") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Style="font-family: Calibri;" Text='<%#Eval("SMSStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EnquiryType">
                            <ItemTemplate>
                                <asp:Label ID="lblEnquiryType" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EnquiryType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enquiry No.">
                            <ItemTemplate>
                                <asp:Label ID="lblSMSEnquiryNumber" runat="server" Style="font-family: Calibri;"
                                    Text='<%#Eval("SMSEnquiryNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grd_search" runat="server" CssClass="GridView" AutoGenerateColumns="false"
                    Width="952px" AllowPaging="True" OnPageIndexChanging="grd_search_PageIndexChanging"
                    PageSize="15">
                    <Columns>
                        <asp:TemplateField HeaderText="Sno" Visible="false">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SMSId">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblSmSId" runat="server" Text='<%#Eval("SMSId") %>'></asp:Label>--%>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sender">
                            <ItemTemplate>
                                <asp:Label ID="lblSenderId" runat="server" Text='<%#Eval("SMSSender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sent date &  Time">
                            <ItemTemplate>
                                <asp:Label ID="lblSentDateTime" runat="server" Text='<%#Eval("SMSSentdateandTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("SMSStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SMSMobile">
                            <ItemTemplate>
                                <asp:Label ID="lblSMSMobile" runat="server" Text='<%#Eval("SMSMobile") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EnquiryType">
                            <ItemTemplate>
                                <asp:Label ID="lblEnquiryType" runat="server" Text='<%#Eval("EnquiryType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enquiry Number">
                            <ItemTemplate>
                                <asp:Label ID="lblSMSEnquiryNumber" runat="server" Text='<%#Eval("SMSEnquiryNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: center">
                <b>
                    <asp:Label ID="lbl_Count" runat="server" Text=""></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td colspan="7" align="right">
                &nbsp;
                <asp:Button ID="btn_ExportExcel" Text="Export to Excel" runat="server" Height="30px"
                    Width="110px" BackColor="AliceBlue" OnClick="btn_ExportExcel_Click" />
                &nbsp;
                <asp:Button ID="btn_Exportalldata" Text="Export to Excel" runat="server" Height="30px"
                    Width="110px" BackColor="AliceBlue" OnClick="btn_Exportalldata_Click" />
            </td>
        </tr>
        <%--                </ContentTemplate>
            </asp:UpdatePanel>--%>
    </table>
    <%--    </div>--%>
</asp:Content>
