using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using seoWebApplication.st.SharkTankDAL; 
using seoWebApplication.st.SharkTankDAL.entObject;
using Facebook;
using System.Collections.Generic;

namespace seoWebApplication
{
    public partial class Register : System.Web.UI.Page
    {
        public bool errorCheck { get; set;}
        public bool displayError { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the title of the page
            this.Title = seoWebAppConfiguration.SiteName +
            " : Register";
            //LoadScreenFromObject();
            //string accessToken = (string)(Session["AccessToken"]);
            //string uid = (string)(Session["uid"]);
            //var accessToken = Session["AccessToken"].ToString();
           
            ////lets check if fb id exists
            //customerEO cust = new customerEO();
            
            //if (cust.FbLogin(Convert.ToInt32(uid)))
            //{
            //    Session["User"] = "true";
            //    Session["UserName"] = cust.GetEmailByFb(Convert.ToInt32(uid));
            //    Response.Redirect("/ShoppingCart.aspx");
            //}
            
            
            
        }
        private const string VIEW_STATE_KEY_customer = "customer";
         

        protected void LoadObjectFromScreen(customerEO Entity)
        {
           

            customerEO customer = (customerEO)Entity;

            if (txtfname.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>First name needs a value!";
                this.errorCheck = true;
            }

            customer.fname = txtfname.Text;

            if (txtlname.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Last Name needs a value!";
                this.errorCheck = true;
            }

            customer.lname = txtlname.Text;

            if (txtaddress1.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Address needs a value!";
                this.errorCheck = true;
            }

            customer.address1 = txtaddress1.Text;

            customer.address2 = txtaddress2.Text;

            if (txtcity.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>City needs a value!";
                this.errorCheck = true;
            }

            //if (hidFBid.Value.Length > 0)
            //{
            //    customer.fbId = Convert.ToInt32(hidFBid.Value);
            //}
            //else
            //{
            //    customer.fbId = 0;
            //}

            customer.city = txtcity.Text;

            customer.region = this.ddlRegion.SelectedValue;

            if (txtzip.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Zip needs a value!";
                this.errorCheck = true;
            }

            customer.zip = txtzip.Text;  

            customer.country = this.ddlCountries.SelectedValue;

            customer.shippingRegion = this.ddlCountries.SelectedValue;


            if (txtdayPhone.Text.Equals(""))
            {
                lblErrors.Text += "<br/>Check Day Phone";
                this.errorCheck = true;
            }

            customer.dayPhone = Convert.ToDecimal(txtdayPhone.Text);

            if (txtcellPhone.Text.Equals(""))
            {
                lblErrors.Text += "<br/>Check Cell Phone";
                this.errorCheck = true;
            }


            customer.cellPhone = Convert.ToDecimal(txtcellPhone.Text);


            if (txtevePhone.Text.Equals(""))
            {
                lblErrors.Text += "<br/>Check Evening Phone";
                this.errorCheck = true;
            }


            customer.evePhone = Convert.ToDecimal(txtevePhone.Text);

            customer.creditCard = "";

            customer.username = txtusername.Text;

            if (txtpassword.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Password needs a value!";
                this.errorCheck = true;
            }

            if (txtpassword.Text != txtpassword0.Text)
            {
                lblErrors.Text += "<br/>Password Do not match!";
                this.errorCheck = true;
            }

            string strPassword = phasher.Hash(txtpassword.Text);

            customer.password = strPassword;

            if (txtusername.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Email needs a value!";
                this.errorCheck = true;
            }

            if (txtusername.Text != txtemail.Text)
            {
                lblErrors.Text += "<br/>Check Email";
                this.errorCheck = true;
            }

            if (checkUsername(txtemail.Text))
            {
                lblErrors.Text += "<br/>Email exists";
                this.errorCheck = true;
            }

            customer.email = txtemail.Text;

            customer.squestion = ddlSecret.SelectedItem.Text.ToString();

            

            if (txtSecretAnswer.Text.Length.Equals(0))
            {
                lblErrors.Text += "<br/>Secret Answer needs a value!";
                this.errorCheck = true;
            }

            string strAnswer = phasher.Hash(txtSecretAnswer.Text);

            customer.sanswer = strAnswer;

            customer.sendMail = chkSendMail.Checked;

            customer.webstore_id = dBHelper.GetWebstoreId();
           
        }

        protected void LoadScreenFromObject()
        {

            //customerEO customer = new customerEO();
            //int id = 11;
            //customer.Load(id);
            var accessToken = Session["AccessToken"].ToString(); 
            try
            {
                // Using IDictionary<string, object> (.Net 3.5, .Net 4.0, WP7)
                var client = new FacebookClient(accessToken);
                var me = (IDictionary<string, object>)client.Get("me");
                string firstName = (string)me["first_name"];
                string lastName = (string)me["last_name"];
                string email = (string)me["email"];


                txtfname.Text = Convert.ToString(firstName);

                txtlname.Text = Convert.ToString(lastName);

                txtemail.Text = Convert.ToString(email);

                txtaddress1.Text = Convert.ToString(accessToken);
            }
            catch
            {

            }
            

            


            //txtaddress1.Text = Convert.ToString(customer.address1);

            //txtaddress2.Text = Convert.ToString(customer.address2);

            //txtcity.Text = Convert.ToString(customer.city);

            //txtregion.Text = Convert.ToString(customer.region);

            //txtzip.Text = Convert.ToString(customer.zip);

            ////txtcountry.Text = Convert.ToString(customer.country);

            ////txtshippingRegion.Text = Convert.ToString(customer.shippingRegion);

            //txtdayPhone.Text = Convert.ToString(customer.dayPhone);

            //txtcellPhone.Text = Convert.ToString(customer.cellPhone);

            //txtevePhone.Text = Convert.ToString(customer.evePhone);

            ////txtcreditCard.Text = Convert.ToString(customer.creditCard);

            //txtusername.Text = Convert.ToString(customer.username);

            //txtpassword.Text = Convert.ToString(customer.password);

            



            ////Put the object in the view state so it can be attached back to the data context.
            //ViewState[VIEW_STATE_KEY_customer] = customer;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!errorCheck)
                {
                    lblErrors.Text = "";
                    lblErrors.Text = "Please Check the following Errors:";
                    //customerEO customer = (customerEO)ViewState[VIEW_STATE_KEY_customer];
                    customerEO customer = new customerEO();
                    LoadObjectFromScreen(customer);
                    if (!errorCheck)
                    {
                        customer.Save(true);
                        Session["User"] = "true";
                        Session["UserName"] = txtusername.Text;
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        lblErrors.Text += "<br/>Please check errors";
                        displayError = true;
                    }
                }
                else
                {
                    lblErrors.Text = "Please check errors";
                    displayError = true;
                }
            
            }
            catch
            {
                if (errorCheck)
                { 
                    Session["User"] = "false";
                    lblErrors.Text += "<br/>There is a problem, please check your input";
                    errorCheck = false;
                    displayError = true;
                }
             
            }
            
            
        }

        public bool checkUsername(string username)
        {
            using (seowebappDataContextDataContext dc = new seowebappDataContextDataContext())
            {
                return Convert.ToBoolean(dc.customerSelectByUsername(username, dBHelper.GetWebstoreId()));
            }
        }

       
 
    }
}
