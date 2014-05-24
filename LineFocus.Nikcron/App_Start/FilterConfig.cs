using System.Web;
using System.Web.Mvc;

namespace LineFocus.Nikcron
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}