using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class ReturnProductsResponseClass
    { 
        [XmlElement("product_id")]
        public string product_id;
        [XmlElement("name")]
        public string name;
    }
}
