namespace Settimana_19_Esercizio_Unico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dettagli_Ordini
    {
        [Key]
        public int IdDettaglio { get; set; }

        public int IdOrdine { get; set; }

        public int IdArticolo { get; set; }

        public int Quantità { get; set; }

        public virtual Articoli Articoli { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}
