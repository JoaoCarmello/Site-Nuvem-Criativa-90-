using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Controllers
{
    public class CentralController : Controller
    {
        private readonly ILogger<CentralController> _logger;
        //private readonly siteNuvemCriativa90DBContext _context;

        public CentralController(ILogger<CentralController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
