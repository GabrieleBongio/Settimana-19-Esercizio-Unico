using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    public class MenùController : Controller
    {
        // GET: Menù
        public ActionResult Index()
        {
            ModelDbContext context = new ModelDbContext();
            return View(context.Articoli.ToList());
        }
    }
}
