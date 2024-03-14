using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_19_Esercizio_Unico.Models
{
    public class ElementoCarrello
    {
        public Articoli Articolo { get; set; }

        public int Quantità { get; set; }

        public ElementoCarrello(Articoli articolo, int quantità)
        {
            Articolo = articolo;
            Quantità = quantità;
        }
    }
}
