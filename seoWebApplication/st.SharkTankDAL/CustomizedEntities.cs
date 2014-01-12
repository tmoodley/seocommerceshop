using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL.Framework;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using System.Data.Linq.Mapping;

namespace seoWebApplication.st.SharkTankDAL
{
    public partial class product : IENTBaseEntity { }
    public partial class department : IENTBaseEntity { }
    public partial class category : IENTBaseEntity { }
    public partial class UserAccount : IENTBaseEntity { }
    public partial class Attribute : IENTBaseEntity { }
    public partial class AttributeValue : IENTBaseEntity { }
    public partial class ProductAttributeValue : IENTBaseEntity { }
    public partial class webstore : ISEOBaseEntity { }
    public partial class zone : ISEOBaseEntity { }
    public partial class city : ISEOBaseEntity { }
    public partial class state : ISEOBaseEntity { }
    public partial class country : ISEOBaseEntity { }
    public partial class cuisine : ISEOBaseEntity { }
    public partial class review : ISEOBaseEntity { }
    public partial class points : ISEOBaseEntity { }
}
