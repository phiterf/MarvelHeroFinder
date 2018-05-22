using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteAcerto.Models;
using TesteAcerto.Repositories;

namespace TesteAcerto.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}