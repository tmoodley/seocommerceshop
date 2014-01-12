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
    public partial class RestaurantDeliveryMap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            webstoreEO webstore = new webstoreEO();
            webstore.Load(dBHelper.GetWebstoreId());
            string polygon = webstore.polygonArray.ToString();
            StringBuilder builder = new StringBuilder();

            builder.Append("<script type='text/javascript'>").AppendLine();
            builder.Append("(function () {").AppendLine();
            builder.Append("window.onload = function () {").AppendLine();
            builder.Append("// Creating a map").AppendLine();
            builder.Append("var options = {").AppendLine();
            builder.Append("zoom: 13,").AppendLine();
            builder.Append("center: new google.maps.LatLng(29.611534, -98.459268),").AppendLine();
            builder.Append("mapTypeId: google.maps.MapTypeId.ROADMAP").AppendLine();
            builder.Append("};").AppendLine();
            builder.Append("var map = new google.maps.Map(document.getElementById('main-map'), options);").AppendLine();
            builder.Append("// Creating an array with the points for the polygon").AppendLine();
            builder.Append("var points = [ ").AppendLine();







            string[] words = polygon.Split(')');
            int x = words.Length;
            int y = words.Length - 2;
            for (int i = 0; i < x; i++)
            {
                if (i < y)
                {
                    builder.Append("new google.maps.LatLng" + words[i] + "),").AppendLine();
                }
                else if (i == y)
                {
                    builder.Append("new google.maps.LatLng" + words[i] + ")").AppendLine();
                }
            }


            builder.Append("];").AppendLine();

            builder.Append("// Creating the polygon").AppendLine();
            builder.Append("var polygon = new google.maps.Polygon({").AppendLine();
            builder.Append("paths: points,").AppendLine();
            builder.Append("map: map,").AppendLine();
            builder.Append("strokeColor: '#0000ff',").AppendLine();
            builder.Append("strokeOpacity: 0.6,").AppendLine();
            builder.Append("strokeWeight: 1,").AppendLine();
            builder.Append("fillColor: '#0000ff',").AppendLine();
            builder.Append("fillOpacity: 0.35").AppendLine();
            builder.Append("});").AppendLine();
            builder.Append("};").AppendLine();
            builder.Append("})();").AppendLine();
            builder.Append("</script>").AppendLine();

            this.mapLiteral.Text = builder.ToString();


        }

       
    }
}