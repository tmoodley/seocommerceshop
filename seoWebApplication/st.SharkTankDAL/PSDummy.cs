using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL
{
    /// <summary>
    /// Summary description for PSDummy
    /// </summary>
    public class PSDummy : IPipelineSection
    {
        public void Process(OrderProcessor processor, int orderId)
        {
            processor.CreateAudit(orderId, "PSDoNothing started.", 99999);
            processor.CreateAudit(orderId, "Customer: ", 99999);
            processor.CreateAudit(orderId, "First item in order: ", 99999);
            processor.MailAdmin(orderId, "Test.", "Test mail from PSDummy.", 99999);
            processor.CreateAudit(orderId, "PSDoNothing finished.", 99999);
        }
    }
}