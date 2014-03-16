using ChameleonForms.ModelBinders;
using System;
using System.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(seoWebApplication.App_Start.RegisterChameleonFormsComponents), "Start")]
 
namespace seoWebApplication.App_Start
{
    public static class RegisterChameleonFormsComponents
    {
        public static void Start()
        {
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
        }
    }
}
