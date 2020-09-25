using System.Web;
using System.Web.Mvc;

namespace Sagar_Dudhaiya_Practicel_Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
