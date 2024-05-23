using Microsoft.AspNetCore.Mvc;

namespace ASP_LR_5_Kyrylenko_402
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookie(string value, string expiry)
        {
            Response.Cookies.Append("MyCookie", value, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = System.DateTime.Parse(expiry)
            });

            return RedirectToAction("Index");
        }

        public IActionResult CheckCookie()
        {
            var value = Request.Cookies["MyCookie"];
            ViewBag.CookieValue = value ?? "cookie not found";
            return View();
        }

        public IActionResult SimulateError()
        {
            int x = 0;
            int result = 10 / x;
            return View();
        }
    }
}
