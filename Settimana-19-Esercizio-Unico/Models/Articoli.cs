namespace Settimana_19_Esercizio_Unico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articoli")]
    public partial class Articoli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors"
        )]
        public Articoli()
        {
            Dettagli_Ordini = new HashSet<Dettagli_Ordini>();
        }

        [Key]
        public int IdArticolo { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Prezzo { get; set; }

        [Required]
        [Display(Name = "Tempo di Consegna")]
        [DataType(DataType.Time)]
        public TimeSpan TempoConsegna { get; set; }

        [Required]
        [StringLength(200)]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly"
        )]
        public virtual ICollection<Dettagli_Ordini> Dettagli_Ordini { get; set; }
    }
}
