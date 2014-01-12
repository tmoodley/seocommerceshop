﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections;

namespace seoWebApplication.st.SharkTankDAL.Framework
{
    #region CustomGridView

    [ToolboxData("<{0}:CustomGridView runat=server></{0}:CustomGridView>")]
    public class CustomGridView : GridView
    {
        #region Members

        private ArrayList _methodParameters = new ArrayList();

        #endregion Members

        #region Constructor

        public CustomGridView()
        {
            AutoGenerateColumns = false;
            AllowPaging = true;
            AllowSorting = true;
            PageSize = 20;
            GridLines = GridLines.Both;
            HeaderStyle.CssClass = "gridViewHeader";
            RowStyle.CssClass = "gridViewRow";
            AlternatingRowStyle.CssClass = "gridViewAlternatingRow";
            PagerStyle.CssClass = "gridViewPager";                        
            CellPadding = 3;
        }

        #endregion Constructor

        #region Properties

        public string HasDT
        {
            get {
                if (ViewState["HasDT"] == null)
                {
                    //Default to displaytext
                    return "false";
                }

                else
                {
                    return ViewState["HasDT"].ToString(); 
                }
                    
            }
            set { ViewState["HasDT"] = value; }
        }

        public string ListClassName
        {
            get {
                if (ViewState["ListClassName"] == null)
                {
                    //Default to displaytext
                    return "false";
                }
                else
                { 
                return ViewState["ListClassName"].ToString();
                } 
            }
            set { ViewState["ListClassName"] = value; }
        }

        public string LoadMethodId
        {
            get { return ViewState["LoadMethodId"].ToString(); }
            set { ViewState["LoadMethodId"] = value; }
        }

        public string LoadMethodName
        {
            get { return ViewState["LoadMethodName"].ToString(); }
            set { ViewState["LoadMethodName"] = value; }
        }

        public string SortExpressionLast
        {
            get
            {
                if (ViewState["SortExpressionLast"] == null)
                    //Default to displaytext
                    return "DisplayText";

                else
                    return ViewState["SortExpressionLast"].ToString();
            }

            set { ViewState["SortExpressionLast"] = value; }
        }

        private SortDirection SortDirectionLast
        {
            get
            {
                if (ViewState["SortDirectionLast"] == null)
                    //Default to ascending
                    return SortDirection.Ascending;
                else
                    return (SortDirection)ViewState["SortDirectionLast"];
            }

            set { ViewState["SortDirectionLast"] = value; }
        }

        public ArrayList LoadMethodParameters
        {
            get
            {
                return _methodParameters;
            }
        }

        /// <summary>
        /// Set the ListClassName and LoadMethodName instead of the DataSource property
        /// </summary>
        /// 
       
        public new object DataSource
        {
            //set { throw new NotImplementedException(); }
            get { return ViewState["DataSource"]; }
            set { ViewState["DataSource"] = value; }
        }
        
        #endregion Properties
        
        #region Overrides
        
        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            PageIndex = e.NewPageIndex;

            //Use the sorting stored in view state
            BindGridView(SortExpressionLast, SortDirectionLast);
        }

        protected override void OnSorting(GridViewSortEventArgs e)
        {
            //Start at the first page whenever the user sorts.
            PageIndex = 0;

            //Check if the field being sorted is the same as last time.
            if (e.SortExpression == SortExpressionLast)
            {
                //Reverse the direction.
                if (SortDirectionLast == SortDirection.Ascending)
                {
                    BindGridView(e.SortExpression, SortDirection.Descending);
                }
                else
                {
                    BindGridView(e.SortExpression, SortDirection.Ascending);
                }
            }
            else
            {
                //Default to Ascending
                BindGridView(e.SortExpression, SortDirection.Ascending);
            }
        }

        public new void DataBind()
        {
            BindGridView(SortExpressionLast, SortDirectionLast);
        }

        #endregion Override
        
        #region Methods

        private void BindGridView(string sortExpression, SortDirection sortDirection)
        { 
            if (Convert.ToBoolean(this.HasDT))
            {
               
                base.DataSource = this.DataSource;
               
 
            }
            else
            {
                //Create an instance of the list object
                Type objectType = Type.GetType(ListClassName);
                object listObject = Activator.CreateInstance(objectType);
            
                //Call the method to load the object
                //objectType.InvokeMember(LoadMethodName, BindingFlags.InvokeMethod, null, listObject, new object[] { });
                objectType.InvokeMember(LoadMethodName, BindingFlags.InvokeMethod, null, listObject, _methodParameters.ToArray());

                //Call the SortByPropertyName method.  This is in the ENTBaseBOList class.  The object must inherit
                //from this class.
                 
                base.DataSource = objectType.InvokeMember("SortByPropertyName", BindingFlags.InvokeMethod, null, listObject, new object[] { sortExpression, sortDirection == SortDirection.Ascending });
                  
                objectType = null;
                listObject = null;
            }
             base.DataBind();

            //Save the sortExpression and sortDirection to the view state.
            SortExpressionLast = sortExpression;
            SortDirectionLast = sortDirection;

            
        }

        public void AddBoundField(string dataField, string headerText, string sortExpression)
        {
            BoundField bf = new BoundField();
            if (dataField != "")
            {
                bf.DataField = dataField;
            }

            if (headerText != "")
            {
                bf.HeaderText = headerText;
            }

            if (sortExpression != "")
            {
                bf.SortExpression = sortExpression;
            }

            Columns.Add(bf);
        }

        #endregion Methods
    }

    #endregion CustomGridView

    

}
