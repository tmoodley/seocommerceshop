using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{
    [XmlRoot("Response")]
    public class myWsResponse
    {
        //string HttpSOAPRequest(XmlDocument doc, string add, string proxy, X509Certificate2Collection certs)
        //{
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(add);
        //    req.ClientCertificates = certs;
        //    if (proxy != null) req.Proxy = new WebProxy("", true);

        //    req.Headers.Add("SOAPAction", "\"\"");

        //    req.ContentType = "text/xml;charset=\"utf-8\"";
        //    req.Accept = "text/xml";
        //    req.Method = "POST";
        //    Stream stm = req.GetRequestStream();
        //    doc.Save(stm);
        //    stm.Close();
        //    WebResponse resp = req.GetResponse();
        //    stm = resp.GetResponseStream();
        //    StreamReader r = new StreamReader(stm);

        //    return r.ReadToEnd();
        //}

        [XmlElement("ReturnProductsResponse")]
        public string ReturnProductsResponse;
        [XmlElement("ReturnProductsResult")]
        public string ReturnProductsResult;
        [XmlElement("Product")]
        public string Product;
      

        public ReturnProductsResponseClass ProdReturn;
        [XmlIgnore()]
        public string Xml
        {
            get
            {
                // Prepare XML serializer
                XmlSerializer serializer =
                new XmlSerializer(typeof(myWsResponse));
                // Serialize into StringBuilder
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                serializer.Serialize(sw, this);
                sw.Flush();
                // Replace UTF-16 encoding with UTF-8 encoding
                string xml = sb.ToString();
                xml = xml.Replace("utf-16", "utf-8");
                return xml;
            }
        }
    }
}

