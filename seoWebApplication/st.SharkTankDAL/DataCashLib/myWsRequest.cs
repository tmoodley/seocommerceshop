using System.Xml.Serialization;
using System.Xml.Serialization.Configuration;
using System.IO;
using System.Net;
using System.Text;


namespace seoWebApplication.st.SharkTankDAL.DataCashLib
{

    [XmlRoot(ElementName = "soap:Envelope")]

    public class myWsRequest
    {
      
        [XmlElement("ReturnProducts",Namespace = "devArticles")]
        
      
      
        //[Serializable, XmlRoot(ElementName = "ReturnProducts", Namespace = "devArticles")]
        //[XmlType("register-account")]
        public ReturnProductsClass RetProducts =
        new ReturnProductsClass();

        //XDocument ConstructSoapEnvelope(string messageId, string action, XDocument body)
        //{
        //    XDocument xd = new XDocument();
        //    XNamespace s = "http://schemas.xmlsoap.org/soap/envelope/";
        //    XNamespace a = "http://www.w3.org/2005/08/addressing";

        //    XElement soapEnvelope = new XElement(s + "Envelope", new XAttribute(XNamespace.Xmlns + "s", s), new XAttribute(XNamespace.Xmlns + "a", a));
        //    XElement header = new XElement(s + "Header");
        //    XElement xmsgId = new XElement(a + "MessageID", "uuid:" + messageId);
        //    XElement xaction = new XElement(a + "Action", action);
        //    header.Add(xmsgId);
        //    header.Add(xaction);

        //    XElement soapBody = new XElement(s + "Body", body.Root);
        //    soapEnvelope.Add(header);
        //    soapEnvelope.Add(soapBody);
        //    xd = new XDocument(soapEnvelope);
        //    return xd;
        //}

        
        
        
        public myWsResponse GetResponse(string url)
        {
            // Configure HTTP Request
            HttpWebRequest httpRequest = WebRequest.Create(url)
            as HttpWebRequest;
            httpRequest.Method = "POST";
            // Prepare correct encoding for XML serialization
            UTF8Encoding encoding = new UTF8Encoding();
            // Use Xml property to obtain serialized XML data
            // Convert into bytes using encoding specified above and
            // get length
            byte[] bodyBytes = encoding.GetBytes(Xml);
            httpRequest.ContentLength = bodyBytes.Length;
            // Get HTTP Request stream for putting XML data into
            Stream httpRequestBodyStream =
            httpRequest.GetRequestStream();
            // Fill stream with serialized XML data
            httpRequestBodyStream.Write(bodyBytes, 0, bodyBytes.Length);
            httpRequestBodyStream.Close();
            // Get HTTP Response
            HttpWebResponse httpResponse = httpRequest.GetResponse()
            as HttpWebResponse;
            StreamReader httpResponseStream =
                new StreamReader(httpResponse.GetResponseStream(),
            System.Text.Encoding.ASCII);
            // Extract XML from response
            string httpResponseBody = httpResponseStream.ReadToEnd();
            httpResponseStream.Close();
            // Ignore everything that isn't XML by removing headers
            httpResponseBody = httpResponseBody.Substring(
            httpResponseBody.IndexOf("<?xml"));
            // Deserialize XML into DataCashResponse
            XmlSerializer serializer =
            new XmlSerializer(typeof(myWsResponse));
            StringReader responseReader =
            new StringReader(httpResponseBody);
            // Return DataCashResponse result
            return serializer.Deserialize(responseReader)
            as myWsResponse;
        }
        [XmlIgnore()]
        public string Xml
        {
            get
            {
                // Prepare XML serializer
                XmlSerializer serializer =
                new XmlSerializer(typeof(myWsRequest));
                // Serialize into StringBuilder
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                serializer.Serialize(sw, this);
                sw.Flush();
                // Replace UTF-16 encoding with UTF-8 encoding
                string xml = sb.ToString();
                xml = xml.Replace("utf-16", "utf-8");
                 
               
                string headerTag2 = "<soap:Body><ReturnProducts xmlns=\"devArticles\" /></soap:Body>";
                string oldTag = "<ReturnProducts xmlns=\"devArticles\" />";
                string newTag = "<soap:Body><ReturnProducts xmlns=\"devArticles\" /></soap:Body>";
                string oldTag2 = "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"";
                string newTag2 = "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"";
                xml = xml.Replace(oldTag2, newTag2);
                xml = xml.Replace(oldTag, newTag);
                xml = xml.Replace("_x003A_", ":");
                return xml;
            }
        }
    }
}


