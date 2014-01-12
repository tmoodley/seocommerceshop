using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL;

namespace seoWebApplication.UserControls
{
    public partial class AccordianRestaurantHours : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateControls();
            }
            catch (Exception ex)
            {
                Response.Write("Exception Occured:   " + ex);
            }
        }

        // Fill the page with data
        private void PopulateControls()
        {

            webstoreEO w = new webstoreEO();
            w.Load(dBHelper.GetWebstoreId());
          
            ckMonday.Checked = w.monday;
            lblMonBreakfastHrs.Text = w.monBreakfastEnd + " - " + w.monBreakfastStart;
            ckMonLunch.Checked = w.monLunch;
            lblMonLunchHrs.Text = w.monLunchStart + " - " + w.monLunchEnd;
            ckMonDinner.Checked = w.monDinner;
            lblMonDinner.Text = w.monDinnerStart + " - " + w.monDinnerEnd;

            ckTueBreakfast.Checked = w.tuesday;
            lblTueBreakFast.Text = w.tueBreakfastStart + " - " + w.tueBreakfastEnd;
            ckTueLunch.Checked = w.tuesLunch;
            lblTueLunch.Text = w.tueLunchStart + " - " + w.tueLunchEnd;
            ckTueDinner.Checked = w.tuesDinner;
            lblTueDinner.Text = w.tueDinnerStart + " - " + w.tueDinnerEnd;

            ckWedBreakfast.Checked = w.wednesday;
            lblWedBreakfast.Text = w.wedBreakfastStart + " - " + w.wedBreakfastEnd;
            ckWedLunch.Checked = w.wedLunch;
            lblWedLunch.Text = w.wedLunchStart + " - " + w.wedLunchEnd;
            ckWedDinner.Checked = w.wedDinner;
            lblWedDinner.Text = w.wedDinnerStart + " - " + w.wedDinnerEnd;

            ckThrBreakfast.Checked = w.thursday;
            lblThrBreakfast.Text = w.thrBreakfastStart + " - " + w.thrBreakfastEnd;
            ckThrLunch.Checked = w.thrLunch;
            lblThrLunch.Text = w.thrLunchStart + " - " + w.thrLunchEnd;
            ckThrDinner.Checked = w.thrDinner;
            lblThrDinner.Text = w.thrDinnerStart + " - " + w.thrDinnerEnd;

            ckFriBreakfast.Checked = w.friday;
            lblFriBreakfast.Text = w.friBreakfastStart + " - " + w.friBreakfastEnd;
            ckFriLunch.Checked = w.friLunch;
            lblFriLunch.Text = w.friLunchStart + " - " + w.friLunchEnd;
            ckFriDinner.Checked = w.friDinner;
            lblFriDinner.Text = w.friDinnerStart + " - " + w.friDinnerEnd;

            ckSatBreakfast.Checked = w.saturday;
            lblSatBreakfast.Text = w.satBreakfastStart + " - " + w.satBreakfastEnd;
            ckSatLunch.Checked = w.satLunch;
            lblSatLunch.Text = w.satLunchStart + " - " + w.satLunchEnd;
            ckSatDinner.Checked = w.satDinner;
            lblSatDinner.Text = w.satDinnerStart + " - " + w.satDinnerEnd;

            ckSunBreakfast.Checked = w.sunday;
            lblSunBreakfast.Text = w.sunBreakfastStart + " - " + w.sunBreakfastEnd;
            ckSunLunch.Checked = w.sunLunch;
            lblSunLunch.Text = w.sunLunchStart + " - " + w.sunLunchEnd;
            ckSunDinner.Checked = w.sunDinner;
            lblSunDinner.Text = w.sunDinnerStart + " - " + w.sunDinnerEnd;




        }
    }
}