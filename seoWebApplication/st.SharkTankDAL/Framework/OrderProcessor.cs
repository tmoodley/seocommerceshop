using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject; 

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    /// <summary>
    /// Main class, used to obtain order information,
    /// run pipeline sections, audit orders, etc.
    /// </summary>
    public class OrderProcessor
    {
        internal IPipelineSection CurrentPipelineSection;
        internal bool ContinueNow; 
        internal CommerceLibOrderInfo Order;

        public OrderProcessor(int orderID)
        {
            // get order
            Order = CommerceLibOrderInfo.GetOrder(orderID);
        }
         
        public OrderProcessor(CommerceLibOrderInfo orderToProcess)
        {
            // get order
            Order = orderToProcess;
        }
        public void Process()
        {
            int orderId = Order.OrderID;
            // configure processor
            ContinueNow = true;
            // log start of execution
            CreateAudit(orderId, "Order Processor started.", 10000);
            // process pipeline section
            try
            {
                while (ContinueNow)
                {
                    ContinueNow = false;
                    GetCurrentPipelineSection();
                    CurrentPipelineSection.Process(this,orderId);
                }
            }
            catch (OrderProcessorException ex)
            {
                MailAdmin(orderId, "Order Processing error occurred.", ex.Message, ex.SourceStage);
                CreateAudit(orderId, "Order Processing error occurred.", 10002);
                throw new OrderProcessorException(
                "Error occurred, order aborted. "
                + "Details mailed to administrator.", 100);
            }
            catch (Exception ex)
            {
                MailAdmin(orderId, "Order Processing error occurred.", ex.Message,
                100);
                CreateAudit(orderId, "Order Processing error occurred.", 10002);
                throw new OrderProcessorException(
                "Unknown error, order aborted. "
                + "Details mailed to administrator.", 100);
            }
            finally
            {
                CreateAudit(orderId, "Order Processor finished.", 10001);
            }
        }

        public void CreateAudit(int OrderId, string message, int messageNumber)
        {
            AuditEO audit = new AuditEO();
            audit.Message = message;
            audit.MessageNumber = messageNumber;
            audit.OrderID = OrderId;
            audit.DateStamp = DateTime.Today;
            audit.webstore_id = dBHelper.GetWebstoreId();
            audit.Save(true);
        }

        public void MailAdmin(int OrderId, string subject, string message, int sourceStage)
        {
            OrderProcessorMailer.MailAdmin(OrderId, subject, message, sourceStage);
        }
        private void GetCurrentPipelineSection()
        {
            // select pipeline section to execute based on order status
            // for now just provide a dummy
            CurrentPipelineSection = new PSDummy();
        }
    }
}