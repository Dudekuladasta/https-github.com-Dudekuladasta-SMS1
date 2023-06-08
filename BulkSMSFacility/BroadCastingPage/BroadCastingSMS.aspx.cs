using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulkSMSFacility.BLL;
using BulkSMSFacility.BEL;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;

namespace BulkSMSFacility.BroadCastingPage
{
    public partial class BroadCastingSMS : System.Web.UI.Page
    {
        BulkSMS_BEL bulkSMS_bel = new BulkSMS_BEL();
        BulkSMS_BLL bulkSMS_bll = new BulkSMS_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDealerLocation();
                GetCustomerDealerLocation();
                GetModelNames();
                ddl_DealerName.Enabled = false;
                ddl_DealerCode.Enabled = false;
                UpdateCustomerPanel.Visible = false;
            }
        }
        public void GetDealerLocation()
        {
            ddl_DealerLocation.DataSource = bulkSMS_bll.DealerLocation_Select_BLL();
            ddl_DealerLocation.DataTextField = "DealerLocation";
            ddl_DealerLocation.DataValueField = "";
            ddl_DealerLocation.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Location";
            lstitem.Value = "0";
            ddl_DealerLocation.Items.Insert(0, lstitem);
        }
        public void GetDealerName()
        {
            ddl_DealerName.DataSource = bulkSMS_bll.DealerName_selectwithDealerLocation_BLL(ddl_DealerLocation.SelectedItem.Text);
            ddl_DealerName.DataTextField = "DealerName";
            ddl_DealerName.DataValueField = "";
            ddl_DealerName.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Name";
            lstitem.Value = "0";
            lstitem.Enabled = true;
            ddl_DealerName.Items.Insert(0, lstitem);
        }
        protected void ddl_DealerLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDealerName();
            ddl_DealerName.Enabled = true;
            GetDealerCode();
        }
        public void GetModelNames()
        {
            ddl_ModelName.DataSource = bulkSMS_bll.ModelName_Select_BLL();
            ddl_ModelName.DataTextField = "ModelName";
            ddl_ModelName.DataValueField = "ModelCode";
            ddl_ModelName.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Model Name";
            lstitem.Value = "0";
            ddl_ModelName.Items.Insert(0, lstitem);
        }
        public void GetDealerCode()
        {
            ddl_DealerCode.DataSource = bulkSMS_bll.DealerCode_selectwithDealerName_BLL(ddl_DealerName.SelectedItem.Text);
            ddl_DealerCode.DataTextField = "DealerCode";
            ddl_DealerCode.DataValueField = "";
            ddl_DealerCode.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Code";
            lstitem.Value = "0";
            ddl_DealerCode.Items.Insert(0, lstitem);
        }
        protected void ddl_DealerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDealerCode();
            ddl_DealerCode.Enabled = true;
        }
        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
            string strDealercode = "";
            string strDealerLocation = "";
            string strModel = "";
            string strDealerName = "";
            string strCustomerTitle = "";
            DataTable dtMobileNumbers = new DataTable();
            if (ddl_DealerCode.SelectedIndex != -1)
            {
                strDealercode = ddl_DealerCode.SelectedItem.Text;
            }
            string strCustomerName = txt_CustName.Text;
            string strCustomerMobile = txt_CustMobile.Text;
            string strOthersMobile = txt_OthersMobile.Text;
            if (ddl_ModelName.SelectedIndex != 0)
            {
                strModel = ddl_ModelName.SelectedItem.Text;
            }
            string strEnquiryNumber = txtEnquiryNum.Text;
            if (ddl_DealerLocation.SelectedIndex != 0)
            {
                strDealerLocation = ddl_DealerLocation.SelectedItem.Text;
            }
            if (ddl_DealerName.SelectedIndex != -1)
            {
                strDealerName = ddl_DealerName.SelectedItem.Text;
            }
            if (ddl_Title.SelectedIndex != 0)
            {
                strCustomerTitle = ddl_Title.SelectedItem.Text;
            }

            string strAPIKey = "A7336b9df5c9c7cf0ba324721f6a790f1";
            string strSender = "TOYOTA";
            string strformat = "xml";
            string strMethod = "sms";
            string strdeliveryreport = "";
            DateTime localDate = DateTime.Now;
            string strEntquiryType = "";
            string strcheckGM = "";
            try
            {
                foreach (ListItem item in chk_DealerPIC.Items)
                {
                    if (item.Selected)
                        strcheckGM += "'" + item.Text + "'" + ",";
                }
                strcheckGM = strcheckGM.TrimEnd(',');

                foreach (ListItem itemtype in chk_EnquiryType.Items)
                {
                    if (itemtype.Selected)
                        strEntquiryType += itemtype.Text + "/";
                }
                strEntquiryType = strEntquiryType.Trim('/');

                if (strDealerLocation != "" && strDealerName != "" && strDealercode != "" && strcheckGM != "")
                {
                    dtMobileNumbers = bulkSMS_bll.GetGMSalesMobile_BLL((ddl_DealerLocation.SelectedItem.Text), (ddl_DealerName.SelectedItem.Text),
                               (ddl_DealerCode.SelectedItem.Text), strcheckGM);

                }
                string commaSeparatedString = String.Join(",", dtMobileNumbers.AsEnumerable().Select(x => x.Field<string>("DealerMobileNumber").ToString()).ToArray());

                commaSeparatedString = commaSeparatedString + "," + strOthersMobile;

                commaSeparatedString = commaSeparatedString.TrimStart(',').TrimEnd(',');


                if (commaSeparatedString != null && commaSeparatedString != "" && strDealerLocation != "" && strDealerName != "" && strDealercode != "")
                {
                    
                    StringBuilder smsMessage = new StringBuilder();
                    smsMessage.Append("Dear Sir/Madam,");
                    smsMessage.Append("\n");
                    smsMessage.Append("Enquiry has been registered to your dealership");
                    smsMessage.Append("\n");
                    smsMessage.Append("Enquiry Type   : " + strEntquiryType + "\n");
                    smsMessage.Append("Dealer Code    : " + strDealercode + "\n");
                    smsMessage.Append("Customer Name : " + strCustomerName + "\n");
                    smsMessage.Append("Customer No    : " + strCustomerMobile + "\n");
                    smsMessage.Append("Model Name     : " + strModel + "\n");
                    smsMessage.Append("Request to contact the customer within 2 hours.");
                    string strMessage = smsMessage.ToString();
                    /* API URL */

                    //string strUrl = "https://alerts.solutionsinfini.com/api/v4/?api_key=" + strAPIKey + "&method=" + strMethod + "&message=" + strMessage + "&to=" + commaSeparatedString + "&sender=" + strSender + "&format=" + strformat + "&dlrurl =" + strdeliveryreport;
                    string strUrl = "https://bankalerts.solutionsinfini.com/api/v4/?api_key=" + strAPIKey + "&method=" + strMethod + "&message=" + strMessage + "&to=" + commaSeparatedString + "&sender=" + strSender + "&format=" + strformat + "&dlrurl =" + strdeliveryreport;
                    HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(strUrl);
                    HttpWebResponse httpResp = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader respStreamReader = new StreamReader(httpResp.GetResponseStream());
                    string responseString = respStreamReader.ReadToEnd();
                    respStreamReader.Close();
                    httpResp.Close();
                    #region "path for logs"

                    if (responseString != null)
                    {
                        string path = @"E:\Log Files\";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = path + "Log_TKMSMS " + DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
                        if (!File.Exists(path))
                        {
                            File.Create(path).Dispose();
                        }
                        using (StreamWriter writer = File.AppendText(path))
                        {
                            string strmsg = "\r\nLog written at : " + DateTime.Now.ToString();
                            writer.WriteLine(strmsg);
                            writer.WriteLine(responseString);
                            writer.WriteLine("==========================================");
                            writer.Flush();
                            writer.Close();
                        }
                    }

                    #endregion "path for logs"
                    try
                    {
                        XmlDocument xd = new XmlDocument();
                        xd.LoadXml(responseString);
                        System.Xml.Linq.XDocument xd1 = System.Xml.Linq.XDocument.Parse(responseString);
                        string strStatuscode = xd1.Root.Element("status").Value;
                        string strM = "";

                        switch (strStatuscode)
                        {
                            case "OK":
                                if (strStatuscode == "OK")
                                    strM = "DELIVERED";
                                MessageBox1.ShowSuccess("SMS delivered successully..!", 100, 400);
                                break;
                            case "E612":
                                if (strStatuscode == "E612")
                                    strM = "Invalid Template Matched...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "E605":
                                if (strStatuscode == "E605")
                                    strM = "Invalid Sender or Sender not allowed...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "DNDNUMB":
                                if (strStatuscode == "DNDNUMB")
                                    strM = "DND registered number...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "A401A":
                                if (strStatuscode == "A401A")
                                    strM = "Method Not Implemented...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "A400":
                                if (strStatuscode == "A400")
                                    strM = "API Not Implemented...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "ABSENT-SUB":
                                if (strStatuscode == "ABSENT-SUB")
                                    strM = "Mobile Subscriber not reachable...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "INVALID-SUB":
                                if (strStatuscode == "INVALID-SUB")
                                    strM = "Number does not exist...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "FAILED":
                                if (strStatuscode == "FAILED")
                                    strM = "SMS expired due to roaming limitation...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "REJECTED":
                                if (strStatuscode == "REJECTED")
                                    strM = "SMS Rejected as the number is blacklisted by operator...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "UNDELIV":
                                if (strStatuscode == "UNDELIV")
                                    strM = "Failed due to network errors...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "HANDSET-BUSY":
                                if (strStatuscode == "HANDSET-BUSY")
                                    strM = "Subscriber is in busy condition...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "MEMEXEC":
                                if (strStatuscode == "MEMEXEC")
                                    strM = "Handset memory full...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "SERVER-ERR":
                                if (strStatuscode == "SERVER-ERR")
                                    strM = "Server Error...!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "H601":
                                if (strStatuscode == "H601")
                                    strM = "Insufficient credits..!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "INV-NUMBER":
                                if (strStatuscode == "INV-NUMBER")
                                    strM = "Invalid Number..!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "SPAM":
                                if (strStatuscode == "SPAM")
                                    strM = "Spam SMS..!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "BLACKLIST":
                                if (strStatuscode == "BLACKLIST")
                                    strM = "Blacklisted Number..!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            case "SERIES-BLOCK":
                                if (strStatuscode == "SERIES-BLOCK")
                                    strM = "Mobile number series blocked..!";
                                MessageBox1.ShowSuccess(strM, 100, 400);
                                break;
                            default:
                                break;

                        }
                        bulkSMS_bel.SMSText = strMessage;
                        bulkSMS_bel.SMSSender = strSender;
                        bulkSMS_bel.SMSSentdateandTime = localDate;
                        bulkSMS_bel.SMSStatus = strM;
                        bulkSMS_bel.SMSMobile = commaSeparatedString;
                        bulkSMS_bel.SMSResponselog = responseString;
                        bulkSMS_bel.SMSEnquiryNumber = strEnquiryNumber;
                        bulkSMS_bel.sDealerLocation = strDealerLocation;
                        bulkSMS_bel.sDealerName = strDealerName;
                        bulkSMS_bel.sCustomerName = strCustomerName;
                        bulkSMS_bel.sDealerCode = strDealercode;
                        bulkSMS_bel.sCustomerTitle = strCustomerTitle;
                        bulkSMS_bel.sCustomerName = strCustomerName;
                        bulkSMS_bel.sCustomerMobile = strCustomerMobile;
                        bulkSMS_bel.sEnquiryType = strEntquiryType;
                        bulkSMS_bel.sModelName = strModel;
                        bulkSMS_bel.sDealerPIC = strcheckGM;

                        int insertsmsDetails = bulkSMS_bll.InsertSMSDetails_BLL(bulkSMS_bel);

                    }
                    catch (Exception ex)
                    {
                        EmailExceptionLogging.SendErrorTomail(ex);
                        ErrorLogging.LogErrorToLogFile(ex, "An error occured.");
                    }
                    ResetFields();
                }
                else
                {
                    MessageBox1.ShowInfo("Please select any Dealer PIC or Mobile number to send SMS..!", 100, 400);
                }
            }
            catch (WebException ex)
            {
                string strex = ex.ToString();
                MessageBox1.ShowInfo("Internet should be enable", 100, 400);
                ResetFields();
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        public void ResetFields()
        {
            txt_OthersMobile.Text = string.Empty;
            txt_CustName.Text = string.Empty;
            txt_CustMobile.Text = string.Empty;
            ddl_DealerLocation.SelectedIndex = 0;
            ddl_DealerName.Items.Clear();
            ddl_DealerCode.Items.Clear();
            ddl_DealerName.Enabled = false;
            ddl_DealerCode.Enabled = false;
            chk_DealerPIC.ClearSelection();
            chk_EnquiryType.ClearSelection();
            //for (int items = 0; items < chk_DealerPIC.Items.Count; items++)
            //{
            //    chk_DealerPIC.ClearSelection();
            //}
            //for (int items = 0; items < chk_EnquiryType.Items.Count; items++)
            //{
            //    chk_EnquiryType.ClearSelection();
            //}
            ddl_ModelName.SelectedIndex = 0;
            ddl_Title.SelectedIndex = 0;
            txtEnquiryNum.Text = string.Empty;
        }


        public void GetCustomerDealerLocation()
        {
            ddl_CustDealerLocation.DataSource = bulkSMS_bll.DealerLocation_Select_BLL();
            ddl_CustDealerLocation.DataTextField = "DealerLocation";
            ddl_CustDealerLocation.DataValueField = "";
            ddl_CustDealerLocation.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Location";
            lstitem.Value = "0";
            ddl_CustDealerLocation.Items.Insert(0, lstitem);
        }
        public void GetCustomerDealerName()
        {
            ddl_CustDealerName.DataSource = bulkSMS_bll.DealerName_selectwithDealerLocation_BLL(ddl_CustDealerLocation.SelectedItem.Text);
            ddl_CustDealerName.DataTextField = "DealerName";
            ddl_CustDealerName.DataValueField = "";
            ddl_CustDealerName.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Name";
            lstitem.Value = "0";
            lstitem.Enabled = true;
            ddl_CustDealerName.Items.Insert(0, lstitem);
        }
        public void GetCustDealerCode()
        {
            ddl_CustDealerCode.DataSource = bulkSMS_bll.DealerCode_selectwithDealerName_BLL(ddl_CustDealerName.SelectedItem.Text);
            ddl_CustDealerCode.DataTextField = "DealerCode";
            ddl_CustDealerCode.DataValueField = "";
            ddl_CustDealerCode.DataBind();
            ListItem lstitem = new ListItem();
            lstitem.Text = "Choose Dealer Code";
            lstitem.Value = "0";
            ddl_CustDealerCode.Items.Insert(0, lstitem);
        }

        protected void btn_sendCustomerSMS_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_CustDealerLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            UU1.Visible = false;
            GetCustomerDealerName();
            ddl_CustDealerName.Enabled = true;
            GetCustDealerCode();
        }

        protected void ddl_CustDealerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustDealerCode();
            ddl_CustDealerCode.Enabled = true;
        }
    }
}
