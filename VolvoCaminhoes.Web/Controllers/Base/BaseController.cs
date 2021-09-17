using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VolvoCaminhoes.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IActionResult ReturnView()
        {
            if (HttpExtensions.IsAjaxRequest(Request))
                return PartialView();
            else
                return View();
        }
        protected IActionResult ReturnView(object obj)
        {
            if (HttpExtensions.IsAjaxRequest(Request))
                return PartialView(obj);
            else
                return View(obj);
        }

        protected IActionResult ReturnView(string viewName)
        {
            if (HttpExtensions.IsAjaxRequest(Request))
                return PartialView(viewName);
            else
                return View(viewName);
        }
        protected IActionResult ReturnView(string viewName, object obj)
        {
            if (HttpExtensions.IsAjaxRequest(Request))
                return PartialView(viewName, obj);
            else
                return View(viewName, obj);
        }
    }
    public static class HttpExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                return false;
            else if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}