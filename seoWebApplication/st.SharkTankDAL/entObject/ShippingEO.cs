using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region ShippingEO

    [Serializable()]
    public class ShippingEO 
    {
        #region Properties

        public int ShippingID { get; set; }
        public Nullable<int> webstore_id { get; set; }
        public string ShippingType { get; set; }
        public decimal ShippingCost { get; set; }
        public Nullable<int> ShippingRegionID { get; set; }

        #endregion Properties

        #region Overrides

        public bool Load(int id, int webstore_id)
        {            
            //Get the entity object from the DAL.
            Shipping shipping = new ShippingData().Select(id, webstore_id);
            MapEntityToProperties(shipping);
            return shipping != null;        
        }

         

        public bool GetShippingInfo(int id, int webstore_id)
        {            
            //Get the entity object from the DAL.
            Shipping shipping = new ShippingData().Select(id, webstore_id);
            MapEntityToProperties(shipping);
            return shipping != null;        
        }


        public decimal GetShippingCost(int id, int webstore_id)
        {
            decimal shippingCost;
            //Get the entity object from the DAL. 
            Shipping shipping = new ShippingData().Select(id, webstore_id);
            shippingCost = shipping.ShippingCost; 
            return shippingCost; 
        }

          
        public void MapEntityToProperties(Shipping entity)
        {
            Shipping shipping = (Shipping)entity;
              
            ShippingID = shipping.ShippingID;
            webstore_id = shipping.webstore_id;
            ShippingType = shipping.ShippingType;
            ShippingCost = shipping.ShippingCost;
            ShippingRegionID = shipping.ShippingRegionID;
        }

        public bool Save(bool newrec)
        {
            if (newrec)
            {
                //Add
                ShippingID = new ShippingData().Insert(webstore_id, ShippingType, ShippingCost, ShippingRegionID);

            }
            else
            {
                //Update
                if (!new ShippingData().Update(ShippingID, webstore_id, ShippingType, ShippingCost, ShippingRegionID))
                {

                    return false;
                }
            }

            return true;


        }


        
 

         

       

        

        

        #endregion Overrides
    }

    #endregion ShippingEO

    #region ShippingEOList

    [Serializable()]
    public class ShippingEOList : List<ShippingEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new ShippingData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<Shipping> shippings)
        {
            if (shippings.Count > 0)
            {
                foreach (Shipping shipping in shippings)
                {
                    ShippingEO newShippingEO = new ShippingEO();
                    newShippingEO.MapEntityToProperties(shipping);
                    this.Add(newShippingEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion ShippingEOList
}
