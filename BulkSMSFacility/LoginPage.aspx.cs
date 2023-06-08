using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BulkSMSFacility.BEL;
using BulkSMSFacility.BLL;
using System.Web.Security;

namespace BulkSMSFacility
{
    public partial class LoginPage : System.Web.UI.Page
    {
        BulkSMS_BEL bulksms_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulksms_bll = new BulkSMS_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dtlogin = bulksms_bll.Login_BLL(Txt_uname.Text.Trim(), Txt_pwd.Text.Trim());

            if (dtlogin.Rows.Count > 0)
            {
                string Username = dtlogin.Rows[0]["username"].ToString();
                if (Username != "" || Username != null)
                {
                    Session["username"] = dtlogin.Rows[0]["username"].ToString();
                    Response.Redirect(@"Admin\ViewSMSHistory.aspx", true);
                }
                else
                {
                    lblstatus.Text = "Invalid Username and Password";
                }
                lblstatus.Visible = false;
            }
            else
            {
                lblstatus.Visible = true;
                lblstatus.Text = "Invalid Username and Password";
            }
        }
    }
}