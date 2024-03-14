using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_19_Esercizio_Unico.Models;

namespace Settimana_19_Esercizio_Unico.Controllers
{
    [Authorize]
    public class CarrelloController : Controller
    {
        // GET: Carrello
        public ActionResult Index()
        {
            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;
            TempData.Keep("Carrello");

            if (carrello == null || carrello.Count < 1)
            {
                carrello = new List<ElementoCarrello>();
                TempData["Info"] = "Non ci sono elementi nel carrello";
            }

            return View(carrello);
        }

        public ActionResult AggiungiAlCarrello(int idArticolo, int quantità)
        {
            ModelDbContext context = new ModelDbContext();
            Articoli articolo = context.Articoli.Find(idArticolo);

            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;

            if (carrello == null)
            {
                carrello = new List<ElementoCarrello>();

                ElementoCarrello elem = new ElementoCarrello(articolo, quantità);

                carrello.Add(elem);
            }
            else
            {
                bool giaPresente = false;
                foreach (ElementoCarrello c in carrello)
                {
                    if (c.Articolo.IdArticolo == idArticolo)
                    {
                        c.Quantità += quantità;
                        giaPresente = true;
                    }
                }
                if (!giaPresente)
                {
                    ElementoCarrello elem = new ElementoCarrello(articolo, quantità);
                    carrello.Add(elem);
                }
            }

            TempData["Carrello"] = carrello;
            TempData["Info"] = "Articolo aggiunto al carrello";

            return RedirectToAction("Index", "Menù");
        }

        public ActionResult AggiungiUno(int idArticolo)
        {
            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;
            foreach (ElementoCarrello c in carrello)
            {
                if (c.Articolo.IdArticolo == idArticolo)
                {
                    c.Quantità += 1;
                }
            }
            TempData["Carrello"] = carrello;

            return RedirectToAction("Index");
        }

        public ActionResult RimuoviUno(int idArticolo)
        {
            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;
            List<ElementoCarrello> carrelloNuovo = new List<ElementoCarrello>();
            foreach (ElementoCarrello c in carrello)
            {
                if (c.Articolo.IdArticolo == idArticolo)
                {
                    if (c.Quantità != 1)
                    {
                        c.Quantità -= 1;
                        carrelloNuovo.Add(c);
                    }
                }
                else
                {
                    carrelloNuovo.Add(c);
                }
            }
            TempData["Carrello"] = carrelloNuovo;

            return RedirectToAction("Index");
        }

        public ActionResult Rimuovi(int idArticolo)
        {
            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;
            List<ElementoCarrello> carrelloNuovo = new List<ElementoCarrello>();
            foreach (ElementoCarrello c in carrello)
            {
                if (c.Articolo.IdArticolo != idArticolo)
                {
                    carrelloNuovo.Add(c);
                }
            }
            TempData["Carrello"] = carrelloNuovo;

            return RedirectToAction("Index");
        }

        public ActionResult DatiPersonali()
        {
            if (TempData.ContainsKey("Carrello"))
            {
                return View();
            }
            else
            {
                TempData["Error"] = "Non è possibile procedere con un ordine vuoto";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ConfermaOrdine(string indirizzo, string noteUtili)
        {
            ModelDbContext dbContext = new ModelDbContext();
            Utenti utente = dbContext.Utenti.First(m => m.Username == User.Identity.Name);
            int Ultimo = dbContext.Ordini.Max(m => m.IdOrdine);

            List<ElementoCarrello> carrello = TempData["Carrello"] as List<ElementoCarrello>;
            decimal importo = 0;

            foreach (ElementoCarrello c in carrello)
            {
                importo += c.Articolo.Prezzo * c.Quantità;
            }

            Ordini nuovoOrdine = new Ordini();
            nuovoOrdine.IdUtente = utente.IdUtente;
            nuovoOrdine.Importo = importo;
            nuovoOrdine.Indirizzo = indirizzo;
            nuovoOrdine.NoteUtili = noteUtili;

            dbContext.Ordini.Add(nuovoOrdine);
            dbContext.SaveChanges();

            foreach (ElementoCarrello c in carrello)
            {
                Dettagli_Ordini dettaglio = new Dettagli_Ordini()
                {
                    IdOrdine = Ultimo + 1,
                    IdArticolo = c.Articolo.IdArticolo,
                    Quantità = c.Quantità
                };

                dbContext.Dettagli_Ordini.Add(dettaglio);
            }
            dbContext.SaveChanges();

            TempData["Info"] = "Ordine effettuato con successo";
            return RedirectToAction("Index", "Home");
        }
    }
}
