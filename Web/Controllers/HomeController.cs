using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    /// <summary>
    /// The main HomeController  class.
    /// Contains basic methods.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        /// <summary>
        /// The main constuctor.
        /// </summary>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Return view.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}