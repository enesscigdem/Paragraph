using Microsoft.AspNetCore.Mvc;
using Paragraph.Core.Models;
using Paragraph.WebApp.Areas.Admin.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Paragraph.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DashboardController : Controller
    {
        private readonly HttpClient _httpClient;
        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("DefaultApi");
        }

        public async Task<IActionResult> Index()
        {
            // API'den DashboardDto çekiliyor.
            var dashboardDto = await _httpClient.GetFromJsonAsync<DashboardDto>("api/dashboard") ?? new DashboardDto();

            // DashboardDto'yu DashboardViewModel'e map ediyoruz.
            var viewModel = new DashboardViewModel
            {
                TotalCourses = dashboardDto.TotalCourses,
                TotalLessons = dashboardDto.TotalLessons,
                TotalWordCards = dashboardDto.TotalWordCards,
                TotalOrders = dashboardDto.TotalOrders,
                TotalRevenue = dashboardDto.TotalRevenue,
                EducationSales = dashboardDto.EducationSales,
                PendingPayments = dashboardDto.PendingPayments,
                IncomingMessages = dashboardDto.IncomingMessages,
                TotalUsers = dashboardDto.TotalUsers,
                TotalRoles = dashboardDto.TotalRoles,
                TotalProducts = dashboardDto.TotalProducts,
                TotalReports = dashboardDto.TotalReports,
                TotalMessagesAll = dashboardDto.TotalMessagesAll,
                LastOrders = dashboardDto.LastOrders.Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName,
                    CustomerEmail = o.CustomerEmail,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                }).ToList()
            };

            return View(viewModel);
        }
    }
}
