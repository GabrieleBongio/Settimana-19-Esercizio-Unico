using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult CheckUniqueUsername(string Username)
        {
            ModelDbContext dbContext = new ModelDbContext();
            Utenti Account = dbContext.Utenti.FirstOrDefault(m => m.Username == Username);

            if (Account == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
