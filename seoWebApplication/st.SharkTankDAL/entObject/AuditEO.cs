using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.dataObject
{
    #region AuditEO

    [Serializable()]
    public class AuditEO  
    {
        #region Properties

        public int AuditID { get; set; }
        public int OrderID { get; set; }
        public int webstore_id { get; set; }
        public DateTime DateStamp { get; set; }
        public string Message { get; set; }
        public Nullable<int> MessageNumber { get; set; }

        #endregion Properties

        #region Overrides

        public bool Load(int id)
        {            
            //Get the entity object from the DAL.
            Audit audit = new AuditData().Select(id);
            MapEntityToProperties(audit);
            return audit != null;        
        }

        public void MapEntityToProperties(Audit entity)
        {
            Audit audit = (Audit)entity;
             
            AuditID = audit.AuditID;
            OrderID = audit.OrderID;
            webstore_id = audit.webstore_id;
            DateStamp = audit.DateStamp;
            Message = audit.Message;
            MessageNumber = audit.MessageNumber;
        }

        
        public bool Save(bool newrec)
        {
            if (newrec)
            {
                //Add
                AuditID = new AuditData().Insert(OrderID, webstore_id, DateStamp, Message, MessageNumber);

            }
            else
            {
                //Update
                if (!new AuditData().Update(AuditID, OrderID, webstore_id, DateStamp, Message, MessageNumber)) ;
                {

                    return false;
                }
            }

            return true;


        }
         
        #endregion Overrides
    }

    #endregion AuditEO

    #region AuditEOList

    [Serializable()]
    public class AuditEOList : List<AuditEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new AuditData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<Audit> audits)
        {
            if (audits.Count > 0)
            {
                foreach (Audit audit in audits)
                {
                    AuditEO newAuditEO = new AuditEO();
                    newAuditEO.MapEntityToProperties(audit);
                    this.Add(newAuditEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion AuditEOList
}
