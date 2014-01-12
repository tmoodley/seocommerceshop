using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class AmountClass
    {
        [XmlAttribute("currency")]
        public string Currency;
        [XmlText()]
        public string Amount;
    }
}
