using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdeaClub.Controllers
{
    public class UserPageTabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Photos()
        {
            return PartialView("_Photos");
        }
    }
}