using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace seoWebApplication.st.SharkTankDAL
{
    #region ENTValidationError
    /// <summary>
    /// This class contains the error message when a validation rule is broken
    /// A validation error object should be created when validating input from the user and 
    /// you want to display a message back to the user.
    /// </summary>
    public class ENTValidationError
    {
        public ENTValidationError() { }

        public string ErrorMessage { get; set;}
    }

    #endregion ENTValidationError

    #region ENTValidationErrors

    /// <summary>
    /// This class contains a list of validation errors.  This allows you to report back multiple errors.
    /// </summary>
    public class ENTValidationErrors : List<ENTValidationError>
    {               
        public void Add(string errorMessage)
        {            
            base.Add(new ENTValidationError { ErrorMessage = errorMessage });
         
        }
    }

    #endregion ENTValidationErrors
}
