using Microsoft.AspNetCore.Mvc;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
