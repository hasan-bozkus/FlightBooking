using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.HomeViewComponents
{
    public class _HomeFrequantlyAskedQuestionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
