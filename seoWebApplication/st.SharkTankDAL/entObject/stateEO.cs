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
    #region stateEO

    [Serializable()]
    public class stateEO : SEOBaseEO
    {
        #region Properties

        public int idState { get; set; }
        public string stateSname { get; set; }
        public string stateLname { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            state state = new stateData().Select(id);
            MapEntityToProperties(state);
            return state != null;        
        }

        protected override void MapEntityToCustomProperties(ISEOBaseEntity entity)
        {
            state state = (state)entity;

            ID = state.idState;
            idState = state.idState;
            stateSname = state.stateSname;
            stateLname = state.stateLname;
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
                        ID = new stateData().Insert(db, idState, stateSname, stateLname);

                    }
                    else
                    {
                        //Update
                        if (!new stateData().Update(db, ID, stateSname, stateLname))
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
            stateData stateData = new stateData();

            //name is required.
            if (stateSname.Trim().Length == 0)
            {
                validationErrors.Add("The Short name is required.");
            }

            if (stateLname.Trim().Length == 0)
            {
                validationErrors.Add("The Long name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new stateData().Delete(db, ID);
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
            stateSname = "";
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion stateEO

    #region stateEOList

    [Serializable()]
    public class stateEOList : SEOBaseEOList<stateEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new stateData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<state> states)
        {
            if (states.Count > 0)
            {
                foreach (state state in states)
                {
                    stateEO newstateEO = new stateEO();
                    newstateEO.MapEntityToProperties(state);
                    this.Add(newstateEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion stateEOList
}
