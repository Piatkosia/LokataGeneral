using Lokata.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lokata.Web.Controllers
{
    public class PopableController : Controller
    {
        public void SuccessPopup(string message = "Zapisało się!")
        {
            var x = new Message() { CssClassName = "alert-success", Title = "Sukces!", DisplayMessage = message };
            TempData["UserMessage"] = JsonConvert.SerializeObject(x);
        }

        public void FailedPopup(string message = "Coś nie wyszło:(")
        {
            var x = new Message() { CssClassName = "alert-warning", Title = "Sukces!", DisplayMessage = message };
            TempData["UserMessage"] = JsonConvert.SerializeObject(x);
        }
    }
}
