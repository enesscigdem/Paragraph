using Microsoft.AspNetCore.Mvc;

namespace Paragraph.WebApp.Areas.Student.Controllers
{
    [Area("Student")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}