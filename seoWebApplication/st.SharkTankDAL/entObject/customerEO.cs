using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  
using System.Text;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;

namespace seoWebApplication.st.SharkTankDAL.entObject
{
    [Serializable()]
    public class customerEO
    {
        #region Properties

     

        public int customerid { get; set; }

        public int webstore_id { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string region { get; set; }

        public string zip { get; set; }

        public string country { get; set; }

        public string shippingRegion { get; set; }

        public decimal dayPhone { get; set; }

        public decimal cellPhone { get; set; }

        public decimal evePhone { get; set; }

        public string creditCard { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string squestion { get; set; }

        public string sanswer { get; set; }

        public bool sendMail { get; set; }

        public Nullable<int> fbId { get; set; }
        public Nullable<int> rewardPoints { get; set; }

        #endregion Properties

        public bool Load(int id)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().Select(id);
            MapEntityToProperties(customer);
            return customer != null;
        }

        public bool Login(string email, string password)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().Login(email);
            string pw3;
            pw3 = customer.password.ToString();

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

        public bool FbLogin(int uid)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().FbLogin(uid);


            if (customer.email.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int GetIdbyFb(int uid)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().FbLogin(uid);

            if (customer.email.Length > 0)
            {
                return Convert.ToInt32(customer.customer_id);
            }
            else
            {
                return 0;
            }

        }

        public string GetEmailByFb(int uid)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().FbLogin(uid);

            if (customer.email.Length > 0)
            {
                return customer.email;
            }
            else
            {
                return null;
            }

        }

        public int getUserId(string email)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().Login(email); 
            return customer.customer_id; 
        }

        public string getShippingId(string email)
        {
            //Get the entity object from the DAL.
            customer customer = new customerData().Login(email);
            return customer.shippingRegion;
        }

        protected void MapEntityToProperties(customer entity)
        {
            //customer customer = new customer()entity;
            customer customer = (customer)entity;

            webstore_id = customer.webstore_id;

            customerid = customer.customer_id;  
 
            fname = customer.fname;

            lname = customer.lname;

            address1 = customer.address1;

            address2 = customer.address2;

            city = customer.city;

            region = customer.region;

            zip = customer.zip;

            country = customer.country;

            shippingRegion = customer.shippingRegion;

            dayPhone = Convert.ToDecimal(customer.dayPhone);

            cellPhone = Convert.ToDecimal(customer.cellPhone);

            evePhone = Convert.ToDecimal(customer.evePhone);

            creditCard = customer.creditCard;

            username = customer.username;

            password = customer.password;

            email = customer.email;

            squestion = customer.squestion;

            sanswer = customer.sanswer;

            fbId = customer.fbId;

            rewardPoints = customer.rewardPoints;
             
        }

        internal static void updateTotalPoints(int cId, int points)
        {
            int newPoints, oldPoints;
            customerEO cust = new customerEO();
            cust.Load(cId);
            newPoints = points;
            oldPoints = Convert.ToInt32(cust.rewardPoints);

            //check if new points are greater than old points
            if (newPoints > oldPoints)
            {
                newPoints -= oldPoints;
            }
            else
            {
                newPoints = 0;
            }
            cust.rewardPoints = newPoints;
            cust.Save(false); 
        }

        internal static int getTotalPoints(int cId)
        {
            customerEO cust = new customerEO();
            cust.Load(cId);
            return Convert.ToInt32(cust.rewardPoints);
          
        }

        public bool Save(bool newrec)
        { 
                    if (newrec)
                    {
                        //Add

                        customerid = new customerData().Insert(webstore_id, fname, lname, address1, address2, city, region, zip, country, shippingRegion, dayPhone, cellPhone, evePhone, creditCard, username, password, email, squestion, sanswer, sendMail, fbId, rewardPoints);

                    }
                    else
                    {
                    
                        //Update
                        if (!new customerData().Update(customerid, fname, lname, address1, address2, city, region, zip, country, shippingRegion, dayPhone, cellPhone, evePhone, creditCard, username, password, email, squestion, sanswer, sendMail, fbId, rewardPoints)) ;
                        {
                           
                            return false;
                        }
                    }

                    return true;

                
        }

        #region customerList

        [Serializable()]
    public class c_uomEOList : List<customerEO>
    {
        #region Overrides

        public void Load()
        {
            LoadFromList(new customerData().Select());
        }

        #endregion Overrides

        #region Private Methods

        private void LoadFromList(List<customer> customers)
        {
            if (customers.Count > 0)
            {
                foreach (customer customer in customers)
                {
                    customerEO newcustomerEO = new customerEO();
                    newcustomerEO.MapEntityToProperties(customer);
                    this.Add(newcustomerEO);
                }
            }
        }

        #endregion Private Methods

        #region Internal Methods

        #endregion Internal Methods
    }

    #endregion customerList

    }
}