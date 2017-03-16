using LinkManager.UI.Models;
using System.Web;
using System.Web.Mvc;

namespace LinkManager.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyActionFilterAttribute());
        }
    }
}