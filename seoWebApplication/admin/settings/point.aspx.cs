using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework;

namespace seoWebApplication.admin.settings
{
public partial class point : SEOBaseEditPage<pointsEO>
{
    private const string VIEW_STATE_KEY_points = "points";
    protected void Page_Load(object sender, EventArgs e)
    { 
            //check to see if the webstore has an existing id
            int pointId;
            pointId = pointsEO.checkEntry();
            int getId = GetId();
            if (pointId > 0)
            {
                //reload page with the correct id. 
                if (getId == 0)
                { 
                Response.Redirect("point.aspx" + EncryptQueryString("id=" + pointId));
                }  
            }
            else
            {
                if (getId > 0)
                {
                    //reload page with the correct id. 
                    Response.Redirect("point.aspx" + EncryptQueryString("id=" + pointId));
                }
                else
                { 
                 //reload page with the correct id. 
                //Response.Redirect("point.aspx" + EncryptQueryString("id=0&newRec=true"));
                }
               
            }
         
        Master.SaveButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_SaveButton_Click);
        Master.CancelButton_Click += new seoWebAppAdminEditPage.ButtonClickedHandler(Master_CancelButton_Click);

    }
    void Master_CancelButton_Click(object sender, EventArgs e)
    {
        GoToGridPage();
    }
    void Master_SaveButton_Click(object sender, EventArgs e)
    {
        ENTValidationErrors validationErrors = new ENTValidationErrors();
        pointsEO points = (pointsEO)ViewState[VIEW_STATE_KEY_points];
        LoadObjectFromScreen(points);
        if (!points.Save(ref validationErrors, 1))
        {
            //Master.ValidationErrors = validationErrors;
        }
        else
        {
            GoToGridPage();
        }
    }

    protected override void LoadObjectFromScreen(pointsEO baseEO)
    {

        baseEO.webstore_id = Convert.ToInt32(txtwebstore_id.Text);

        baseEO.Name = txtName.Text;

        baseEO.ConversionRate = txtConversionRate.Text;

        baseEO.Point = Convert.ToInt32(txtPoint.Text);

        baseEO.Percentage = Convert.ToDecimal(txtPercentage.Text);

        baseEO.Active = chkActive.Checked;
    }

    protected override void LoadScreenFromObject(pointsEO baseEO)
    {

        txtwebstore_id.Text = Convert.ToString(baseEO.webstore_id);

        txtName.Text = Convert.ToString(baseEO.Name);

        txtConversionRate.Text = Convert.ToString(baseEO.ConversionRate);

        txtPoint.Text = Convert.ToString(baseEO.Point);

        decimal myPercentage = baseEO.Percentage;

        txtPercentage.Text = Convert.ToString(Math.Round(Convert.ToDecimal(myPercentage), 2));

        chkActive.Checked = baseEO.Active;
        //Put the object in the view state so it can be attached back to the data context.
        ViewState[VIEW_STATE_KEY_points] = baseEO;
    }

    protected override void LoadControls()
    {
    }
    protected override void GoToGridPage()
    {
        Response.Redirect("point.aspx");
    }
    public override string MenuItemName()
    {
        return "points";
    }
}
}
