<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BroadCastingMaster.Master"
    AutoEventWireup="true" CodeBehind="BroadCastingSMS.aspx.cs" Inherits="BulkSMSFacility.BroadCastingPage.BroadCastingSMS" %>

<%@ Register Assembly="ProudMonkey.Common.Controls" Namespace="ProudMonkey.Common.Controls"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Script/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <script src="../Script/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../Script/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="../Script/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });
    </script>
    <style type="text/css">
        .checkboxlist input
        {
            font: inherit;
            font-size: 0.875em;
            color: #494949;
            margin-bottom: 5px;
            margin-top: 5px;
            margin-right: 9px !important;
        }
        
        .style3
        {
            width: 731px;
        }
        .style5
        {
            width: 122px;
        }
        .AcceptedAgreement
        {
        }
        .style10
        {
            text-align: left;
        }
        .newStyle1
        {
            font-family: "Berlin Sans FB";
        }
        .newStyle2
        {
            color: #FED22F;
        }
        .newStyle3
        {
            font-family: Calibri;
            color: #B81900;
        }
        .style28
        {
            text-align: left;
            height: 31px;
        }
        .style30
        {
            width: 173px;
            text-align: left;
            height: 30px;
        }
        .style31
        {
            text-align: left;
            height: 30px;
        }
        .style33
        {
            height: 31px;
        }
        .style34
        {
            width: 131px;
            height: 31px;
        }
        .style37
        {
            width: 141px;
            height: 31px;
        }
        .style40
        {
            width: 173px;
            text-align: left;
            height: 31px;
        }
        .style41
        {
            width: 173px;
            text-align: left;
        }
    </style>
    <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            var checkBoxList = document.getElementById("<%=chk_EnquiryType.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
    <div class="MidContainer">
        <div>
            <img src="../Images/Toyota1.jpg" style="height: 12%; width: 8%; margin-left: 1px;" />
        </div>
        <div class="menu" style="padding-left: 45%; padding-top: 1%;">
            SMS Application System</div>
        <div style="background-color: White; height: 20px; text-align: right;">
        </div>
        <div style="height: 745px; width: 875px; margin-left: 19px; background-color: White;
            padding-left: 17%;">
            <div id="tabs">
                <ul>
                    <li><a href="#Dealer">Dealer</a></li>
                    <%--<li><a href="#Customer">Customer</a></li>--%>
                </ul>

                <asp:UpdatePanel ID="UU1" runat="server">
                    <ContentTemplate>
                        <div id="Dealer" style="background-color: White;">
                            <asp:Panel ID="Panel1" runat="server">
                                <fieldset class="FieldSet_90">
                                    <legend><b>Dealer Section</b></legend>
                                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <table class="style3">
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="lbl_DealerLocation" runat="server" Text="Dealer Location :"></asp:Label>
                                            </td>
                                            <td class="style28" colspan="2">
                                                <asp:DropDownList ID="ddl_DealerLocation" runat="server" Height="26px" Width="185px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_DealerLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp&nbsp
                                                <asp:RequiredFieldValidator ID="rfv_Location" runat="server" ControlToValidate="ddl_DealerLocation"
                                                    ErrorMessage="Please select Dealer location" ForeColor="Red" InitialValue="0"
                                                    SetFocusOnError="true" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="lbl_DealerName" runat="server" Text="Dealer Name :"></asp:Label>
                                            </td>
                                            <td class="style28" colspan="2">
                                                <asp:DropDownList ID="ddl_DealerName" runat="server" Height="26px" Width="185px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_DealerName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp&nbsp
                                                <asp:RequiredFieldValidator ID="rfv_DealerName" runat="server" ControlToValidate="ddl_DealerName"
                                                    ErrorMessage="Please select Dealer name" ForeColor="Red" InitialValue="0" SetFocusOnError="true"
                                                    ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style30">
                                                <asp:Label ID="lbl_DealerCode" runat="server" Text="Dealer Code :"></asp:Label>
                                            </td>
                                            <td class="style31" colspan="2">
                                                <asp:DropDownList ID="ddl_DealerCode" runat="server" Height="26px" Width="185px">
                                                </asp:DropDownList>
                                                &nbsp&nbsp
                                                <asp:RequiredFieldValidator ID="rfv_Dcode" runat="server" ControlToValidate="ddl_DealerCode"
                                                    ErrorMessage="Please select Dealer code" ForeColor="Red" InitialValue="0" SetFocusOnError="true"
                                                    ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style41">
                                                <asp:Label ID="lblDealerPIC" runat="server" Text="Dealer PIC :"></asp:Label>
                                            </td>
                                            <td class="style10" align="justify">
                                                <asp:CheckBoxList ID="chk_DealerPIC" runat="server" Width="223px" DataTextField="DEALERMobileNumber"
                                                    Style="text-align: left; margin-left: 0px;" Font-Bold="False" CssClass="checkboxlist">
                                                    <asp:ListItem Text="General Manager [Sales]" Value="0">General Manager [Sales]</asp:ListItem>
                                                    <asp:ListItem Text="Head Customer Relations" Value="0">Head Customer Relations</asp:ListItem>
                                                    <asp:ListItem Text="VP Sales" Value="0">VP Sales</asp:ListItem>
                                                </asp:CheckBoxList>
                                                <%--<asp:CustomValidator ID="CustomValidator1" runat="server" 
                                            ClientValidationFunction="ValidateCheckBoxList" 
                                            ErrorMessage="Please select at least one DealerPIC" 
                                            ForeColor="Red" ValidationGroup="BulkSMS"></asp:CustomValidator>--%>
                                            </td>
                                            <td class="style5">
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style41">
                                                <asp:Label ID="lbl_Others" runat="server" Text="Others Mobile Number :"></asp:Label>
                                            </td>
                                            <td class="style10" colspan="2">
                                                <asp:TextBox ID="txt_OthersMobile" runat="server" Height="22px" Width="185px" MaxLength="10"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_OthersMobile"
                                                    ErrorMessage="Please enter valid Mobile number" ForeColor="Red" ValidationExpression="^([6-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                                                <asp:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txt_OthersMobile" FilterType="Numbers">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                                </fieldset>
                            </asp:Panel>
                            <br />
                            <table align="center">
                                <tr align="center">
                                    <td>
                                        <%--<asp:Label ID="lblStatusmsg" runat="server"></asp:Label>--%>
                                        <cc1:MessageBox ID="MessageBox1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                                <fieldset class="FieldSet_90">
                                    <legend><b>Customer Details</b></legend>
                                    <table class="style3">
                                        <tr>
                                            <td class="style37">
                                                <asp:Label ID="lbl_CustName" runat="server" Text="Customer Name :"></asp:Label>
                                            </td>
                                            <td class="style33">
                                                <asp:DropDownList ID="ddl_Title" runat="server" Width="52px" Height="26px" Mandetory="Please Select Title">
                                                    <asp:ListItem Selected="True" Value="0">Title</asp:ListItem>
                                                    <asp:ListItem>Mr.</asp:ListItem>
                                                    <asp:ListItem>Ms</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txt_CustName" runat="server" Height="25px" Width="160px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_CustName" runat="server" ControlToValidate="txt_CustName"
                                                    ErrorMessage="Enter Customer Name" ForeColor="Red" ValidationGroup="BulkSMS">Please enter Customer name</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style37">
                                                <asp:Label ID="lbl_CustMobile" runat="server" Text="Customer Mobile :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_CustMobile" runat="server" Height="22px" Width="180px" MaxLength="10"></asp:TextBox>&nbsp&nbsp
                                                <asp:RequiredFieldValidator ID="rfv_Mob" runat="server" ErrorMessage="Please enter mobile number"
                                                    ForeColor="Red" ControlToValidate="txt_CustMobile" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_CustMobile"
                                                    ErrorMessage="Please enter valid Mobile number!" ForeColor="Red" ValidationExpression="^([6-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                                    TargetControlID="txt_CustMobile" FilterType="Numbers">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel5" runat="server">
                                <fieldset class="FieldSet_90">
                                    <legend><b>Enquiry Details</b></legend>
                                    <table class="style3">
                                        <tr>
                                            <td class="style34">
                                                Enquiry Type :
                                            </td>
                                            <td>
                                                <asp:CheckBoxList ID="chk_EnquiryType" runat="server" Width="115px" Height="53px"
                                                    CssClass="checkboxlist">
                                                    <asp:ListItem>Test Drive</asp:ListItem>
                                                    <asp:ListItem>Buy Now</asp:ListItem>
                                                </asp:CheckBoxList>
                                                &nbsp&nbsp<asp:CustomValidator ID="cust_Enqtype" runat="server" ClientValidationFunction="ValidateCheckBoxList"
                                                    ErrorMessage="Please select at least one Enquiry type" ForeColor="Red" ValidationGroup="BulkSMS"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style34">
                                                <asp:Label ID="lblModelName" runat="server" Text="Model Name"></asp:Label>
                                                &nbsp;:
                                            </td>
                                            <td class="style33">
                                                <asp:DropDownList ID="ddl_ModelName" runat="server" Height="26px" Width="185px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_ModelName" runat="server" ControlToValidate="ddl_ModelName"
                                                    ErrorMessage="Please select Model name" ForeColor="Red" InitialValue="0" SetFocusOnError="true"
                                                    ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style34">
                                                Enquiry Number :
                                            </td>
                                            <td class="style33">
                                                <asp:TextBox ID="txtEnquiryNum" runat="server" Height="22px" Width="185px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_EnqNumber" runat="server" ControlToValidate="txtEnquiryNum"
                                                    ErrorMessage="Please enter Enquiry number." ForeColor="Red" ValidationGroup="BulkSMS"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server">
                                <%--<fieldset class="FieldSet_90">--%>
                                <table align="center" style="height: 30px; width: 21px">
                                    <%-- <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                    <tr align="center">
                                        <td>
                                            <asp:Button ID="btnSendSMS" runat="server" Text="Send SMS" Width="109px" Height="33px"
                                                ValidationGroup="BulkSMS" OnClick="btnSendSMS_Click" Font-Bold="True" Font-Names="Bell MT"
                                                Font-Size="Small" ForeColor="Black" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="109px" Height="33px"
                                                OnClick="btnClear_Click" Font-Bold="True" Font-Names="Bell MT" Font-Size="Small"
                                                ForeColor="Black" />
                                        </td>
                                    </tr>
                                    <%--</ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSendSMS" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                    <%--<asp:Label ID="lblStatusmsg" runat="server"></asp:Label>--%>
                                </table>
                                <%--</fieldset>--%>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdateCustomerPanel" runat="server">
                    <ContentTemplate>
                        <div id="Customer">
                            <asp:Panel ID="Panel4" runat="server">
                                <fieldset class="FieldSet_90">
                                    <table class="style3">
                                        <tr>
                                            <td>
                                                Dealer Location :
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_CustDealerLocation" runat="server" Height="26px" Width="185px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_CustDealerLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style33">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style33">
                                                Dealer Name
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_CustDealerName" runat="server" Height="26px" Width="185px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_CustDealerName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style33">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style33">
                                                Dealer Code
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_CustDealerCode" runat="server" Height="26px" Width="185px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style33">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style33">
                                                <asp:Label ID="lbl_CustomerName" runat="server" Text="Customer Name :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCustmername" runat="server" CssClass="TextBox_150" Height="26px"
                                                    Width="185px"></asp:TextBox>
                                            </td>
                                            <td class="style33">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style35">
                                                <asp:Label ID="lbl_CstMble" runat="server" Text="Customer Mobile :"></asp:Label>
                                            </td>
                                            <td class="style35">
                                                <asp:TextBox ID="txt_CMobile" runat="server" CssClass="TextBox_150" Height="26px"
                                                    Width="185px"></asp:TextBox>
                                            </td>
                                            <td class="style35">
                                                &nbsp;
                                            </td>
                                            <td class="style35">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                            <table align="center" style="height: 30px; width: 21px">
                                <tr align="center">
                                    <td>
                                        <asp:Button ID="btn_sendCustomerSMS" runat="server" Text="Send SMS" CssClass="Btn"
                                            Width="109px" Height="33px" Font-Bold="True" Font-Names="Bell MT" Font-Size="Small"
                                            ForeColor="Black" OnClick="btn_sendCustomerSMS_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_ClearSMS" runat="server" Text="Clear SMS" Width="109px" Height="33px"
                                            Font-Bold="True" Font-Names="Bell MT" Font-Size="Small" ForeColor="Black" CssClass="Btn" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <div class="footer">
            <strong>SMS Application System @ 2018</strong></div>
    </div>
</asp:Content>
