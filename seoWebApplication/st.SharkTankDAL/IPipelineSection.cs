using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL
{
    /// <summary>
    /// Standard interface for pipeline sections
    /// </summary>
    public interface IPipelineSection
    {
        void Process(OrderProcessor processor, int orderId);
    }
}
