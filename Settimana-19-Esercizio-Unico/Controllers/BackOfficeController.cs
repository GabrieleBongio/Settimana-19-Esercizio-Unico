using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NumeroOrdiniEvasi(DateTime dateTime)
        {
            TempData["Data"] = dateTime;

            ModelDbContext dbContext = new ModelDbContext();
            int NumeroOrdiniEvasi = dbContext
                .Ordini.Where(m => m.Data == dateTime && m.Evaso == true)
                .Count();
            TempData["NumeroOrdiniEvasi"] = NumeroOrdiniEvasi;

            decimal TotaleIncasso = 0;

            if (NumeroOrdiniEvasi > 0)
            {
                TotaleIncasso = dbContext
                    .Ordini.Where(m => m.Data == dateTime && m.Evaso == true)
                    .Sum(m => m.Importo);
            }

            TempData["TotaleIncasso"] = TotaleIncasso;

            return RedirectToAction("Index");
        }
    }
}
