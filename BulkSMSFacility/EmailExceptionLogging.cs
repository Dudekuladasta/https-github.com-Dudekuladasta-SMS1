using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using context = System.Web.HttpContext;

namespace BulkSMSFacility
{
    
    public static class EmailExceptionLogging
    {
        private static string strErrorlineNo, strErrormsg, strErrorLocation, strPassword, strextype, strexurl, strFrommail, strToMail, strSub, strHostAdd, strEmailHead, strEmailSing;
        
        public static void SendErrorTomail(Exception exmail)
        {
            try
            {
                var newline = "<br/>";
                strErrorlineNo = exmail.StackTrace.Substring(exmail.StackTrace.Length - 6, 6);
                strErrormsg = exmail.GetType().Name.ToString();
                strextype = exmail.GetType().ToString();
                strexurl = context.Current.Request.Url.ToString();
                strErrorLocation = exmail.Message.ToString();
                strEmailHead = "<b>Dear Team,</b>" + "<br/>" + "An exception occurred in a Application Url" + " " + strexurl + " " + "With following Details" + "<br/>" + "<br/>";
                strEmailSing = newline + "Thanks & Regards" + newline + "    " + "     " + "<b>Application Admin </b>" + "</br>";
                strSub = "Exception occurred" + " " + "in Application" + " " + strexurl;
                strHostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string errortomail = strEmailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString() + newline + "<b>Error Line No :</b>" + " " + strErrorlineNo + "\t\n" + " " + newline + "<b>Error Message:</b>" + " " + strErrormsg + newline + "<b>Exception Type:</b>" + " " + strextype + newline + "<b> Error Details :</b>" + " " + strErrorLocation + newline + "<b>Error Page Url:</b>" + " " + strexurl + newline + newline + newline + newline + strEmailSing;

                using (MailMessage mailMessage = new MailMessage())
                {
                    strFrommail = ConfigurationManager.AppSettings["FromMail"].ToString();
                    strToMail = ConfigurationManager.AppSettings["ToMail"].ToString();
                    strSub = ConfigurationManager.AppSettings["Subject"].ToString();
                    strPassword = ConfigurationManager.AppSettings["Password"].ToString();

                    mailMessage.From = new MailAddress(strFrommail);
                    mailMessage.Subject = strSub;
                    mailMessage.Body = errortomail;
                    mailMessage.IsBodyHtml = true;

                    string[] MultiEmailId = strToMail.Split(',');
                    foreach (string userEmails in MultiEmailId)
                    {
                        mailMessage.To.Add(new MailAddress(userEmails));
                    }

                    SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                    smtp.Host = strHostAdd;              //host of emailaddress for example smtp.gmail.com etc  
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = mailMessage.From.Address;
                    NetworkCred.Password = strPassword;  
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mailMessage); //sending Email

                }  

            }
            catch (Exception emailexception)
            {
                emailexception.ToString();
            }
        }
    }
}