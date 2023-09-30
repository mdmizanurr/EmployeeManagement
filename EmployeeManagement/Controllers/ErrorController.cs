using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404 :
                    ViewBag.ErrorMessage = "Sorry, the resourse you requested could nor found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;

                    break;

                case 405:
                    ViewBag.ErrorMessage = "Sorry, the resourse you requested could nor found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;

                    break;
            }


            return View("NotFound");
        }


        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptioDetals = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptioDetals.Path;
            ViewBag.ExceptionMessage = exceptioDetals.Error.Message;
            ViewBag.StackTrace = exceptioDetals.Error.StackTrace;

            return View("Error");

        }
    }
}
