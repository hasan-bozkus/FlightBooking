using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.HomeViewComponents
{
    public class _HomeServiceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
