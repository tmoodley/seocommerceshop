using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    /// <summary>
    /// Mailing utilities for OrderProcessor
    /// </summary>
    public static class OrderProcessorMailer
    {
        public static void MailAdmin(int orderID, string subject, string message, int sourceStage)
        {
            // Send mail to administrator
            string to = seoWebAppConfiguration.ErrorLogEmail;
            string from = seoWebAppConfiguration.OrderProcessorEmail;
            string body = "Message: " + message
            + "\nSource: " + sourceStage.ToString()
            + "\nOrder ID: " + orderID.ToString();
            //Utilities.SendMail(from, to, subject, body);
        }
    }
}