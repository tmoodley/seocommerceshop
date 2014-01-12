using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using seoWebApplication.st.SharkTankDAL;
using seoWebApplication.st.SharkTankDAL.dataObject;
using seoWebApplication.st.SharkTankDAL.Framework; 
using System.Web.UI.HtmlControls;

namespace seoWebApplication.st.SharkTankDAL
{    
    [ToolboxData("<{0}:ValidationErrorMessages runat=server></{0}:ValidationErrorMessages>")]
    public class ValidationErrorMessages : WebControl
    {
        #region Constructor

        public ValidationErrorMessages()
        {
            ValidationErrors = new ENTValidationErrors();
        }

        #endregion Constructor

        #region Properties

        [Bindable(false),
        Browsable(false)]
        public ENTValidationErrors ValidationErrors { get; set; }

        #endregion Properties

        #region Methods

        /// <summary> 
        /// Render this control to the output parameter specified.
        /// </summary>
        /// <param name="output"> The HTML writer to write out to </param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            //Show all the messages in the ENTValidationErrorsAL

            //Check if there are an items in the array list
            if (ValidationErrors.Count != 0)
            {
                //There are items so create a table with the list of messages.
                HtmlTable table = new HtmlTable();

                HtmlTableRow trHeader = new HtmlTableRow();
                HtmlTableCell tcHeader = new HtmlTableCell();
                tcHeader.InnerText = "Please review the following issues:";
                tcHeader.Attributes.Add("class", "validatioErrorMessageHeader");
                trHeader.Cells.Add(tcHeader);
                table.Rows.Add(trHeader);

                foreach (ENTValidationError ve in ValidationErrors)
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell tc = new HtmlTableCell();
                    tc.InnerText = ve.ErrorMessage;
                    tc.Attributes.Add("class", "validationErrorMessage");
                    tr.Cells.Add(tc);
                    table.Rows.Add(tr);
                    tc = null;
                    tr = null;
                }

                table.RenderControl(output);
                tcHeader = null;
                trHeader = null;
                table = null;
            }
            else
            {
                //Write nothing.
                output.Write("");
            }
        }

        #endregion Methods
    }
}
