using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Xml.Serialization;

namespace seoWebApplication.webservices
{
    /// <summary>
    /// Summary description for getproducts
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class getproducts : System.Web.Services.WebService
    {

        [WebMethod]
         //Message Version
        public Message GetRoot()
        {
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter xw = XmlDictionaryWriter.CreateTextWriter(ms);
            xw.WriteStartDocument();
            xw.WriteStartElement("Domains");
            string[] domains = new string[] { "Archaea", "Eubacteria", "Eukaryota" };
            foreach (string domain in domains)
            {
                xw.WriteStartElement("Domain");
                xw.WriteAttributeString("name", domain);
                xw.WriteAttributeString("uri", domain);
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Flush();
            ms.Position = 0;
            XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
            Message ret = Message.CreateMessage(MessageVersion.None, "*", xdr);
            return ret;
        }
        //hybrid version
        //public Message GetRoot()
        //{
        //    DomainList ret = new DomainList();
        //    string[] domains = new string[] { "Archaea", "Eubacteria", "Eukaryota" };
        //    foreach (string domain in domains)
        //    {
        //        ret.Add(new Domain { Name = domain, Uri = domain });

        //    }
        //    Message realRet = Message.CreateMessage(MessageVersion.None, "*", ret);
        //     return realRet;
        //}
    }
}
