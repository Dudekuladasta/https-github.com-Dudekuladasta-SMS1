using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.Data;

namespace BulkSMSFacility.Admin
{
    public partial class UserDetails : System.Web.UI.Page
    {
        BulkSMS_BEL bulksms_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulksms_bll = new BulkSMS_BLL();
        DateTime localDate = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
            //Session.Clear();
            //Session.RemoveAll();
            if (!IsPostBack)
            {
                BindUserData();
                BindStatus();
                ddlStatus.Enabled = false;

                if (Session["UserName"] != null)
                {
                    Lbl_Welcome.Text = "<b><font color=Brown>" + "WELCOME: " + "</font>" + "<b><font color=red>" + Session["username"] + "</font>";
                }
                int UserId = Convert.ToInt32(Request.QueryString["Userid"]);

                if (UserId == 0)
                {
                    btn_update.Visible = false;
                    btn_save.Visible = true;
                }
                else
                {
                    btn_update.Visible = true;
                    btn_save.Visible = false;
                    bulksms_bel.Userid = UserId;
                    BindStatus();
                    DataTable dt = bulksms_bll.UserDetailsselectforupdate_BLL(UserId);

                    if (dt.Rows.Count > 0)
                    {
                        txt_Username.Text = dt.Rows[0]["username"].ToString();
                        txt_Password.Text = dt.Rows[0]["Passwrd"].ToString();
                    }
                }
            }
        }
        public void BindStatus()
        {
            ddlStatus.DataSource = bulksms_bll.Getuserstatusdetails_BLL();
            ddlStatus.DataTextField = "statusname";
            ddlStatus.DataValueField = "statusid";
            ddlStatus.DataBind();
            ddlStatus.Enabled = true;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            string strUsername = txt_Username.Text;
            string strPassword = txt_Password.Text;

            bulksms_bel.UserName = strUsername;
            bulksms_bel.Password = strPassword;
            bulksms_bel.DateRegistered = localDate;
            bulksms_bel.UserActive = ddlStatus.SelectedItem.Text;

            int insertsmsDetails = bulksms_bll.InsertUserDetais_BLL(bulksms_bel);

            if (insertsmsDetails == 1)
            {
                lblSuccess.ForeColor = System.Drawing.Color.Black;
                lblSuccess.Text = "User Details Added Successfully..!";
                lblSuccess.Visible = true;
                ResetFields();
                BindUserData();
            }
            else
            {
                lblSuccess.ForeColor = System.Drawing.Color.Red;
                lblSuccess.Text = "User Details already exist..!";
                lblSuccess.Visible = true;
            }
        }
        public void BindUserData()
        {
            grd_UserDetails.DataSource = bulksms_bll.UserDetails_Select_BLL();
            grd_UserDetails.DataBind();
        }
        public void ResetFields()
        {
            txt_Username.Text = string.Empty;
            txt_Password.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
        }

        protected void grd_UserDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            lblSuccess.Visible = false;
            grd_UserDetails.PageIndex = e.NewPageIndex;
            ResetFields();
            BindUserData();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string OutPut = "";
            int UserId = Convert.ToInt32(Request.QueryString["Userid"]);
            bulksms_bel.UserName = txt_Username.Text;
            bulksms_bel.Password = txt_Password.Text;
            bulksms_bel.Password = ddlStatus.SelectedItem.Text;
            OutPut = bulksms_bll.Delete_UserDetails_BLL(UserId);
            if (OutPut == "0")
            {
                lblSuccess.ForeColor = System.Drawing.Color.Black;
                lblSuccess.Text = "User Details Deleted Successfully..!";
                lblSuccess.Visible = true;
            }
            ResetFields();
            BindUserData();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string OutPut = "";
            int UserId = Convert.ToInt32(Request.QueryString["Userid"]);
            bulksms_bel.Userid = UserId;
            bulksms_bel.UserName = txt_Username.Text;
            bulksms_bel.Password = txt_Password.Text;
            bulksms_bel.UserActive = ddlStatus.SelectedItem.Text;
            OutPut = bulksms_bll.Update_UserDetails_BLL(bulksms_bel);
            if (OutPut == "0")
            {
                if (ddlStatus.SelectedItem.Text == "InActive")
                {
                    lblSuccess.ForeColor = System.Drawing.Color.Black;
                    lblSuccess.Text = "User has been Deactivated..!";
                    lblSuccess.Visible = true;
                }
                else
                {
                    lblSuccess.ForeColor = System.Drawing.Color.Black;
                    lblSuccess.Text = "User Details updated Successfully..!";
                    lblSuccess.Visible = true;
                }
            }

            ResetFields();
            BindUserData();
            txt_Username.Enabled=false;
            txt_Password.Enabled = false;
            ddlStatus.Enabled = false;
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        protected void grd_UserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Userid = Convert.ToInt32(((Label)grd_UserDetails.Rows[e.RowIndex].FindControl("lblUserid")).Text);
            bulksms_bel.Userid = Userid;
            bulksms_bll.Delete_UserDetails_BLL(Userid);
            lblSuccess.Visible = true;
            lblSuccess.Text = "User Deleted Sucessfully...";
            lblSuccess.ForeColor = System.Drawing.Color.Black;
            BindUserData();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("UserDetails.aspx", true);
        }
    }
}