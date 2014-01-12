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
    public partial class RestaurantReviewStars : System.Web.UI.UserControl
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
           LoadRestaurantReviewStars(dBHelper.GetWebstoreId()); 
        }

       

        public void LoadRestaurantReviewStars(int webstore_id)
        { 
            
                // get the attribute placeholder
                PlaceHolder attrPlaceHolder = this.attrPlaceHolder;  

                // current DropDown for attribute values
                Label attributeNameLabel;
                  
                Literal attributeNameLabel2;
                Literal brLiteral;
                Literal tdLiteral;
                Literal tdLiteral1;
                Literal td2Literal;
                Literal trLiteral;
                Literal tr2Literal;
                Image starsImage;
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
              
                reviewEOList rev = new reviewEOList();
                rev.Load();
                int x = 0;
                int y = 0;
                if (rev.Count > 0)
                {
                     
                    attrPlaceHolder.Controls.Add(tableLiteral);
                 
                    foreach (reviewEO review in rev)
                    {
                        if (review.webstore_id == webstore_id)
                        { 
                                x++;
                                y = y + Convert.ToInt32(review.MainRate);
                        }

                    }
                }
                int rating = 0;
                if (y > 0)
                {
                    rating = (y / x);
                }
                
                

                attributeNameLabel = new Label();
                attributeNameLabel.Text = "Main Rating" + ": ";
                attributeValuesDropDown = new DropDownList();
              
                starsImage = new Image();
                starsImage.ID = "MainRating";
                starsImage.Width = 100;
             

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

                attributeNameLabel2.Text = "Main Rating" + ": ";
                attrPlaceHolder.Controls.Add(trLiteral);
                attrPlaceHolder.Controls.Add(tdLiteral1);
                attrPlaceHolder.Controls.Add(attributeNameLabel2);
                attrPlaceHolder.Controls.Add(td2Literal);
                attrPlaceHolder.Controls.Add(tdLiteral);
                attrPlaceHolder.Controls.Add(starsImage);
                attrPlaceHolder.Controls.Add(td2Literal);
                attrPlaceHolder.Controls.Add(tr2Literal);

                attrPlaceHolder.Controls.Add(table2Literal);
                 
                }

        

                 
        }

       
    
}