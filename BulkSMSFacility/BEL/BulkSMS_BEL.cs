using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulkSMSFacility.BEL
{
    public class BulkSMS_BEL
    {
        #region "Login Properties"
        public int Userid { get; set; }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string UserActive
        {
            get;
            set;
        }
        #endregion "Login Properties"

        #region "Dealer Properties"

        public int Dealerid { get; set; }
        public string DealerCode
        {
            get;
            set;
        }
        public string GroupCode
        {
            get;
            set;
        }
        public string DealerName
        {
            get;
            set;
        }
        //public string DealerLocation 
        //{ 
        //    get; 
        //    set; 
        //}
        public string DealerCity
        {
            get;
            set;
        }
        public string DealerMobile
        {
            get;
            set;
        }
        public string DealerActive
        {
            get;
            set;
        }
        public DateTime DateRegistered
        {
            get;
            set;
        }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmpEmail { get; set; }
        #endregion "Dealer Properties"

        #region "SMSStatusDetails"
        public int SMSId { get; set; }
        public string SMSText { get; set; }
        public string SMSSender { get; set; }
        public DateTime SMSSentdateandTime { get; set; }
        public string SMSStatus { get; set; }
        public string SMSMobile { get; set; }
        public string SMSResponselog { get; set; }
        public string SMSEnquiryNumber { get; set; }
        public string sDealerLocation { get; set; }
        public string sDealerName { get; set; }
        public string sDealerCode { get; set; }
        public string sCustomerTitle { get; set; }
        public string sCustomerName { get; set; }
        public string sCustomerMobile { get; set; }
        public string sEnquiryType { get; set; }
        public string sModelName { get; set; }
        public string sDealerPIC { get; set; }
        public string IPadress { get; set; }

        #endregion "SMSStatusDetails"

        #region "ModelRegistrationProperties"
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string ModelActive { get; set; }
        #endregion "ModelRegistrationProperties"

        #region "IPAddressProperties"
        public string IPAddress { get; set; }
        public string Hostname { get; set; }
        #endregion "ModelRegistrationProperties"

        #region "SMSHistoryScreen"
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        #endregion "SMSHistoryScreen"
    }
}