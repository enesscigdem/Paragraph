using Microsoft.AspNetCore.Mvc;

namespace Paragraph.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}