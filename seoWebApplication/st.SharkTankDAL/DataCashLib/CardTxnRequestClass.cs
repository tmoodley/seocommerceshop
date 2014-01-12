using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class CardTxnRequestClass
    {
        [XmlElement("method")]
        public string Method;
        [XmlElement("Card")]
        public CardClass Card = new CardClass();
    }
}
