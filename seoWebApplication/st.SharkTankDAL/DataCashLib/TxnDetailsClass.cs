using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class TxnDetailsClass
    {
        [XmlElement("merchantreference")]
        public string MerchantReference;
        [XmlElement("amount")]
        public AmountClass Amount = new AmountClass();
    }
}