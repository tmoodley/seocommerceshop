using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region TaxEO

    [Serializable()]
    public class TaxEO 
    {
        #region Properties

        public int TaxID { get; set; }
        public Nullable<int> webstore_id { get; set; }
        public string TaxType { get; set; }
        public double TaxPercentage { get; set; }

        #endregion Properties

        #region Overrides

        public bool Load(int id, int webstore_id)
        {            
            //Get the entity object from the DAL.
            Tax tax = new TaxData().Select(id, webstore_id);
            MapEntityToProperties(tax);
            return tax != null;        
        }

        public void MapEntityToProperties(Tax entity)
        {
            Tax tax = (Tax)entity;
             
            TaxID = tax.TaxID;
            webstore_id = tax.webstore_id;
            TaxType = tax.TaxType;
            TaxPercentage = tax.TaxPercentage;
        }

        public bool Save(bool newrec)
        {
            if (newrec)
            {
                //Add
                 TaxID = new TaxData().Insert(webstore_id, TaxType, TaxPercentage);

            }
            else
            {
                //Update
                if (!new TaxData().Update(TaxID, webstore_id, TaxType, TaxPercentage))
                {

                    return false;
                }
            }

            return true;


        }
        
        #endregion Overrides
    }

    #endregion TaxEO

    #region TaxEOList

    [Serializable()]
    public class TaxEOList : List<TaxEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new TaxData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<Tax> taxs)
        {
            if (taxs.Count > 0)
            {
                foreach (Tax tax in taxs)
                {
                    TaxEO newTaxEO = new TaxEO();
                    newTaxEO.MapEntityToProperties(tax);
                    this.Add(newTaxEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion TaxEOList
}
