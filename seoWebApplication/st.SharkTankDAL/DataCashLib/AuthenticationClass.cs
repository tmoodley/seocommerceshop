using System.Xml.Serialization;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    public class AuthenticationClass
    {
        [XmlElement("password")]
        public string Password;
        [XmlElement("client")]
        public string Client;
    }
}
