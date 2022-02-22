using Contact_Manager_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contact_Manager_Test.Controllers
{
    [Route("Error/{code}")]
    public class ErrorsController : Controller
    {
        public IActionResult Index(int code)
        {
            var errorViewModel = new ErrorViewModel(code)
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            switch (code)
            {
                case 400:
                    errorViewModel.Message = "Bad request was maded";
                    break;
                case 404:
                    errorViewModel.Message = "Page not found";
                    break;
                case 500:
                    errorViewModel.Message = "Server error";
                    break;
                default:
                    errorViewModel.Message = "Error occurred while processing your request";
                    break;
            };

            return View("Error", errorViewModel);
        }
    }
}
