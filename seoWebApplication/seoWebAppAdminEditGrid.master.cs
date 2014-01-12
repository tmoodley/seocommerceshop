using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.Framework;
using System.Text;

namespace seoWebApplication
{
    public partial class seoWebAppAdminEditGrid : System.Web.UI.MasterPage
    {
        public delegate void ButtonClickedHandler(object sender, EventArgs e);
        public delegate void SelectedIndexChanged (object sender, EventArgs e);

        public event SelectedIndexChanged ddlClickEvent_Click;
        public event ButtonClickedHandler AddButton_Click;
        public string RootPath { get; set; }
        public string CurrentMenuItemName { get; set; }
        //Chapter 9: Reporting
        public event ButtonClickedHandler PrintButton_Click;
        public event ButtonClickedHandler AddSearch_Click;
        public string change_ddlArea
        {
            get { return ddlFilter.SelectedItem.Value; }
            set { ddlFilter.Items.FindByValue(value).Selected = true; }
        }

        public string searchBox
        {
            get { return txtSearch.Text; } 
        }

        public string displayBox { get; set; }
         

        public DropDownList SearchList
        {
            get { return ddlFilter; }
        }

        public PlaceHolder SearchPh
        {
            get { return filterHolder; }
        }

        protected void ddlSearch_Click(object sender, EventArgs e)
        {
            if (ddlClickEvent_Click != null)
            {
                ddlClickEvent_Click(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (AddSearch_Click != null)
            {
                AddSearch_Click(sender, e);
            }
        }
         
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (AddButton_Click != null)
            {
                AddButton_Click(sender, e);
            }
        }

        //Chapter 9: Reporting
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (PrintButton_Click != null)
            {
                PrintButton_Click(sender, e);
            }
        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_ddlArea = this.ddlFilter.SelectedValue;
            if (ddlClickEvent_Click != null)
            {
                ddlClickEvent_Click(sender, e);
            }
        }

        

         

      
    }
}
