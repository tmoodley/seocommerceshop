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
    #region categoryEO

    [Serializable()]
    public class categoryEO : ENTBaseEO
    {
        #region Properties

        public int category_id { get; set; }
        public int department_id { get; set; }
        public int webstore_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            category category = new categoryData().Select(id, dBHelper.GetWebstoreId());
            MapEntityToProperties(category);
            return category != null;        
        }
         

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            category category = (category)entity;

            category_id = category.category_id;
            department_id = category.department_id;
            webstore_id = category.webstore_id;
            name = category.name;
            description = category.description;
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
                        ID = new categoryData().Insert(department_id, webstore_id, name, description, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new categoryData().Update(ID, department_id, webstore_id, name, description, userAccountId, Version))
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
            categoryData categoryData = new categoryData(); 

            //name is required.
            if (name.Trim().Length == 0)
            {
                validationErrors.Add("The name is required.");
            }

            if (DBAction == DBActionEnum.Delete)
            {
                //if (db.ShoppingCartSelectByPId(ID) > 0)
                //{
                //    validationErrors.Add("There are products in the shopping cart.");
                //} 
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new categoryData().Delete(ID);
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
            return name;
        }


        public static void addProductToCategory(int pid, int cid)
        {
            categoryData.addProductToCategory(pid, cid);  
        }

        public static void delProductToCategory(int pid, int cid)
        {
            categoryData.delProductToCategory(pid, cid);
        }

        #endregion Overrides
    }


    #endregion categoryEO

    #region categoryEOList


    [Serializable()]
    public class categoryEOList : List<categoryEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new categoryData().SelectByWid(dBHelper.GetWebstoreId()));
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<category> categorys)
        {
            if (categorys.Count > 0)
            {
                foreach (category category in categorys)
                {
                    categoryEO newcategoryEO = new categoryEO();
                    newcategoryEO.MapEntityToProperties(category);
                    this.Add(newcategoryEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion categoryEOList
}
