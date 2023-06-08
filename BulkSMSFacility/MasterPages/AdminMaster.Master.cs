using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulkSMSFacility.MasterPages
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string Username = Session["username"].ToString();

                if (Username == "Admin")
                {
                    admin1.Visible = true;
                    admin2.Visible = true;
                    admin3.Visible = true;
                    admin4.Visible = true;
                    //admin5.Visible = true;
                    admin6.Visible = true;
                    // admin7.Visible = true;

                    Response.Expires = 0;
                    Response.Cache.SetNoStore();
                    Response.AppendHeader("Pragma", "no-cache");

                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");

                }
            }
            else
            {
                Response.Redirect(@"..\LoginPage.aspx", true);
            }
        }
    }
}