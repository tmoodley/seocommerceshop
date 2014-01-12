using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    [Serializable()]
    public abstract class SEOBaseBOList<T> : List<T>
        where T : SEOBaseBO, new()
    {
        #region Abstract Methods
        /// <summary>
        /// The use must implement a method to load the object from the database.
        /// </summary>
        public abstract void Load();

        #endregion Abstract Methods

        #region Methods

        public List<T> SortByPropertyName(string propertyName, bool ascending)
        {
            //Create a Lambda expression to dynamically sort the data.
            var param = Expression.Parameter(typeof(T), "N");

            var sortExpresseion = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

            if (ascending)
            {
                return this.AsQueryable<T>().OrderBy<T, object>(sortExpresseion).ToList<T>();
            }
            else
            {
                return this.AsQueryable<T>().OrderByDescending<T, object>(sortExpresseion).ToList<T>();
            }
        }

        #endregion Methods

    }
}
