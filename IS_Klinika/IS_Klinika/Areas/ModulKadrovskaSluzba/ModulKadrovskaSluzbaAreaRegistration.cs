using System.Web.Mvc;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba
{
    public class ModulKadrovskaSluzbaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulKadrovskaSluzba";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulKadrovskaSluzba_default",
                "ModulKadrovskaSluzba/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}