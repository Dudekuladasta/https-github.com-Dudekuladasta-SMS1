using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BulkSMSFacility.DAL;
using BulkSMSFacility.BEL;
using System.Web.Services;

namespace BulkSMSFacility.BLL
{
    public class BulkSMS_BLL
    {
        BulkSMS_DAL bulkSMS_dal = new BulkSMS_DAL();


        public DataTable Login_BLL(string strUsername, string strPassword)
        {
            try
            {
                return bulkSMS_dal.Login_DAL(strUsername, strPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public string InsertUserDetais_BLL(BulkSMS_BEL bulksms_bel)
        //{
        //    try
        //    {
        //        return bulkSMS_dal.InsertUserDetais_DAL(bulksms_bel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public int InsertUserDetais_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.InsertUserDetais_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UserDetails_Select_BLL()
        {
            try
            {
                return bulkSMS_dal.UserDetails_Select_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable UserDetailsselectforupdate_BLL(int Userid)
        {
            try
            {
                return bulkSMS_dal.UserDetailsselectforupdate_DAL(Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Delete_UserDetails_BLL(int Userid)
        {
            try
            {
                return bulkSMS_dal.Delete_UserDetails_DAL(Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Update_UserDetails_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.Update_UserDetails_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DealerLocation_Select_BLL()
        {
            try
            {
                return bulkSMS_dal.DealerLocation_Select_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DealerName_selectwithDealerLocation_BLL(string strDLocation)
        {
            try
            {
                return bulkSMS_dal.DealerName_selectwithDealerLocation_DAL(strDLocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DealerCode_selectwithDealerName_BLL(string strDName)
        {
            try
            {
                return bulkSMS_dal.DealerCode_selectwithDealerName_DAL(strDName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ModelName_Select_BLL()
        {
            try
            {
                return bulkSMS_dal.ModelName_Select_DAL();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable GetGMSalesMobile_BLL(string strDealerLocation, string strDealerName, string strDealerCode, string strDEALERPIC)
        {
            try
            {
                return bulkSMS_dal.GetGMSalesMobile_DAL(strDealerLocation, strDealerName, strDealerCode, strDEALERPIC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertSMSDetails_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.InsertSMSDetails_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertModelDetais_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.InsertModelDetais_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SMSStatus_Select_DAL()
        {
            try
            {
                return bulkSMS_dal.SMSStatus_Select_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string BLL_GetIPAddress(string strIPAddress, string strHostname)
        {
            try
            {
                return bulkSMS_dal.DAL_GetIPAddress(strIPAddress, strHostname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SMSHistorySearch_BLL(string strSMSStatus, string dtFromDate, string dtToDate)
        {
            try
            {
                return bulkSMS_dal.SMSHistorySearch_DAL(strSMSStatus, dtFromDate, dtToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSMSStatus_BLL()
        {
            try
            {
                return bulkSMS_dal.GetSMSStatus_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetStatename_BLL()
        {
            try
            {
                return bulkSMS_dal.GetStatename_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetDealerDetails_BLL()
        {
            try
            {
                return bulkSMS_dal.GetDealerDetails_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDealerRegistrationDetails_BLL()
        {
            try
            {
                return bulkSMS_dal.GetDealerRegistrationDetails_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDealerRegistrationdelete_BLL(string strdealercode)
        {
            try
            {
                return bulkSMS_dal.GetDealerRegistrationdelete_DAL(strdealercode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SearchDealerDetailsbyDealerName_BLL(string strDealercode)
        {
            try
            {
                return bulkSMS_dal.SearchDealerDetailsbyDealerName_DAL(strDealercode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Dealer_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.Delete_Dealer_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SearchDealerID_BLL(int dealerid)
        {
            try
            {
                return bulkSMS_dal.SearchDealerID_DAL(dealerid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insert_DealerDetails_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.Insert_DealerDetails_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Update_DealerDetails_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.Update_DealerDetails_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ModelCodeselectforupdate_BLL(string strmodelcode)
        {
            try
            {
                return bulkSMS_dal.ModelCodeselectforupdate_DAL(strmodelcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Delete_modelcode_BLL(string strmodelcode)
        {
            try
            {
                return bulkSMS_dal.Delete_modelcode_DAL(strmodelcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Update_modelcode_BLL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                return bulkSMS_dal.Update_modelcode_DAL(bulksms_bel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Select_ModelRegisterdetails_BLL(string strmodelcode)
        {
            try
            {
                return bulkSMS_dal.Select_ModelRegisterdetails_DAL(strmodelcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDealerRegistrationUpdatedDetails_BLL()
        {
            try
            {
                return bulkSMS_dal.GetDealerRegistrationUpdatedDetails_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Getuserstatusdetails_BLL()
        {
            try
            {
                return bulkSMS_dal.Getuserstatusdetails_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DealerMaster_Select_BLL()
        {
            try
            {
                return bulkSMS_dal.DealerMaster_Select_DAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}