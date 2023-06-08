using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using System.Drawing;

namespace BulkSMSFacility.Admin
{
    public partial class ViewSMSHistory : System.Web.UI.Page
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
                    Lbl_Welcome.Text = "<b><font color=Brown>" + "WELCOME: " + "</font>" + "<b><font color=Green>" + Session["username"] + "</font>";
                }
                Bind_grdSMSHistory();
                BindSMSStatus();
                btn_ExportExcel.Visible = false;
                grd_search.Visible = false;
            }
        }
        public void Bind_grdSMSHistory()
        {
            grd_SMSHistory.DataSource = bulksms_bll.SMSStatus_Select_DAL();
            grd_SMSHistory.DataBind();
            DataTable tbl = grd_SMSHistory.DataSource as DataTable;
            lbl_Count.Text = "Number of Records : " + tbl.Rows.Count.ToString();
            lbl_Count.Visible = true;
        }
        protected void grd_SMSHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_SMSHistory.PageIndex = e.NewPageIndex;
            Bind_grdSMSHistory();
            grd_SMSHistory.DataBind();
        }
        public void GetSMSHistoryData()
        {
            lbl_Count.Visible = false;
            if (ddl_Status.SelectedIndex != 0)
            {
                bulksms_bel.SMSStatus = ddl_Status.SelectedItem.Text;
            }
            else
            {
                MessageBox1.ShowInfo("Please select status..!", 100, 400);
                btn_ExportExcel.Visible = false;
            }
            if (txt_FromDate.Text != "" && txt_Todate.Text != "" || txt_FromDate.Text != "" && txt_Todate.Text != "")
            {
                DateTime dtfrmdate = Convert.ToDateTime(txt_FromDate.Text);
                DateTime dttodate = Convert.ToDateTime(txt_Todate.Text);

                if (dtfrmdate <= dttodate)
                {

                    bulksms_bel.FromDate = txt_FromDate.Text;
                    bulksms_bel.ToDate = txt_Todate.Text;
                    grd_search.DataSource = bulksms_bll.SMSHistorySearch_BLL(ddl_Status.SelectedItem.Text, txt_FromDate.Text, txt_Todate.Text);
                    grd_search.DataBind();
                    DataTable tbl = grd_search.DataSource as DataTable;
                    lbl_Count.Text = "Number of Records : " + tbl.Rows.Count.ToString();
                    lbl_Count.ForeColor = System.Drawing.Color.Black;
                    lbl_Count.Visible = true;
                    if (tbl.Rows.Count <= 0)
                    {
                        btn_ExportExcel.Visible = false;
                        btn_Exportalldata.Visible = false;
                    }
                }
                else
                {
                    btn_ExportExcel.Visible = false;
                    btn_Exportalldata.Visible = false;
                    MessageBox1.ShowInfo("FromDate cannot be greater than ToDate..!", 100, 400);
                }
            }
            else
            {
                MessageBox1.ShowInfo("Please select FromDate and ToDate..!", 100, 400);
                btn_ExportExcel.Visible = false;
            }
        }
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            grd_search.Visible = true;
            grd_SMSHistory.Visible = false;
            btn_ExportExcel.Visible = true;
            btn_Exportalldata.Visible = false;

            GetSMSHistoryData();
        }
        public void BindSMSStatus()
        {
            ddl_Status.DataSource = bulksms_bll.GetSMSStatus_BLL();
            ddl_Status.DataTextField = "SMSStatus";
            ddl_Status.DataValueField = "";
            ddl_Status.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "--Choose SMS Status--";
            lstitem.Value = "0";
            ddl_Status.Items.Insert(0, lstitem);
        }
        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            GridviewToExcel();
        }
        public void GridviewToExcel()
        {
            string sFileName = "SMSDeliveryReport_" + DateTime.Now + ".xls";
            bulksms_bel.SMSStatus = ddl_Status.SelectedItem.Text;
            if (txt_FromDate.Text != null || txt_Todate.Text != null)
            {
                bulksms_bel.FromDate = txt_FromDate.Text;
                bulksms_bel.ToDate = txt_Todate.Text;
            }
            else
            {
                MessageBox1.ShowInfo("Please select FromDate or ToDate..!", 100, 400);
            }
            var grd_search = new GridView();
            grd_search.DataSource = bulksms_bll.SMSHistorySearch_BLL(ddl_Status.SelectedItem.Text, txt_FromDate.Text, txt_Todate.Text);
            grd_search.DataBind();
            if (grd_search.Rows.Count > 0)
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", sFileName));
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grd_search.RenderControl(htw);
                grd_search.AllowPaging = true;
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
            else
            {
                MessageBox1.ShowInfo("No data to export..!", 100, 400);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btn_Exportalldata_Click(object sender, EventArgs e)
        {
            string sFileName = "SMSDeliveryReport_" + DateTime.Now + ".xls";
            var grd_SMSHistory = new GridView();
            grd_SMSHistory.DataSource = bulksms_bll.SMSStatus_Select_DAL();
            grd_SMSHistory.DataBind();
            if (grd_SMSHistory.Rows.Count > 0)
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", sFileName));
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grd_SMSHistory.RenderControl(htw);
                grd_SMSHistory.AllowPaging = true;
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
            else
            {
                MessageBox1.ShowInfo("No data to export..!", 100, 400);
            }
        }

        protected void grd_search_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_search.PageIndex = e.NewPageIndex;
            GetSMSHistoryData();
        }
    }
}
