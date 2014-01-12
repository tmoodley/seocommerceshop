using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Xml;
using System.IO;
using System.ServiceModel.Description;

namespace seoWebApplication.webservices
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Message DoWork()
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
    }
}
