using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BulkSMSFacility.BEL;
using MySql.Data.MySqlClient;
using System.Net;
using System.Web.Services;

namespace BulkSMSFacility.DAL
{
    public class BulkSMS_DAL
    {
        BulkSMS_BEL bulksms_bel = new BulkSMS_BEL();
        MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["test"].ToString());
        MySqlCommand sqlcmd;
        MySqlDataAdapter sqladapter;
        string strIPAddress = string.Empty;
        string strHostname = string.Empty;

       public string DAL_GetIPAddress(string strIPAddress, string strHostname)
       {
        IPHostEntry Host = default(IPHostEntry);
            strHostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(strHostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    strIPAddress = Convert.ToString(IP);
                }
            }
            return strIPAddress;
        }

        public DataTable Login_DAL(string strUsername, string strPassword)
        {
            sqlConn.Open();
            string strlogin = "Select username,Passwrd FROM tbl_userdetails WHERE username ='" + strUsername + "' AND BINARY Passwrd ='" + strPassword + "' AND UserActive='Active'";
            sqlcmd = new MySqlCommand(strlogin, sqlConn);
            sqlcmd.CommandType = CommandType.Text;
            sqladapter = new MySqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("Login");
            sqladapter.Fill(dt);
            return dt;
        }

        public int InsertUserDetais_DAL(BulkSMS_BEL bulksms_bel)
        {
            try
            {

                MySqlCommand cmd_InsertsmsDetails = new MySqlCommand("Proc_InsertUserDetails", sqlConn);
                cmd_InsertsmsDetails.CommandType = CommandType.StoredProcedure;
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_Username", bulksms_bel.UserName);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_Password", bulksms_bel.Password);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_DateRegistered", bulksms_bel.DateRegistered);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_UserActive", bulksms_bel.UserActive);
                sqlConn.Open();
                int i = cmd_InsertsmsDetails.ExecuteNonQuery();
                sqlConn.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable UserDetails_Select_DAL()
        {
            try
            {
                sqlConn.Open();
                MySqlCommand sqlcmd = new MySqlCommand("Proc_UserDetailsSelect", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataTable UserDetailsselectforupdate_DAL(int Userid)
        {
            try
            {
                sqlConn.Open();
                string strmcode = "SELECT username,Passwrd,UserActive FROM tbl_userdetails WHERE Userid = '" + Userid + "'";
                MySqlCommand sqlcmd = new MySqlCommand(strmcode, sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataTable DealerLocation_Select_DAL()
        {
            try
            {
                sqlConn.Open();
                sqlcmd = new MySqlCommand("Proc_DealerLocation_Select", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string Delete_UserDetails_DAL(int Userid)
        {
            string output = "";
            try
            {
                string str = "Update tbl_userdetails set UserActive = 'InActive' WHERE Userid = '" + Userid + "'";
                MySqlCommand cmd_delete = new MySqlCommand(str, sqlConn);
                cmd_delete.CommandType = CommandType.Text;
                sqlConn.Open();
                cmd_delete.ExecuteNonQuery();
                sqlConn.Close();
                output = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return output;
        }
        public string Update_UserDetails_DAL(BulkSMS_BEL bulksms_bel)
        {
            string strOutput = "";
            try
            {
                MySqlCommand cmd_update = new MySqlCommand("Update_Userdetails", sqlConn);
                cmd_update.CommandType = CommandType.StoredProcedure;
                cmd_update.Parameters.AddWithValue("p_Userid", bulksms_bel.Userid);
                cmd_update.Parameters.AddWithValue("p_Username", bulksms_bel.UserName);
                cmd_update.Parameters.AddWithValue("p_Password", bulksms_bel.Password);
                cmd_update.Parameters.AddWithValue("p_userActive", bulksms_bel.UserActive);
                sqlConn.Open();
                cmd_update.ExecuteNonQuery();
                sqlConn.Close();
                strOutput = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strOutput;
        }

        public DataTable DealerName_selectwithDealerLocation_DAL(string strDLocation)
        {
            try
            {
                sqlConn.Open();
                sqlcmd = new MySqlCommand("proc_DealerName_SelectwithLocation", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("p_DealerLocation", strDLocation);
                sqladapter = new MySqlDataAdapter(sqlcmd);
                DataTable dtDealerName = new DataTable();
                sqladapter.Fill(dtDealerName);
                return dtDealerName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable DealerCode_selectwithDealerName_DAL(string strDName)
        {
            try
            {
                sqlConn.Open();
                sqlcmd = new MySqlCommand("proc_DealerCode_SelectwithDName", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("p_DealerName", strDName);
                sqladapter = new MySqlDataAdapter(sqlcmd);
                DataTable dtDealerName = new DataTable();
                sqladapter.Fill(dtDealerName);
                return dtDealerName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

        }

        public DataTable ModelName_Select_DAL()
        {
            try
            {
                sqlConn.Open();
                MySqlCommand sqlcmd = new MySqlCommand("Proc_ModelName_Select", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable GetGMSalesMobile_DAL(string strDealerLocation, string strDealerName, string strDealerCode, string strDEALERPIC)
        {
            try
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                if (strDEALERPIC != string.Empty)
                {
                    string strsql = "Select DealerMobileNumber FROM tbl_DealerMaster WHERE DealerLocation ='" + strDealerLocation + "'AND DealerName ='" + strDealerName + "'AND DealerCode='" + strDealerCode + "' and DealerPIC IN (" + strDEALERPIC + ")";
                    MySqlCommand sqlcmd = new MySqlCommand(strsql, sqlConn);
                    sqlcmd.CommandType = CommandType.Text;
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public int InsertSMSDetails_DAL(BulkSMS_BEL bulksms_bel)
        {
            try
            {

                MySqlCommand cmd_InsertsmsDetails = new MySqlCommand("Proc_Insert_SMSStatus", sqlConn);
                cmd_InsertsmsDetails.CommandType = CommandType.StoredProcedure;
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSText", bulksms_bel.SMSText);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSSender", bulksms_bel.SMSSender);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSSentdateandTime", bulksms_bel.SMSSentdateandTime);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSStatus", bulksms_bel.SMSStatus);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSMobile", bulksms_bel.SMSMobile);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSResponselog", bulksms_bel.SMSResponselog);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_SMSEnquiryNumber", bulksms_bel.SMSEnquiryNumber);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_DealerLocation", bulksms_bel.sDealerLocation);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_DealerName", bulksms_bel.sDealerName);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_DealerCode", bulksms_bel.sDealerCode);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_CustomerTitle", bulksms_bel.sCustomerTitle);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_CustomerName", bulksms_bel.sCustomerName);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_CustomerMobile", bulksms_bel.sCustomerMobile);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_EnquiryType", bulksms_bel.sEnquiryType);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_ModelName", bulksms_bel.sModelName);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_DealerPIC", bulksms_bel.sDealerPIC);
                string Ip = DAL_GetIPAddress(strIPAddress, strHostname);
                cmd_InsertsmsDetails.Parameters.AddWithValue("p_IPaddress", Ip);
                sqlConn.Open();
                int i = cmd_InsertsmsDetails.ExecuteNonQuery();
                sqlConn.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public int InsertModelDetais_DAL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                sqlcmd = new MySqlCommand("PROC_InsertVModelData", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("p_ModelCode", bulksms_bel.ModelCode);
                sqlcmd.Parameters.AddWithValue("p_ModelName", bulksms_bel.ModelName);

                sqlcmd.Parameters.AddWithValue("p_DateRegistered", bulksms_bel.DateRegistered);
                sqlcmd.Parameters.AddWithValue("p_ModelActive", bulksms_bel.ModelActive);

                sqlConn.Open();
                int i = sqlcmd.ExecuteNonQuery();
                sqlConn.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable SMSStatus_Select_DAL()
        {
            try
            {
                sqlConn.Open();
                //MySqlCommand sqlcmd = new MySqlCommand("Select SMSId,SMSSender,SMSMobile,SMSSentdateandTime,SMSStatus,EnquiryType,SMSEnquiryNumber From TBL_SMSStatus", sqlConn);
                //MySqlCommand sqlcmd = new MySqlCommand("Select SMSSender,SMSMobile,SMSSentdateandTime,SMSStatus,EnquiryType,SMSEnquiryNumber,DealerName From TBL_SMSStatus", sqlConn);
                MySqlCommand sqlcmd = new MySqlCommand("SELECT SMSId,SMSSender,SMSSentdateandTime,SMSStatus,SMSMobile,SMSEnquiryNumber,DealerLocation,DealerName,DealerCode,CustomerTitle,CustomerName,CustomerMobile,EnquiryType,ModelName,DealerPIC From TBL_SMSStatus", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }


        public DataTable SMSHistorySearch_DAL(string strSMSStatus, string dtFromDate, string dtToDate)
        {
            try
            {
                sqlConn.Open();
                MySqlCommand sqlcmd = new MySqlCommand("Proc_ViewSMSHistory", sqlConn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("p_SMSStatus", strSMSStatus);
                sqlcmd.Parameters.AddWithValue("p_FromDate", dtFromDate);
                sqlcmd.Parameters.AddWithValue("p_ToDate", dtToDate);
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }





        public DataTable GetSMSStatus_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("Select Distinct(SMSStatus) from tbl_smsstatus", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetStatename_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("Select Stateid,Statename from tbl_state", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDealerDetails_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("SELECT Dealerid,Dealercode,DealerName,DealerLocation,DealerPIC,DealerMobileNumber,EmployeeName,EmployeeCode,DepartmentName FROM tbl_dealermaster where DealerActive = 'Y' order by DealerName asc", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDealerRegistrationDetails_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("SELECT Dealerid,Dealercode,DealerName,DealerLocation,DealerPIC,DealerMobileNumber,EmployeeName,EmployeeCode,DepartmentName FROM tbl_dealermaster where DealerActive = 'Y' order by dealerid desc LIMIT 1", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDealerRegistrationdelete_DAL(string strdealercode)
        {
            try
            {
                sqlcmd = new MySqlCommand("SELECT Dealerid,Dealercode,DealerName,DealerLocation,DealerPIC,DealerMobileNumber,EmployeeName,EmployeeCode,DepartmentName FROM tbl_dealermaster where DealerActive = 'Y' and DealerCode ='" + strdealercode + "'", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchDealerDetailsbyDealerName_DAL(string strDealercode)
        {
            try
            {
                DataTable dt = new DataTable();
                sqlConn.Open();
                string strsql = "SELECT Dealerid,Dealercode,DealerName,DealerLocation,DealerPIC,DealerMobileNumber,EmployeeName,EmployeeCode,DepartmentName FROM tbl_dealermaster where DealerActive = 'Y' and DealerCode = '" + strDealercode + "' order by Dealercode asc";
                MySqlCommand sqlcmd = new MySqlCommand(strsql, sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public int Delete_Dealer_DAL(BulkSMS_BEL bulksms_bel)
        {
            MySqlCommand cmd_delete = new MySqlCommand("delete_Dealer_Proc", sqlConn);
            cmd_delete.CommandType = CommandType.StoredProcedure;
            cmd_delete.Parameters.AddWithValue("p_Dealerid", bulksms_bel.Dealerid);
            cmd_delete.Parameters.AddWithValue("p_DateRegistered", bulksms_bel.DateRegistered);
            sqlConn.Open();
            int i = cmd_delete.ExecuteNonQuery();
            sqlConn.Close();
            return i;
        }

        public DataTable SearchDealerID_DAL(int dealerid)
        {
            string strsql = "SELECT * FROM tbl_dealermaster where Dealerid = '" + dealerid + "'";
            MySqlCommand cmd = new MySqlCommand(strsql, sqlConn);
            cmd.Parameters.AddWithValue("P_Dealerid", bulksms_bel.Dealerid);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Insert_DealerDetails_DAL(BulkSMS_BEL bulksms_bel)
        {
            try
            {
                MySqlCommand cmd_InsertdealerDetails = new MySqlCommand("Proc_InsertDealerDeails", sqlConn);
                cmd_InsertdealerDetails.CommandType = CommandType.StoredProcedure;
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerLocation", bulksms_bel.sDealerLocation);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerCode", bulksms_bel.DealerCode);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerName", bulksms_bel.DealerName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerPIC", bulksms_bel.sDealerPIC);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerMobileNumber", bulksms_bel.DealerMobile);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmployeeName", bulksms_bel.EmployeeName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DepartmentName", bulksms_bel.DepartmentName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmployeeCode", bulksms_bel.EmployeeCode);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmpEmail", bulksms_bel.EmpEmail);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DateRegistered", bulksms_bel.DateRegistered);
                sqlConn.Open();
                int i = cmd_InsertdealerDetails.ExecuteNonQuery();
                sqlConn.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Update_DealerDetails_DAL(BulkSMS_BEL bulksms_bel)
        {
            string output = "";
            try
            {
                MySqlCommand cmd_InsertdealerDetails = new MySqlCommand("Proc_Updatedealerdetails", sqlConn);
                cmd_InsertdealerDetails.CommandType = CommandType.StoredProcedure;
                cmd_InsertdealerDetails.Parameters.AddWithValue("P_Dealerid", bulksms_bel.Dealerid);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerLocation", bulksms_bel.sDealerLocation);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerCode", bulksms_bel.DealerCode);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerName", bulksms_bel.DealerName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerPIC", bulksms_bel.sDealerPIC);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DealerMobileNumber", bulksms_bel.DealerMobile);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmployeeName", bulksms_bel.EmployeeName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DepartmentName", bulksms_bel.DepartmentName);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmployeeCode", bulksms_bel.EmployeeCode);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_EmpEmail", bulksms_bel.EmpEmail);
                cmd_InsertdealerDetails.Parameters.AddWithValue("p_DateRegistered", bulksms_bel.DateRegistered);
                sqlConn.Open();
                cmd_InsertdealerDetails.ExecuteNonQuery();
                sqlConn.Close();
                output = "0";
            }
            catch (Exception ex)
            {
                output = ex.ToString();
            }
            return output;
        }
        public DataTable ModelCodeselectforupdate_DAL(string strmodelcode)
        {
            try
            {
                sqlConn.Open();
                string strmcode = "SELECT ModelCode,ModelName FROM tbl_ModelMaster WHERE ModelCode = '" + strmodelcode + "'";
                MySqlCommand sqlcmd = new MySqlCommand(strmcode, sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string Delete_modelcode_DAL(string strmodelcode)
        {
            string output = "";
            try
            {
                string str = "Update tbl_ModelMaster set ModelActive = 'N' WHERE ModelCode = '" + strmodelcode + "'";
                MySqlCommand cmd_delete = new MySqlCommand(str, sqlConn);
                cmd_delete.CommandType = CommandType.Text;
                cmd_delete.Parameters.AddWithValue(strmodelcode, bulksms_bel.ModelCode);
                sqlConn.Open();
                cmd_delete.ExecuteNonQuery();
                sqlConn.Close();
                output = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return output;
        }

        public string Update_modelcode_DAL(BulkSMS_BEL bulksms_bel)
        {
            string output = "";
            try
            {
                MySqlCommand cmd_update = new MySqlCommand("Update_Modelmasterdetails", sqlConn);
                cmd_update.CommandType = CommandType.StoredProcedure;
                cmd_update.Parameters.AddWithValue("p_ModelCode", bulksms_bel.ModelCode);
                cmd_update.Parameters.AddWithValue("p_ModelName", bulksms_bel.ModelName);
                sqlConn.Open();
                cmd_update.ExecuteNonQuery();
                sqlConn.Close();
                output = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return output;
        }

        public bool Select_ModelRegisterdetails_DAL(string strmodelcode)
        {
            try
            {
                string strmodelselect = "SELECT ModelCode FROM tbl_modelmaster WHERE ModelCode = '" + strmodelcode + "'";
                MySqlCommand cmd = new MySqlCommand(strmodelselect, sqlConn);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                MySqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDealerRegistrationUpdatedDetails_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("SELECT Dealerid,Dealercode,DealerName,DealerLocation,DealerPIC,DealerMobileNumber,EmployeeName,EmployeeCode,DepartmentName FROM tbl_dealermaster where DealerActive = 'Y' order by DateRegistered desc LIMIT 1", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Getuserstatusdetails_DAL()
        {
            try
            {
                sqlcmd = new MySqlCommand("Select * from tbl_statususer", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DealerMaster_Select_DAL()
        {
            try
            {
                sqlConn.Open();
                MySqlCommand sqlcmd = new MySqlCommand("SELECT Dealerid,DealerName,DealerCode,DealerLocation,EmployeeName,EmployeeCode,DealerMobileNumber,DepartmentName,DealerPIC,EmpEmail,DealerActive FROM tbl_dealermaster", sqlConn);
                sqlcmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
