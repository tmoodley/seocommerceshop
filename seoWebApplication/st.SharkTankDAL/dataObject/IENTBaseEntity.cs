using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    public interface IENTBaseEntity
    {
        DateTime InsertDate { get; set; }
        int InsertENTUserAccountId { get; set; }
        DateTime UpdateDate { get; set; }
        int UpdateENTUserAccountId { get; set; }
        Binary Version { get; set; }   
    }
}
