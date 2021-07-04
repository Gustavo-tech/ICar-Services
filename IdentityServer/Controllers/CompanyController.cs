using Microsoft.AspNetCore.Mvc;

namespace ICar.IdentityServer.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
