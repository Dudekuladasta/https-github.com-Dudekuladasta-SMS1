using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulkSMSFacility.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    Lbl_Welcome.Text = "<b><font color=Brown>" + "WELCOME: " + "</font>" + "<b><font color=red>" + Session["username"] + "</font>";
                }
            }
        }
    }
}