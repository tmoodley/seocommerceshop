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
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;  
using System.IO;
 

namespace seoWebApplication.UserControls
{
    public partial class RestaurantReviews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
                    try
                    {
                        // CatalogAccess.GetDepartments returns a DataTable object containing
                        // department data, which is read in the ItemTemplate of the DataList
                        using (var dc = new seowebappDataContextDataContext())
                        {
                            outerRep.DataSource = dc.reviewSelectByWId(Convert.ToInt32(dBHelper.GetWebstoreId()));
                            outerRep.DataBind();  
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Exception Occured:   " + ex);
                    }
             
        }

        protected void outerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                reviewSelectByWIdResult obj = (reviewSelectByWIdResult)(e.Item.DataItem);
                DataRowView drv = e.Item.DataItem as DataRowView;
                Repeater innerRep = e.Item.FindControl("innerRep") as Repeater;
                 
                int review_id = obj.review_id;

                using (var dc = new seowebappDataContextDataContext())
                {
                    innerRep.DataSource = dc.storeReviewsSelectByRId(Convert.ToInt32(review_id));
                    innerRep.DataBind();
                    
                }
                // get the attribute placeholder 
                //PlaceHolder outerattrPlaceHolder = (PlaceHolder)e.Item.FindControl("outerattrPlaceHolder");
                //Label lblName;
                //lblName.Text = 
                //outerattrPlaceHolder.Controls.Add(lblName);  
            }
        }

        protected void innerRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                // Obtain the ID of the selected department

                storeReviewsSelectByRIdResult obj = (storeReviewsSelectByRIdResult)(e.Item.DataItem); 
                string review_id = obj.review_id.ToString();
                int reviewTypeId = Convert.ToInt32(obj.ReviewFields_id); 
                // get the attribute placeholder 
                PlaceHolder attrPlaceHolder = (PlaceHolder)e.Item.FindControl("attrPlaceHolder");

                // current DropDown for attribute values
                Label attributeNameLabel;
                Label lblComments;
                TextBox txtBx;
                HtmlTextArea txtArea;
                Image starsImage;
                RadioButtonList radioList;
                Literal attributeNameLabel2;
                Literal brLiteral;
                Literal tdLiteral;
                Literal tdLiteral1;
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

                attrPlaceHolder.Controls.Add(tableLiteral);  
                 //type = text
                if (reviewTypeId == 1)
                {
                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = "Comment: ";
                    attributeValuesDropDown = new DropDownList();
                    txtBx = new TextBox();
                    txtBx.ID = "Comment";
                    txtBx.CssClass = "Comment";

                    attributeNameLabel2 = new Literal();
                    tdLiteral1 = new Literal();
                    tdLiteral1.Text = "<td width='30%' valign='top' nowrap='' align='right'>";

                    brLiteral = new Literal();
                    brLiteral.Text = "<br />";
                    trLiteral = new Literal();
                    trLiteral.Text = "<tr>";
                    tr2Literal = new Literal();
                    tr2Literal.Text = "</tr>";
                    tdLiteral = new Literal();
                    tdLiteral.Text = "<td width=70px>";
                    td2Literal = new Literal();
                    td2Literal.Text = "</td>";

                    attributeNameLabel2.Text = "Comment" + ": ";
                    attrPlaceHolder.Controls.Add(trLiteral);
                    attrPlaceHolder.Controls.Add(tdLiteral1);
                    attrPlaceHolder.Controls.Add(attributeNameLabel2);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tdLiteral);
                    attrPlaceHolder.Controls.Add(txtBx);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tr2Literal);
                }
                else if (reviewTypeId == 2)
                {

                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = "Comments" + ": ";
                    attributeValuesDropDown = new DropDownList();
                    txtArea = new HtmlTextArea();
                    txtArea.ID = "Comments";
                    txtArea.Rows = 3;
                    txtArea.Cols = 40;
                    attributeNameLabel2 = new Literal();
                    tdLiteral1 = new Literal();
                    tdLiteral1.Text = "<td width='30%' valign='top' nowrap='' align='right'>";

                    brLiteral = new Literal();
                    brLiteral.Text = "<br />";
                    trLiteral = new Literal();
                    trLiteral.Text = "<tr>";
                    tr2Literal = new Literal();
                    tr2Literal.Text = "</tr>";
                    tdLiteral = new Literal();
                    tdLiteral.Text = "<td width=70px>";
                    td2Literal = new Literal();
                    td2Literal.Text = "</td>";

                    attributeNameLabel2.Text = "Comments" + ": ";
                    attrPlaceHolder.Controls.Add(trLiteral);
                    attrPlaceHolder.Controls.Add(tdLiteral1);
                    attrPlaceHolder.Controls.Add(attributeNameLabel2);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tdLiteral);
                    attrPlaceHolder.Controls.Add(txtArea);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tr2Literal);
                }
                //feeling
                else if (reviewTypeId == 3)
                {
                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = "Rating" + ": ";
                    attributeValuesDropDown = new DropDownList();
                    starsImage = new Image();
                    starsImage.ID = "Rating";
                    starsImage.Width = 100;
                  
                    int rating = Convert.ToInt32(obj.rate);

                    if (rating <= 1)
                    {
                        starsImage.ImageUrl = "/Images/1-Stars.png";
                    }
                    else if (rating <= 2)
                    {
                        starsImage.ImageUrl = "/Images/2-Stars.png";
                    }
                    else if (rating <= 3)
                    {
                        starsImage.ImageUrl = "/Images/3-Stars.png";
                    }
                    else if (rating <= 4)
                    {
                        starsImage.ImageUrl = "/Images/4-Stars.png";
                    }
                    else if (rating <= 5)
                    {
                        starsImage.ImageUrl = "/Images/5-Stars.png";
                    }



                    attributeNameLabel2 = new Literal();
                    tdLiteral1 = new Literal();
                    tdLiteral1.Text = "<td width='30%' valign='top' nowrap='' align='right'>";

                    brLiteral = new Literal();
                    brLiteral.Text = "<br />";
                    trLiteral = new Literal();
                    trLiteral.Text = "<tr>";
                    tr2Literal = new Literal();
                    tr2Literal.Text = "</tr>";
                    tdLiteral = new Literal();
                    tdLiteral.Text = "<td width=70px>";
                    td2Literal = new Literal();
                    td2Literal.Text = "</td>";

                    attributeNameLabel2.Text = "Rating" + ": ";
                    attrPlaceHolder.Controls.Add(trLiteral);
                    attrPlaceHolder.Controls.Add(tdLiteral1);
                    attrPlaceHolder.Controls.Add(attributeNameLabel2);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tdLiteral);
                    attrPlaceHolder.Controls.Add(starsImage);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tr2Literal);
                }
                 //Comment
                else if (reviewTypeId == 5)
                {
                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = "Comments" + ": ";
                    attributeValuesDropDown = new DropDownList();
                    txtArea = new HtmlTextArea();
                    lblComments = new Label();
                    txtArea.ID = "Comments";
                    txtArea.Rows = 3;
                    txtArea.Cols = 40;
                    txtArea.InnerText = obj.comment.ToString();
                    attributeNameLabel2 = new Literal();
                    tdLiteral1 = new Literal();
                    tdLiteral1.Text = "<td width='30%' valign='top' nowrap='' align='right'>";

                    brLiteral = new Literal();
                    brLiteral.Text = "<br />";
                    trLiteral = new Literal();
                    trLiteral.Text = "<tr>";
                    tr2Literal = new Literal();
                    tr2Literal.Text = "</tr>";
                    tdLiteral = new Literal();
                    tdLiteral.Text = "<td width=70px>";
                    td2Literal = new Literal();
                    td2Literal.Text = "</td>";

                    attributeNameLabel2.Text = "Comments" + ": ";
                    attrPlaceHolder.Controls.Add(trLiteral);
                    attrPlaceHolder.Controls.Add(tdLiteral1);
                    attrPlaceHolder.Controls.Add(attributeNameLabel2);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tdLiteral);
                    attrPlaceHolder.Controls.Add(txtArea);
                    attrPlaceHolder.Controls.Add(td2Literal);
                    attrPlaceHolder.Controls.Add(tr2Literal);
                }
                 
               attrPlaceHolder.Controls.Add(table2Literal);
            }
            
        }
    }
}