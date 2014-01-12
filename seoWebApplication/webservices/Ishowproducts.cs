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
    // NOTE: If you change the interface name "Ishowproducts" here, you must also update the reference to "Ishowproducts" in Web.config.
    [ServiceContract]
    public interface IshowproductsLitService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Animalia")]
        Message ProcessAnimalia();
        [OperationContract]
        [WebGet(UriTemplate = "/Animalia/{Kingdom}")]
        Message ProcessAnimaliaKingdoms(string Kingdom);

        [OperationContract]
        void DoWork();
    }

    [ServiceContract]
    public interface Ishowproducts
    {

        void DoWork();
        //XmlSerializer version
        //[OperationContract]
        //[WebGet(UriTemplate = "/")]
        //[XmlSerializerFormat()]
        //DomainList GetRoot();
        //DataContract Version
        //[OperationContract]
        //[WebGet(UriTemplate = "/")]
        //DomainList GetRoot();
        //Message version
        [OperationContract]
        [XmlSerializerFormat()]
        [WebGet(UriTemplate = "/")]
        DomainList GetRoot();
        //[OperationContract]
        //[WebGet(UriTemplate = "/")]
        //Message GetRoot();
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}")]
        Message GetDomain(string Domain);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}")]
        Message GetKingdom(string Domain, string Kingdom);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}")]
        Message GetPhylum(string Domain, string Kingdom, string Phylum);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}/{Class}")]
        Message GetClass(string Domain, string Kingdom, string Phylum, string Class);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}/{Class}/{Order}")]
        Message GetOrder(string Domain, string Kingdom, string Phylum, string Class, string Order);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}/{Class}/{Order}/{Family}")]
        Message GetFamily(string Domain, string Kingdom, string Phylum, string Class, string Order, string Family);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}/{Class}/{Order}/{Family}/{Genus}")]
        Message GetGenus(string Domain, string Kingdom, string Phylum, string Class, string Order, string Family, string Genus);
        [OperationContract]
        [WebGet(UriTemplate = "/{Domain}/{Kingdom}/{Phylum}/{Class}/{Order}/{Family}/{Genus}/{Species}")]
        Message GetSpecies(string Domain, string Kingdom, string Phylum, string Class, string Order, string Family, string Genus, string Species);
    }
    [XmlRoot(Namespace = "", ElementName = "Domain")]
    public class Domain
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name;
        [XmlAttribute(AttributeName = "uri")]
        public string Uri;
    }
    [XmlRoot(Namespace = "", ElementName = "Domains")]
    public class DomainList : List<Domain>
    {
    }
    //[DataContract(Namespace = "")]
    //public class Domain
    //{
    //    [DataMember]
    //    public string Name;
    //    [DataMember]
    //    public string Uri;
    //}
    //[CollectionDataContract(Name = "Domains", Namespace = "")]
    //public class DomainList : List<Domain>
    //{
    //}
    [DataContract(Namespace = "")]
    public class Kingdom
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Uri;
    }
    [CollectionDataContract(Name = "Kingdoms", Namespace = "")]
    public class KingdomList : List<Kingdom>
    {
    }
}