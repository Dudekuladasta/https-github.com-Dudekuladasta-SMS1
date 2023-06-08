using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;

namespace BulkSMSFacility.Admin
{
    public partial class DealerDetailsList : System.Web.UI.Page
    {
        BulkSMS_BEL bulksms_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulksms_bll = new BulkSMS_BLL();
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
                grd_Search.Visible = false;
                BindDealerDetails();
                btn_ExportExcel.Visible = true;
            }
        }
        public void BindDealerDetails()
        {
            grd_Dealerdetails.DataSource = bulksms_bll.GetDealerDetails_BLL();
            grd_Dealerdetails.DataBind();
        }

        public void BindDealerDeleteDetails()
        {
            string strDealercode = txt_Dealercode.Text;
            grd_Search.DataSource = bulksms_bll.GetDealerRegistrationdelete_BLL(strDealercode);
            grd_Search.DataBind();
        }
        protected void grd_Dealerdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_Dealerdetails.PageIndex = e.NewPageIndex;
            BindDealerDetails();
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            grd_Search.DataSource = null;
            grd_Search.DataBind();
            grd_Dealerdetails.DataSource = null;
            grd_Dealerdetails.DataBind();
            btn_ExportExcel.Visible = false;
            if (txt_Dealercode.Text.ToUpper() != string.Empty || txt_Dealercode.Text.ToUpper() != "")
            {
                BindSearchGrid();

                if (grd_Search.Rows.Count == 0)
                {
                    lblSuccess.Visible = true;
                    lblSuccess.ForeColor = System.Drawing.Color.Black;
                    lblSuccess.Text = "Dealer details not available..!";
                    grd_Dealerdetails.Visible = false;
                    grd_Search.Visible = false;
                    lblSuccess.Visible = true;
                    this.btn_ExportExcel.Visible = false;
                }
                else
                {
                    lblSuccess.Visible = false;
                    grd_Search.Visible = true;
                    grd_Dealerdetails.Visible = false;
                    this.btn_ExportExcel.Visible = false;
                }
            }
            else
            {
                lblSuccess.ForeColor = System.Drawing.Color.Black;
                lblSuccess.Text = "Please enter Dealer code..!";
                lblSuccess.Visible = true;
                this.btn_ExportExcel.Visible = false;
            }
            
        }
        public void BindSearchGrid()
        {
            DataTable dt = new DataTable();
            bulksms_bel.sDealerLocation = txt_Dealercode.Text;
            dt = bulksms_bll.SearchDealerDetailsbyDealerName_BLL(txt_Dealercode.Text);
            if (dt.Rows.Count > 0)
            {
                grd_Search.DataSource = dt;
                grd_Search.DataBind();
            }
            
        }
        protected void grd_Dealerdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Dealerid = Convert.ToInt32(((Label)grd_Dealerdetails.Rows[e.RowIndex].FindControl("lblDealerid")).Text);
            bulksms_bel.Dealerid = Dealerid;
            DateTime localDate = DateTime.Now;
            bulksms_bel.DateRegistered = localDate;
            bulksms_bll.Delete_Dealer_BLL(bulksms_bel);
            lblSuccess.Visible = true;
            lblSuccess.Text = "DealerDetails Deleted Sucessfully...";
            lblSuccess.ForeColor = System.Drawing.Color.Black;
            BindDealerDetails();
        }
        protected void grd_Search_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Dealerid = Convert.ToInt32(((Label)grd_Search.Rows[e.RowIndex].FindControl("lblDealerid")).Text);
            bulksms_bel.Dealerid = Dealerid;
            DateTime localDate = DateTime.Now;
            bulksms_bel.DateRegistered = localDate;
            bulksms_bll.Delete_Dealer_BLL(bulksms_bel);
            lblSuccess.Visible = true;
            lblSuccess.Text = "DealerDetails Deleted Sucessfully...";
            lblSuccess.ForeColor = System.Drawing.Color.Black;
            BindDealerDeleteDetails();
        }

        protected void grd_Search_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_Search.PageIndex = e.NewPageIndex;
            BindSearchGrid();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            GridviewToExcel();
        }
        public void GridviewToExcel()
        {
            string sFileName = "DealerMasterReport_" + DateTime.Now + ".xls";
            var grd_Search = new GridView();
            grd_Search.DataSource = bulksms_bll.DealerMaster_Select_BLL();
            grd_Search.DataBind();
            if (grd_Search.Rows.Count > 0)
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", sFileName));
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grd_Search.RenderControl(htw);
                grd_Search.AllowPaging = true;
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
            else
            {
                //MessageBox1.ShowInfo("No data to export..!", 100, 400);
            }
        }
    }
}