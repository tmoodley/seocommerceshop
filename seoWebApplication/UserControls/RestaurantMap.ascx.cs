using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL; 
using System.Collections.Generic;   
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Text;

namespace seoWebApplication.UserControls
{
    public partial class RestaurantMap : System.Web.UI.UserControl
    {
        public string geoLocation;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        protected void Page_Load(object sender, EventArgs e)
        {
            webstoreEO webstore = new webstoreEO();
            webstore.Load(dBHelper.GetWebstoreId());
            Address = webstore.address;
            cityEO city = new cityEO();
            city.Load(Convert.ToInt32(webstore.city));
            City = city.city1;
            stateEO state = new stateEO();
            state.Load(Convert.ToInt32(webstore.state));
            State = state.stateLname;
            Zip = webstore.zip; 
            geoLocation = webstore.locationx + "," + webstore.locationy; 
        } 
    }
}