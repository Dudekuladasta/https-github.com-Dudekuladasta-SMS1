using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.Web.UI.WebControls;
using System.Data;

namespace BulkSMSFacility.Admin
{
    public partial class DealerRegistration : System.Web.UI.Page
    {
        BulkSMS_BEL bulkSMS_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulkSMS_bll = new BulkSMS_BLL();
        int Dealerid;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
            //Session.Clear();
            //Session.RemoveAll();
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    Lbl_Welcome.Text = "<b><font color=Brown>" + "WELCOME: " + "</font>" + "<b><font color=red>" + Session["username"] + "</font>";
                }
                //BindDealerDetails();
                bindStatename();
                bindDealerPICs();
                Dealerid = Convert.ToInt32(Request.QueryString["Dealerid"]);
                if (Dealerid==0)
                {
                    btn_update.Visible = false;
                    btn_submit.Visible = true;
                    //btn_clear.Visible = false;
                    //LinkButton1.Visible = false;
                }
                else
                {
                    btn_update.Visible = true;
                    btn_submit.Visible = false;
                    //LinkButton1.Visible = false;
                    //btn_clear.Visible = false;
                    bulkSMS_bel.Dealerid = Dealerid;
                    DataTable dtDealerid;
                    dtDealerid = bulkSMS_bll.SearchDealerID_BLL(Dealerid);
                    if (dtDealerid.Rows.Count > 0)
                    {
                        string strLocation = dtDealerid.Rows[0]["DealerLocation"].ToString();
                        ddl_DLocation.Items.FindByText(strLocation).Selected = true;
                        bulkSMS_bel.sDealerLocation = strLocation;
                        txt_DealerName.Text = dtDealerid.Rows[0]["DealerName"].ToString();
                        txt_Dealercode.Text = dtDealerid.Rows[0]["DealerCode"].ToString();
                        string str = dtDealerid.Rows[0]["DealerPIC"].ToString();
                        ddl_DealerPIC.Items.FindByText(str).Selected = true;
                        bulkSMS_bel.sDealerPIC = str;
                        txt_Mobilenumber.Text = dtDealerid.Rows[0]["DealerMobileNumber"].ToString();
                        txt_EmployeeName.Text = dtDealerid.Rows[0]["EmployeeName"].ToString();
                        txt_Empcode.Text = dtDealerid.Rows[0]["EmployeeCode"].ToString();
                        txt_Departmentname.Text = dtDealerid.Rows[0]["DepartmentName"].ToString();
                        txt_EmpMail.Text = dtDealerid.Rows[0]["EmpEmail"].ToString();
                    }
                }
            }
        }
        public void BindDealerDetails()
        {
            Grd_DealerRegDetails.DataSource = bulkSMS_bll.GetDealerRegistrationDetails_BLL();
            Grd_DealerRegDetails.DataBind();
        }
        public void bindStatename()
        {
            ddl_DLocation.DataSource = bulkSMS_bll.GetStatename_BLL();
            ddl_DLocation.DataTextField = "Statename";
            ddl_DLocation.DataValueField = "Stateid";
            ddl_DLocation.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealerlocation";
            lstitem.Value = "0";
            ddl_DLocation.Items.Insert(0, lstitem);
        }
        public void bindDealerPICs()
        {
            DataTable dtdealerpic=new DataTable();
            dtdealerpic.Columns.Add("DealerPIC",typeof(System.String));
            dtdealerpic.Rows.Add("General Manager [Sales]");
            dtdealerpic.Rows.Add("Head Customer Relations");
            dtdealerpic.Rows.Add("VP Sales");
            dtdealerpic.Rows.Add("Others");

            ddl_DealerPIC.DataSource = dtdealerpic;
            ddl_DealerPIC.DataTextField = "DealerPIC";
            ddl_DealerPIC.DataValueField = "";
            ddl_DealerPIC.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Please select DealerPIC";
            lstitem.Value = "0";
            ddl_DealerPIC.Items.Insert(0, lstitem);
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            bulkSMS_bel.sDealerLocation = ddl_DLocation.SelectedItem.Text.ToUpper();
            bulkSMS_bel.DealerCode = txt_Dealercode.Text.ToUpper();
            bulkSMS_bel.DealerName = txt_DealerName.Text.ToUpper();
            bulkSMS_bel.sDealerPIC = ddl_DealerPIC.SelectedItem.Text;
            bulkSMS_bel.DealerMobile = txt_Mobilenumber.Text;
            bulkSMS_bel.EmployeeName = txt_EmployeeName.Text.ToUpper();
            bulkSMS_bel.EmployeeCode = txt_Empcode.Text.ToUpper();
            bulkSMS_bel.DepartmentName = txt_Departmentname.Text.ToUpper();
            bulkSMS_bel.EmpEmail = txt_EmpMail.Text;
            bulkSMS_bel.DateRegistered = localDate;

            int insertmodelDetails = bulkSMS_bll.Insert_DealerDetails_BLL(bulkSMS_bel);
            if (insertmodelDetails == 1)
            {
                lbl_Success.ForeColor = System.Drawing.Color.Black;
                lbl_Success.Text = "Dealer details Added Successfully!";
                lbl_Success.Visible = true;
            }
            else
            {
                lbl_Success.ForeColor = System.Drawing.Color.Red;
                lbl_Success.Text = "Dealer Details already exist..!";
                lbl_Success.Visible = true;
            }
            BindDealerDetails();
            Resetfields();
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            bulkSMS_bel.Dealerid = Convert.ToInt32(Request.QueryString["Dealerid"]);
            bulkSMS_bel.sDealerLocation = ddl_DLocation.SelectedItem.Text.ToUpper();
            bulkSMS_bel.DealerCode = txt_Dealercode.Text.ToUpper();
            bulkSMS_bel.DealerName = txt_DealerName.Text.ToUpper();
            bulkSMS_bel.sDealerPIC = ddl_DealerPIC.SelectedItem.Text;
            bulkSMS_bel.DealerMobile = txt_Mobilenumber.Text;
            bulkSMS_bel.EmployeeName = txt_EmployeeName.Text.ToUpper();
            bulkSMS_bel.EmployeeCode = txt_Empcode.Text.ToUpper();
            bulkSMS_bel.DepartmentName = txt_Departmentname.Text.ToUpper();
            bulkSMS_bel.EmpEmail = txt_EmpMail.Text;
            bulkSMS_bel.DateRegistered = localDate;
            bulkSMS_bll.Update_DealerDetails_BLL(bulkSMS_bel);
            Resetfields();
            lbl_Success.Text = "DealerDetails Updated Sucessfully...";
            Disablefields();
            BindDealerUpdatetdDetails();
        }
        public void Disablefields()
        {
            ddl_DLocation.Enabled = false;
            txt_Dealercode.Enabled = false;
            txt_DealerName.Enabled = false;
            ddl_DealerPIC.Enabled = false;
            txt_Mobilenumber.Enabled = false;
            txt_EmployeeName.Enabled = false;
            txt_Empcode.Enabled = false;
            txt_Departmentname.Enabled = false;
            txt_EmpMail.Enabled = false;
        }
        public void Resetfields()
        {
            txt_Dealercode.Text = string.Empty;
            txt_DealerName.Text = string.Empty;
            txt_Mobilenumber.Text = string.Empty;
            ddl_DLocation.SelectedIndex = 0;
            ddl_DealerPIC.SelectedIndex = 0;
            txt_EmployeeName.Text = string.Empty;
            txt_Empcode.Text = string.Empty;
            txt_Departmentname.Text = string.Empty;
            txt_EmpMail.Text = string.Empty;
        }

        protected void Grd_DealerRegDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_DealerRegDetails.PageIndex = e.NewPageIndex;
            BindDealerDetails();
        }

        protected void Grd_DealerRegDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Dealerid = Convert.ToInt32(((Label)Grd_DealerRegDetails.Rows[e.RowIndex].FindControl("lblDealerid")).Text);
            bulkSMS_bel.Dealerid = Dealerid;
            DateTime localDate = DateTime.Now;
            bulkSMS_bel.DateRegistered = localDate;
            bulkSMS_bll.Delete_Dealer_BLL(bulkSMS_bel);
            lbl_Success.Text = "DealerDetails Deleted Sucessfully...";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DealerDetailsList.aspx", true);
            BindDealerUpdatetdDetails();

        }
        public void BindDealerUpdatetdDetails()
        {
            Grd_DealerRegDetails.DataSource = bulkSMS_bll.GetDealerRegistrationUpdatedDetails_BLL();
            Grd_DealerRegDetails.DataBind();
        }
    }
}
