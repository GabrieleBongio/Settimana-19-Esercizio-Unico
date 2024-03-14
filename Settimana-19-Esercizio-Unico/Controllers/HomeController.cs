using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti u)
        {
            ModelDbContext dbContext = new ModelDbContext();
            Utenti account = dbContext.Utenti.FirstOrDefault(m => m.Username == u.Username);

            if (account != null)
            {
                if (account.Password != u.Password)
                {
                    ViewBag.Error = "Password Sbagliata";
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Nessun account con questo Username";
                return View();
            }
        }

        public ActionResult Registrati()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrati(Utenti u)
        {
            ModelDbContext dbContext = new ModelDbContext();
            dbContext.Utenti.Add(u);
            dbContext.SaveChanges();
            TempData["Registrato"] =
                "Account Registrato con successo, esegui il login per entrare nell'applicazione";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
