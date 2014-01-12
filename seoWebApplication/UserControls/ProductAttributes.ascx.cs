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
using System.Data;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.UserControls
{
    public partial class ProductAttributes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        public void LoadProductAttributes(int id)
        { 
            // temp variables
            string prevAttributeName = "";
            string attributeName, attributeValue, attributeValueId; 

                DataTable attrTable = catalogAccesor.GetAttributes(1);

                // get the attribute placeholder
                PlaceHolder attrPlaceHolder = this.attrPlaceHolder;  

                // current DropDown for attribute values
                Label attributeNameLabel;
                Literal attributeNameLabel2;
                Literal brLiteral;
                Literal tdLiteral;
                Literal td2Literal;
                Literal trLiteral;
                Literal tr2Literal;

                Literal tableLiteral;
                tableLiteral = new Literal();
                tableLiteral.Text = "<table>";

                Literal table2Literal;
                table2Literal = new Literal();
                table2Literal.Text = "</table>";

                Literal spanLiteral;
                spanLiteral = new Literal();
                spanLiteral.Text = "<span>";

                Literal span2Literal;
                span2Literal = new Literal();
                span2Literal.Text = "</span>";

                DropDownList attributeValuesDropDown = new DropDownList();

                //check to see if the product should use the default attributes
                using (var dc = new seowebappDataContextDataContext())
                {


                    if (Convert.ToBoolean(dc.productCheckAttById(id)))
                    {

                        if (attrTable.Rows.Count > 0)
                        {
                            attrPlaceHolder.Controls.Add(spanLiteral);
                            attrPlaceHolder.Controls.Add(tableLiteral);
                        }

                        // read the list of attributes
                        foreach (DataRow r in attrTable.Rows)
                        {
                        // get attribute data
                        attributeName = r["Name"].ToString();
                        attributeValue = r["Value"].ToString();
                        attributeValueId = r["AttributeValueID"].ToString();
                        // if starting a new attribute (e.g. Color, Size)
                        if (attributeName != prevAttributeName)
                        {
                        prevAttributeName = attributeName;
                        attributeNameLabel = new Label();
                        attributeNameLabel.Text = attributeName + ": ";
                        attributeValuesDropDown = new DropDownList();

                        attributeNameLabel2 = new Literal();
                        brLiteral = new Literal();
                        brLiteral.Text = "<br />";
                        trLiteral = new Literal();
                        trLiteral.Text = "<tr>";
                        tr2Literal = new Literal();
                        tr2Literal.Text = "</tr>";
                        tdLiteral = new Literal();
                        tdLiteral.Text = "<td width=100px>";
                        td2Literal = new Literal();
                        td2Literal.Text = "</td>";
                 
                        attributeNameLabel2.Text = attributeName + ": ";
                        attrPlaceHolder.Controls.Add(trLiteral);
                        attrPlaceHolder.Controls.Add(tdLiteral);
                        attrPlaceHolder.Controls.Add(attributeNameLabel2);
                        attrPlaceHolder.Controls.Add(attributeValuesDropDown);
                        attrPlaceHolder.Controls.Add(td2Literal);
                        attrPlaceHolder.Controls.Add(tr2Literal);
                        }
                        // add a new attribute value to the DropDownList
                 
                        attributeValuesDropDown.Items.Add(new ListItem(attributeValue,attributeValueId));
                        }

                        //close the tags
                        if (attrTable.Rows.Count > 0)
                        {
                            attrPlaceHolder.Controls.Add(table2Literal);
                            attrPlaceHolder.Controls.Add(span2Literal);
                        }
                    }   
                } 
        }

       
    }
}