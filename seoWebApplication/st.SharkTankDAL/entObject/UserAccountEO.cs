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
    #region UserAccountEO

    [Serializable()]
    public class UserAccountEO : ENTBaseEO
    {
        #region Properties

        public int UserAccountId { get; set; }
        public bool IsActive { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int webstore_id { get; set; }

        #endregion Properties

        #region Overrides

        public override bool Load(int id)
        {            
            //Get the entity object from the DAL.
            UserAccount userAccount = new UserAccountData().Select(id);
            MapEntityToProperties(userAccount);
            return userAccount != null;        
        }

        public bool Login(string email, string password)
        {
            //Get the entity object from the DAL.
            UserAccount userAccount = new UserAccountData().Login(email);
           
            string pw3;
            pw3 = userAccount.Password.ToString();

            string strPassword2;
            strPassword2 = phasher.Hash(password);

            if (strPassword2.Equals(pw3))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int getUserId(string email)
        {
            //Get the entity object from the DAL.
            UserAccount userAccount = new UserAccountData().Login(email); 
            return userAccount.UserAccountId;  
        }

        protected override void MapEntityToCustomProperties(IENTBaseEntity entity)
        {
            UserAccount userAccount = (UserAccount)entity;

            ID = userAccount.UserAccountId;
            UserAccountId = userAccount.UserAccountId;
            IsActive = userAccount.IsActive;
            AccountName = userAccount.AccountName;
            FirstName = userAccount.FirstName;
            LastName = userAccount.LastName;
            Email = userAccount.Email;
            Password = userAccount.Password;
            webstore_id = userAccount.webstore_id;
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
                        ID = new UserAccountData().Insert(db, IsActive, AccountName, FirstName, LastName, Email, Password, webstore_id, userAccountId);

                    }
                    else
                    {
                        //Update
                        if (!new UserAccountData().Update(db, ID, IsActive, AccountName, FirstName, LastName, Email, Password, webstore_id, userAccountId, Version))
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
            UserAccount UserAccount = new UserAccount();

            //Email is required.
            if (Email.Trim().Length == 0)
            {
                validationErrors.Add("The Email is required.");
            }
        }

        protected override void DeleteForReal(seowebappDataContextDataContext db)
        {
            if (DBAction == DBActionEnum.Delete)
            {
                new UserAccountData().Delete(db, ID);
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
            this.IsActive = true;
        }

        protected override string GetDisplayText()
        {
            throw new NotImplementedException();
        }

        #endregion Overrides
    }

    #endregion UserAccountEO

    #region UserAccountEOList

    [Serializable()]
    public class UserAccountEOList : ENTBaseEOList<UserAccountEO>
    {
        #region Overrides

        public override void Load()
        {
            LoadFromList(new UserAccountData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<UserAccount> userAccounts)
        {
            if (userAccounts.Count > 0)
            {
                foreach (UserAccount userAccount in userAccounts)
                {
                    UserAccountEO newUserAccountEO = new UserAccountEO();
                    newUserAccountEO.MapEntityToProperties(userAccount);
                    this.Add(newUserAccountEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion UserAccountEOList
}
