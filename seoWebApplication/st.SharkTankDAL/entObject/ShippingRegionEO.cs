using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region ShippingRegionEO

    [Serializable()]
    public class ShippingRegionEO  
    {
        #region Properties

        public int ShippingRegionID { get; set; }
        public string ShippingRegion { get; set; }
        public string ShippingRegionSmall { get; set; }

        #endregion Properties

        #region Overrides

        public bool Load(int id)
        {            
            //Get the entity object from the DAL.
            ShippingRegion shippingRegion = new ShippingRegionData().Select(id);
            MapEntityToProperties(shippingRegion);
            return shippingRegion != null;        
        }

        public void MapEntityToProperties(ShippingRegion entity)
        {
            ShippingRegion shippingRegion = (ShippingRegion)entity;
 
            ShippingRegionID = shippingRegion.ShippingRegionID;
            ShippingRegion = shippingRegion.ShippingRegion1;
            ShippingRegionSmall = shippingRegion.ShippingRegionSmall;
        }


        public bool Save(bool newrec)
        {
            if (newrec)
            { 
                //Add
                ShippingRegionID = new ShippingRegionData().Insert(ShippingRegion, ShippingRegionSmall);

            }
            else
            {
                //Update
                if (!new ShippingRegionData().Update(ShippingRegionID, ShippingRegion, ShippingRegionSmall))
                {

                    return false;
                }
            }

            return true;


        }

        public bool LoadByDesc(string id)
        {
            //Get the entity object from the DAL.
            ShippingRegion shippingRegion = new ShippingRegionData().SelectByDesc(id);
            MapEntityToProperties(shippingRegion);
            return shippingRegion != null;
        }

        public int getShippingId(string id)
        {
            //Get the entity object from the DAL.
            ShippingRegion shippingRegion = new ShippingRegionData().SelectByDesc(id);
            return shippingRegion.ShippingRegionID;
        }

 

        #endregion Overrides
    }

    #endregion ShippingRegionEO

    #region ShippingRegionEOList

    [Serializable()]
    public class ShippingRegionEOList : List<ShippingRegionEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new ShippingRegionData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<ShippingRegion> shippingRegions)
        {
            if (shippingRegions.Count > 0)
            {
                foreach (ShippingRegion shippingRegion in shippingRegions)
                {
                    ShippingRegionEO newShippingRegionEO = new ShippingRegionEO();
                    newShippingRegionEO.MapEntityToProperties(shippingRegion);
                    this.Add(newShippingRegionEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion ShippingRegionEOList
}
