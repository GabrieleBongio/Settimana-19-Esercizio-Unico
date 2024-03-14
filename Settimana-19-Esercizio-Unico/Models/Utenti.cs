namespace Settimana_19_Esercizio_Unico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Utenti")]
    public partial class Utenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors"
        )]
        public Utenti()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int IdUtente { get; set; }

        [Required]
        [StringLength(30)]
        [Remote(
            "CheckUniqueUsername",
            "Validation",
            ErrorMessage = "Questo Username è già stato registrato"
        )]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public bool Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly"
        )]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
