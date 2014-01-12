using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Linq.Expressions;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region zoneEO

    [Serializable()]
    public class zoneEO : SEOBaseEO
    {
        #region Properties

        public int idZone { get; set; }
        public int idCity { get; set; }
        public string zoneName { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            zone zone = new zoneData().Select(id);
            MapEntityToProperties(zone);
            return zone != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            zone zone = (zone)entity;

            ID = zone.idZone;
            idZone = zone.idZone;
            idCity = zone.idCity;
            zoneName = zone.zoneName;
        }

        public override bool Save(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors, int userAccountId)
        {
            if (DBAction == DBActionEnum.Save)
            {
                //Validate the object
                Validate(db, ref validationErrors);

                //Check if there were any validation errors
                if (validationErrors.Count == 0)
                {
                    if (IsNewRecord())
                    {
                        //Add
                        ID = new zoneData().Insert(db, idCity, zoneName);

                    }
                    else
                    {
                        //Update
                        if (!new zoneData().Update(db, ID, idCity, zoneName ))
                        {
                            UpdateFailed(ref validationErrors);
                            return false;
                        }
                    }

                    return true;

                }
                else
                {
                    //Didn't pass validation.
                    return false;
                }
            }
            else
            {
                throw new Exception("DBAction not Save.");
            }
        }

        protected override void Validate(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            zoneData zoneData = new zoneData();

            //name is required.
            if (zoneName.Trim().Length == 0)
            {
                validationErrors.Add("The Zone name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new zoneData().Delete(db, ID);
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected override void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            zoneName = "";
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion zoneEO

    #region zoneEOList

    [Serializable()]
    public class zoneEOList : SEOBaseEOList<zoneEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new zoneData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<zone> zones)
        {
            if (zones.Count > 0)
            {
                foreach (zone zone in zones)
                {
                    zoneEO newzoneEO = new zoneEO();
                    newzoneEO.MapEntityToProperties(zone);
                    this.Add(newzoneEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion zoneEOList
}
