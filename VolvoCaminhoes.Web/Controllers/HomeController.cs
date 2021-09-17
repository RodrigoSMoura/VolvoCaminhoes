using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using VolvoCaminhoes.Web.Controllers.Base;
using VolvoCaminhoes.Web.Models;

namespace VolvoCaminhoes.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return ReturnView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
