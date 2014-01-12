using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class ReturnProductsResult
    {
        [XmlElement("Product")]
        public string Product;
        [XmlElement("product_id")]
        public string product_id;
        [XmlElement("name")]
        public string name;

    }
}
