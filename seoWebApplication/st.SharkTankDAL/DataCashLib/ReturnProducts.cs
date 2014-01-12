using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class ReturnProductsClass
    {
        [XmlElement("ReturnProducts",Namespace = "devArticles")]
        public string ReturnProducts;

        [XmlElement("soap")]
        public string soap;

        
  
    }
}
