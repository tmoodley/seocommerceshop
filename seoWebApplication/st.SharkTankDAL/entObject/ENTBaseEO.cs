using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.entObject; 
using System.Reflection;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    /// <summary>
    /// This class is the base for any BLL class that will perform insert, update, or delete actions on a table.
    /// </summary>    
    [Serializable()]
    public abstract class ENTBaseEO : ENTBaseBO
    {        
        #region Enumerations

        public enum DBActionEnum
        {
            Save,
            Delete
        }

        #endregion Enumerations

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ENTBaseEO() : base()
        {
            //Default the action to save.
            DBAction = DBActionEnum.Save;
        }

        #endregion Constructor

        #region Properties

        public DBActionEnum DBAction { get; set; }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        /// This method will add or update a record.
        /// </summary>
        public abstract bool Save(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors, int userAccountId);

        /// <summary>
        /// This method validates the object's data before trying to save the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void Validate(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors);

        /// <summary>
        /// This should call the business object's data class to delete the record.  The only method that should call this 
        /// is the virtual method "Delete(SqlTransaction tn, ref ValidationErrorAL validationErrors, int id)" in this class.
        /// </summary>
        protected abstract void DeleteForReal(seowebappDataContextDataContext db);

        /// <summary>
        /// This method validates the object's data before trying to delete the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void ValidateDelete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors);

        /// <summary>
        /// This will load the object with the default properties.
        /// </summary>
        public abstract void Init();

        #endregion Abstratct Methods

        #region Protected\Public Methods

        public bool IsNewRecord()
        {
            return ID == 0;
        }

        /// <summary>
        /// This is used to save a record and start a new transaction.
        /// The implementor of BaseEO needs to create their own Save method that expects the 
        /// transaction to be passed in.
        /// </summary>
        public bool Save(ref ENTValidationErrors validationErrors, int userAccountId)
        {
            if (DBAction == DBActionEnum.Save)
            {
                // Begin database transaction
                using (TransactionScope ts = new TransactionScope())
                {
                    // Create connection                    
                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                    {                        
                        //Now save the record
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
                throw new Exception("DBAction not Save.");
            }
        }

        /// <summary>
        /// This method will connect to the database and start a transaction.
        /// </summary>
        public bool Delete(ref ENTValidationErrors validationErrors, int userAccountId)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                // Begin database transaction
                using (TransactionScope ts = new TransactionScope())
                {
                    // Create connection
                    using (seowebappDataContextDataContext db = new seowebappDataContextDataContext(dBHelper.GetSeoWebAppConnectionString()))
                    {
                        this.Delete(db, ref validationErrors, userAccountId);

                        if (validationErrors.Count == 0)
                        {
                            //Commit transaction since the delete was successful
                            ts.Complete();
                            return true;
                        }
                        else
                        {
                            //Rollback since the delete was not successful
                            return false;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        internal virtual bool Delete(seowebappDataContextDataContext db, ref ENTValidationErrors validationErrors, int userAccountId)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                //Check if this record can be deleted.  There may be referential integrity rules preventing it from being deleted                
                ValidateDelete(db, ref validationErrors);

                if (validationErrors.Count == 0)
                {
                    this.DeleteForReal(db);
                                        
                    return true;
                }
                else
                {
                    //The record can not be deleted.
                    return false;
                }
            }
            else
            {
                throw new Exception("DBAction not delete.");
            }
        }

        protected void UpdateFailed(ref ENTValidationErrors validationErrors)
        {
            validationErrors.Add("This record was updated by someone else while you were editing it.  Your changes were not saved.  Click the Cancel button and enter this screen again to see the changes.");
        }
               
        #endregion Protected Methods
    }
}
