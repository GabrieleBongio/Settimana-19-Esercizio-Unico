namespace Settimana_19_Esercizio_Unico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors"
        )]
        public Ordini()
        {
            Dettagli_Ordini = new HashSet<Dettagli_Ordini>();
        }

        [Key]
        public int IdOrdine { get; set; }

        public int IdUtente { get; set; }

        [Column(TypeName = "money")]
        public decimal Importo { get; set; }

        [Required]
        [StringLength(50)]
        public string Indirizzo { get; set; }

        public string NoteUtili { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public bool Evaso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly"
        )]
        public virtual ICollection<Dettagli_Ordini> Dettagli_Ordini { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
