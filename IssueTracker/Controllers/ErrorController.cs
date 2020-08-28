using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.Message = "The requested resources could not be found";
                    break;
                default:
                    break;
            }
            return View("Not Found");
        }
    }
}
