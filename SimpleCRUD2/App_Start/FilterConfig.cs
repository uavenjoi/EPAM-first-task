using System.Web.Mvc;
using SimpleCRUD2.Attributes;

namespace SimpleCRUD2.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleLoggerExceptionAttribute());
        }
    }
}