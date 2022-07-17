using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRecrutement.Models
{
    //[Table("Departements")]
    public class Departement
    {
        public Departement()
        {
        }

        [Key]
        public Guid DepartementID { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Offre> Offres { get; set; }
    }
}
