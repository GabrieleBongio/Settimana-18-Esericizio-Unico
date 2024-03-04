using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esericizio_Unico
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
