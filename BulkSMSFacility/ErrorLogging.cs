using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using context = System.Web.HttpContext;

namespace BulkSMSFacility
{
    public class ErrorLogging
    {
        public static string LogErrorToLogFile(Exception ee, string userFriendlyError)
        {
            try
            {
                //string path = context.Current.Server.MapPath("~/ErrorLogging/");
                string path = @"D:\Log Files\";
                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "ErrorLog - " + DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {
                    string error = "\r\nLog written at : " + DateTime.Now.ToString() +
                                   "\r\nError occured on page : " + context.Current.Request.Url.ToString() +
                                   "\r\n\r\nHere is the actual error :\n" + ee.ToString();
                    writer.WriteLine(error);
                    writer.WriteLine("==========================================");
                    writer.Flush();
                    writer.Close();
                }
                return userFriendlyError;
            }
            catch
            {
                throw;
            }
        }
    }
}