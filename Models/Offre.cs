using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppRecrutement.Models
{
    //[Table("Offres")]
    public class Offre
    {
        public Offre()
        {
        }

        [Key]
        public Guid OffreID { get; set; }

        [Required]
        public string NomOffre { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        public string Region { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début")]
        public string Date_debut { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Qualités interpersonnelles")]
        public string Qualites_interpersonnelles { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Compétences techniques")]
        public string Competences_techniques { get; set; }

        [Required]
        [Display(Name = "Diplome démandé")]
        public string Diplome_demande { get; set; }

        [Required]
        [Display(Name = "Experience démandée")]
        public int Experience_demandee { get; set; }

        

        public long salaire { get; set; }

        [Display(Name = "Type de contrat")]
        public string Type_contrat { get; set; }

        public string departement { get; set; }

        

        public virtual Departement Departements { get; set; }

        [JsonIgnore]
        public virtual ICollection<Candidature> CandidaturesOffre { get; set; }

        
    }
}
