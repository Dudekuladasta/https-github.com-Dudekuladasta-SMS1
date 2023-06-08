using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.Data.SqlClient;
using System.Data;

namespace BulkSMSFacility.Admin
{
    public partial class ModelRegistration : System.Web.UI.Page
    {
        BulkSMS_BEL bulksms_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulksms_bll = new BulkSMS_BLL();
        DateTime localDate = DateTime.Now;
        string strModelcode;
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
                BindModelData();
                strModelcode = Request.QueryString["ModelCode"];
                if (strModelcode == "" || strModelcode == null)
                {
                    btn_update.Visible = false;
                    btn_submit.Visible = true;
                }
                else
                {
                    btn_update.Visible = true;
                    btn_submit.Visible = false;
                    bulksms_bel.ModelCode = strModelcode;
                    DataTable dtmodelcode = bulksms_bll.ModelCodeselectforupdate_BLL(strModelcode);
                    txt_ModelCode.Text = dtmodelcode.Rows[0]["ModelCode"].ToString();
                    txt_ModelName.Text = dtmodelcode.Rows[0]["ModelName"].ToString();
                }
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            string strModelcode = txt_ModelCode.Text.ToUpper();
            string strModelname = txt_ModelName.Text.ToUpper();
            string strModelActive = "Y";

            bulksms_bel.ModelCode = strModelcode;
            bulksms_bel.ModelName = strModelname;
            bulksms_bel.DateRegistered = localDate;
            bulksms_bel.ModelActive = strModelActive;

            int insertmodelDetails = bulksms_bll.InsertModelDetais_BLL(bulksms_bel);
            if (insertmodelDetails == 1)
            {
                lblSuccess.ForeColor = System.Drawing.Color.Black;
                lblSuccess.Text = "Model Details Added Successfully..!";
                lblSuccess.Visible = true;
                ResetFields();
                BindModelData();
            }
            else
            {
                lblSuccess.ForeColor = System.Drawing.Color.Red;
                lblSuccess.Text = "Model Details already exist..!";
                lblSuccess.Visible = true;
            }
        }
        public void ResetFields()
        {
            txt_ModelCode.Text = string.Empty;
            txt_ModelName.Text = string.Empty;
        }
        public void BindModelData()
        {
            grd_ModelDetails.DataSource = bulksms_bll.ModelName_Select_BLL();
            grd_ModelDetails.DataBind();
        }
        protected void grd_ModelDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            lblSuccess.Visible = false;
            grd_ModelDetails.PageIndex = e.NewPageIndex;
            ResetFields();
            BindModelData();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string OutPut = "";
            string strmodelcode = txt_ModelCode.Text;
            bulksms_bel.ModelCode = strmodelcode;
            bulksms_bel.ModelName = txt_ModelName.Text;
            OutPut = bulksms_bll.Delete_modelcode_BLL(strmodelcode);
            if (OutPut == "0")
            {
                lblSuccess.ForeColor = System.Drawing.Color.Red;
                lblSuccess.Text = "Model Details Deleted Successfully..!";
                lblSuccess.Visible = true;
            }
            ResetFields();
            BindModelData();
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            //ResetFields();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string OutPut = "";
            string strmodelcode = txt_ModelCode.Text.ToUpper();
            string strmodelname = txt_ModelName.Text.ToUpper();
            bulksms_bel.ModelCode = strmodelcode;
            bulksms_bel.ModelName = strmodelname;
            OutPut = bulksms_bll.Update_modelcode_BLL(bulksms_bel);
            if (OutPut == "0")
            {
                lblSuccess.ForeColor = System.Drawing.Color.Black;
                lblSuccess.Text = "Model Details Updated Successfully..!";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.ForeColor = System.Drawing.Color.Red;
                lblSuccess.Text = "Model Details already Updated ..!";
                lblSuccess.Visible = true;
            }
            ResetFields();
            txt_ModelCode.Enabled = false;
            txt_ModelName.Enabled = false;
            BindModelData();
        }

        protected void grd_ModelDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strmodelcode = Convert.ToString(((Label)grd_ModelDetails.Rows[e.RowIndex].FindControl("lblModelcode")).Text);
            bulksms_bel.ModelCode = strmodelcode;
            bulksms_bll.Delete_modelcode_BLL(strmodelcode);
            lblSuccess.Visible = true;
            lblSuccess.Text = "Model Details Deleted Sucessfully...";
            lblSuccess.ForeColor = System.Drawing.Color.Red;
            BindModelData();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModelRegistration.aspx", true);
        }

    }
}