using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.entObject;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    [Serializable()]
    public abstract class ENTBaseEOList<T> : ENTBaseBOList<T> 
        where T : ENTBaseEO, new()
    {
        /// <summary>
        /// This method will begin a transaction and save all the edit objects in the collection.
        /// </summary>
        /// <param name="veAL"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool Save(ref ENTValidationErrors validationErrors, int userAccountId)
        {
            // Check if this object has any items
            if (this.Count > 0)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext())
                    {
                        if (this.Save(db, ref validationErrors, userAccountId))
                        {
                            // Commit transaction if update was successful
                            ts.Complete();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                //No items in the list so return true.
                return true;
            }
        }

        /// <summary>
        /// This method will save all the edit objects in the collection.  The transaction must be started before
        /// calling this method.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="validationErrors"></param>
        /// <param name="userAccountId"></param>
        /// <returns></returns>
        public bool Save(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors, int userAccountId)
        {            
            foreach (ENTBaseEO genericEO in this)
            {         
                if (genericEO.DBAction == ENTBaseEO.DBActionEnum.Save)
                {
                    if (!genericEO.Save(db, ref validationErrors, userAccountId))
                    {
                        return false;
                    }
                }
                else
                {
                    if (genericEO.DBAction == ENTBaseEO.DBActionEnum.Delete)
                    {
                        if (!genericEO.Delete(db, ref validationErrors, userAccountId))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        throw new Exception("Unknown DBAction");
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This will load the current instance and return itself.  This is useful for object data source controls.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            this.Load();
            return this;
        }
    }        
}
