using System.Web.Mvc;
using SimpleCRUD2.Loggers;

namespace SimpleCRUD2.Attributes
{
    public class HandleLoggerExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger.Log.Error(string.Empty, filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}