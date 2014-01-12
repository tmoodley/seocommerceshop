using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.entObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    /// <summary>
    /// The BaseBO class is the Base for any business object class that will retrieve data from the database.
    /// </summary>    
    [Serializable()]
    public abstract class SEOBaseBO
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SEOBaseBO() { }

        #endregion Constructor

        #region Properties

        public int ID { get; set; }
        

        /// <summary>
        /// This returns the text that should appear in a list box or drop down list for this object.
        /// The property is used when binding to a control.
        /// </summary>
        public string DisplayText
        {
            get { return GetDisplayText(); }
        }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        /// Get the record from the database and load the object's properties
        /// </summary>
        /// <returns>Returns true if the record is found.</returns>
        public abstract bool Load(int id);

        /// <summary>
        /// This method will map the fields in the data reader to the member variables in the object.
        /// </summary>
        protected abstract void MapEntityToCustomProperties(ISEOBaseEntity entity);

        /// <summary>
        /// This returns the text that should appear in a list box or drop down list for this object.
        /// </summary>
        protected abstract string GetDisplayText();

        #endregion Abstratct Methods

        #region Public Methods

        /// <summary>
        /// This method will load all the properties of the object from the entity.
        /// </summary>        
        public void MapEntityToProperties(ISEOBaseEntity entity)
        {            
            if (entity != null)
            { 
                this.MapEntityToCustomProperties(entity);
            }
        }

        #endregion Public Methods
    }     
}
