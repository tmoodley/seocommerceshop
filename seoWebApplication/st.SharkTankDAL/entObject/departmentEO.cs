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
    #region departmentEO

    [Serializable()]
    public class departmentEO : ENTBaseEO
    {
        #region Properties
        public int department_id { get; set; }
        public int webstore_id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        #endregion Properties

        #region Overrides

       
        public override bool Load(int id)
        {
            //Get the entity object from the DAL.
            department department = new departmentData().Select(id);
            MapEntityToProperties(department);
            return department != null;
        }

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            department department = (department)entity;

            department_id = department.department_id;
            webstore_id = department.webstore_id;
            Description = department.Description;
            Name = department.Name;
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
                        ID = new departmentData().Insert(webstore_id, Description, Name, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new departmentData().Update(ID, webstore_id, Description, Name, userAccountId, Version))
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
            departmentData departmentData = new departmentData(); 

            //name is required.
            if (Name.Trim().Length == 0)
            {
                validationErrors.Add("The name is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new departmentData().Delete(db, ID);
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected override void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors)
        {
            //Validate the object
            Validate(db, ref validationErrors);
        }

        public override void Init()
        {
            this.webstore_id = dBHelper.GetWebstoreId();
        }

        protected override string GetDisplayText()
        {
            return Name;
        }

       

         

        

        
        
       

        #endregion Overrides
    }

    #endregion departmentEO

    #region departmentEOList

    [Serializable()]
    public class departmentEOList : List<departmentEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new departmentData().SelectWid());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<department> departments)
        {
            if (departments.Count > 0)
            {
                foreach (department department in departments)
                {
                    departmentEO newdepartmentEO = new departmentEO();
                    newdepartmentEO.MapEntityToProperties(department);
                    this.Add(newdepartmentEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion departmentEOList
}
