using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace AppRecrutement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column]
        public string FullName { get; set; }

        [Column]
        public string Pays { get; set; }

        [Column]
        public string Ville { get; set; }

        [Column]
        [Display(Name = "Niveau d'étude")]
        public string Niveau_etude { get; set; }

        

        [Column]
        public string Specialite { get; set; }


        [Column]
        [Display(Name = "Nombre d'années d'expérience")]
        public int Nb_annees_experience { get; set; }

        [Column]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de naissance")]
        public string Date_naissance { get; set; }

        [JsonIgnore]
        public virtual ICollection<Candidature> Candidatures { get; set; }

        

        

    }
}
