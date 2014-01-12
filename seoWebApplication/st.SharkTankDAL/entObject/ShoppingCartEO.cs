using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region ShoppingCartEO

    [Serializable()]
    public class ShoppingCartEO  
    {
        #region Properties

        public string cart_id { get; set; }
        public int product_id { get; set; }
        public int webstore_id { get; set; }
        public string attributes { get; set; }
        public int quantity { get; set; }
        public DateTime dateadded { get; set; }

        #endregion Properties

        #region Overrides

        // returns the shopping cart ID for the current user
        public string shoppingCartId
        {
            get
            {
                // get the current HttpContext
                HttpContext context = HttpContext.Current;

                // try to retrieve the cart ID from the user cookie
                //string cart_id = System.Web.HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"].Value;
                string cart_id;
                HttpCookie myCookie = HttpContext.Current.Request.Cookies["SeoWebApp_cart_id"];
                cart_id = "";
                // if the cart ID isn't in the cookie...
                {
                    // check if the cart ID exists as a cookie
                    if (myCookie != null)
                    {
                        //cart_id = myCookie.Value["SeoWebApp_cart_id"];
                        cart_id = context.Request.Cookies["SeoWebApp_cart_id"].Value;
                        // return the id
                        return cart_id;
                    }
                    else
                    // if the cart ID doesn't exist in the cookie as well, generate
                    // a new ID
                    {
                        // generate a new GUID
                        cart_id = Guid.NewGuid().ToString();
                        // create the cookie object and set its value
                        HttpCookie cookie = new HttpCookie("SeoWebApp_cart_id", cart_id);
                        // set the cookie's expiration date
                        int howManyDays = seoWebAppConfiguration.CartPersistDays;
                        DateTime currentDate = DateTime.Now;
                        TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
                        DateTime expirationDate = currentDate.Add(timeSpan);
                        cookie.Expires = expirationDate;
                        // set the cookie on the client's browser
                        context.Response.Cookies.Add(cookie);
                        // return the CartID
                        return cart_id.ToString();
                    }
                }
            }
        }

        public bool Load(int id)
        {            
            //Get the entity object from the DAL.
            ShoppingCart shoppingCart = new ShoppingCartData().Select(id);
            MapEntityToProperties(shoppingCart);
            return shoppingCart != null;        
        }

        public void MapEntityToProperties(ShoppingCart entity)
        {
            ShoppingCart shoppingCart = (ShoppingCart)entity;
             
            cart_id = shoppingCart.cart_id;
            product_id = shoppingCart.product_id;
            webstore_id = shoppingCart.webstore_id;
            attributes = shoppingCart.attributes;
            quantity = shoppingCart.quantity;
            dateadded = shoppingCart.dateadded;
        }

        public bool Save(bool newrec)
        {
            if (newrec)
            {
                //Add
                new ShoppingCartData().Insert(cart_id, product_id, attributes, webstore_id);

            }
            else
            {
                //Update
                if (!new ShoppingCartData().Update(cart_id, product_id, webstore_id, attributes, quantity, dateadded))
                {
                    return false;
                }
            }

            return true;


        }

        

       
 

        #endregion Overrides
    }

    #endregion ShoppingCartEO

    #region ShoppingCartEOList

    [Serializable()]
    public class ShoppingCartEOList : List<ShoppingCartEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new ShoppingCartData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<ShoppingCart> shoppingCarts)
        {
            if (shoppingCarts.Count > 0)
            {
                foreach (ShoppingCart shoppingCart in shoppingCarts)
                {
                    ShoppingCartEO newShoppingCartEO = new ShoppingCartEO();
                    newShoppingCartEO.MapEntityToProperties(shoppingCart);
                    this.Add(newShoppingCartEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion ShoppingCartEOList
}
