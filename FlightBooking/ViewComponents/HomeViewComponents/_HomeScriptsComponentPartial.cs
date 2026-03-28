using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.HomeViewComponents
{
    public class _HomeScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
