using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.HomeViewComponents
{
    public class _HomeFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
