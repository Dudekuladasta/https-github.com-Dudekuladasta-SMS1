<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="DealerRegistration.aspx.cs" Inherits="BulkSMSFacility.Admin.DealerRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style39
        {
            height: 45px;
        }
        .style36
        {
            height: 44px;
        }
        .style37
        {
            height: 68px;
        }
        .style39
        {
            height: 39px;
        }
        .style40
        {
            color: #990000;
        }
        .style41
        {
            height: 39px;
            width: 146px;
        }
        .style42
        {
            height: 68px;
            width: 146px;
        }
        .style43
        {
            width: 146px;
        }
        .style44
        {
            height: 39px;
            width: 154px;
        }
        .style45
        {
            height: 68px;
            width: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <%--<div class="MidContainer">--%>
            <div style="height: 12px; text-align: right;">
                <h5 style="padding-right: 2%">
                    <asp:Label ID="Lbl_Welcome" runat="server" Height="50px"></asp:Label></h5>
            </div>
            <%--<div style="height: 490px; width: 850px; margin-left: 19px; padding-left: 15%;" align="center">--%>
            <%--<fieldset class="FieldSet_90">--%>
            <%-- <legend><b>Dealer master details</b></legend>--%>
            <table align="center">
                <tr>
                    <td style="text-align: center">
                        &nbsp;
                    </td>
                    <td colspan="6" style="text-align: center">
                        <h3>
                            Dealer Registration</h3>
                    </td>
                </tr>
                <tr>
                    <td class="style39">
                        &nbsp;
                    </td>
                    <td class="style41">
                        Dealer Location <span class="style40">*</span>
                    </td>
                    <td class="style39">
                        <asp:DropDownList ID="ddl_DLocation" runat="server" Height="25px" Width="165px" CssClass="DDL">
                        </asp:DropDownList>
                    </td>
                    <td width="110px" class="style39">
                        <asp:RequiredFieldValidator ID="Rfv_Dlocation" runat="server" ControlToValidate="ddl_DLocation"
                            Width="200px" ErrorMessage="Please select Dealer location" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style44">
                        Dealer Name <span class="style40">*</span>
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="txt_DealerName" runat="server" Height="25px" Width="165px" Style="text-transform: uppercase"
                            CssClass="TextBox_150"></asp:TextBox>
                    </td>
                    <td width="210px" class="style39">
                        <asp:RequiredFieldValidator ID="rfv_DName" runat="server" ControlToValidate="txt_DealerName"
                            Width="203px" ErrorMessage="Please enter Dealer name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style39">
                        &nbsp;
                    </td>
                    <td class="style41">
                        Dealer Code <span class="style40">*</span>
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="txt_Dealercode" runat="server" Height="25px" Style="text-transform: uppercase"
                            Width="165px" CssClass="TextBox_150" MaxLength="5"></asp:TextBox>
                    </td>
                    <td width="110px" class="style36">
                        <asp:RequiredFieldValidator ID="Rfv_Dcode" runat="server" ControlToValidate="txt_Dealercode"
                            ErrorMessage="Please enter Dealer code" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style44">
                        Dealer PIC <span class="style40">*</span>
                    </td>
                    <td class="style39">
                        <asp:DropDownList ID="ddl_DealerPIC" runat="server" Height="25px" Width="165px" CssClass="DDL">
                        </asp:DropDownList>
                    </td>
                    <td width="110px" class="style39">
                        <asp:RequiredFieldValidator ID="rfv_DealerPIC" runat="server" ControlToValidate="ddl_DealerPIC"
                            ErrorMessage="Please select Dealer PIC" ForeColor="Red" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style37">
                        &nbsp;
                    </td>
                    <td class="style42">
                        Dealer Mobile <span class="style40">*</span>
                    </td>
                    <td class="style37">
                        <asp:TextBox ID="txt_Mobilenumber" runat="server" CssClass="TextBox_150" Height="25px"
                            Width="165px" MaxLength="10"></asp:TextBox>
                    </td>
                    <td width="110px" class="style37">
                        <asp:RequiredFieldValidator ID="Rfv_mobilenumber" runat="server" ControlToValidate="txt_Mobilenumber"
                            ErrorMessage="Please enter Mobile number" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:FilteredTextBoxExtender ID="Mobilenumber_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="txt_Mobilenumber" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                        <asp:RegularExpressionValidator ID="Reg_Mobilenumber" runat="server" ControlToValidate="txt_Mobilenumber"
                            ErrorMessage="Please enter valid Mobile number" ForeColor="Red" ValidationExpression="^([6-9]{1})([0-9]{9})$">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td class="style45">
                        Employee Name <span class="style40">*</span>
                    </td>
                    <td class="style37">
                        <asp:TextBox ID="txt_EmployeeName" runat="server" CssClass="TextBox_150" Style="text-transform: uppercase"
                            Height="25px" Width="165px"></asp:TextBox>
                    </td>
                    <td width="110px" class="style37">
                        <asp:RequiredFieldValidator ID="Rfv_EmployeeName" runat="server" ControlToValidate="txt_EmployeeName"
                            ErrorMessage="Please enter Employee name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style39">
                        &nbsp;
                    </td>
                    <td class="style41">
                        Employee Code :
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="txt_Empcode" runat="server" Style="text-transform: uppercase" CssClass="TextBox_150"
                            Height="25px" Width="165px" MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="style39">
                    </td>
                    <td class="style44">
                        Department Name :
                    </td>
                    <td class="style39">
                        <asp:TextBox ID="txt_Departmentname" Style="text-transform: uppercase" runat="server"
                            CssClass="TextBox_150" Height="25px" Width="165px"></asp:TextBox>
                    </td>
                    <td class="style39">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style43">
                        Employee Email :
                    </td>
                    <td>
                        <asp:TextBox ID="txt_EmpMail" runat="server" CssClass="TextBox_150" Height="25px"
                            Width="165px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td colspan="3" style="text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                    &nbsp;</tr>
                <td colspan="6" style="text-align: center">
                    <asp:Button ID="btn_submit" runat="server" BackColor="AliceBlue" Height="30px" OnClick="btn_submit_Click"
                        Text="Save" Width="80px" />
                    <asp:Button ID="btn_update" runat="server" BackColor="AliceBlue" Height="30px" OnClick="btn_update_Click"
                        Text="Update" Width="80px" />
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" Text="To see dealerdata please click.."
                        ToolTip="view to dealerdata" onclick="LinkButton1_Click">Please click here to view Dealerdata</asp:LinkButton>--%>
                    <%--<asp:Button ID="btn_clear" runat="server" BackColor="AliceBlue" Height="30px" OnClick="btn_clear_Click"
                        Text="Viewdata" Width="80px" />--%>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: center">
                            <b>
                                <asp:Label ID="lbl_Success" runat="server" Text=""></asp:Label>
                            </b>
                        </td>
                    </tr>
                </td>
                </td>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <asp:GridView ID="Grd_DealerRegDetails" runat="server" AllowPaging="True" PageSize="5"
                            AutoGenerateColumns="false" Width="100%" Height="40%" CssClass="GridView" OnPageIndexChanging="Grd_DealerRegDetails_PageIndexChanging"
                            OnRowDeleting="Grd_DealerRegDetails_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Sno" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDealerid" runat="server" Style="font-family: Calibri;" Text='<%#Eval("Dealerid")%>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dealerlocation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDealerLocation" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerLocation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dealername">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDealerName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dealercode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDealerCode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DealerCode")%>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Employeecode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeecode" runat="server" Style="font-family: Calibri;" Text='<%#Eval("EmployeeCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DepartmentName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartmentName" runat="server" Style="font-family: Calibri;" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hpkUpdate" runat="server" Text="Edit" ToolTip="Edit" NavigateUrl='<%#"DealerRegistration.aspx?Dealerid="+Eval("Dealerid") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
