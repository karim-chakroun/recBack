using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRecrutement.Models
{
    //[Table("EntretienRHs")]
    public class EntretienRH
    {
        public EntretienRH()
        {
        }

        [Key]
        public Guid EntretienID { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse e-mail de distinataire")]
        public string Destination { get; set; }

        [Display(Name = "Equipe de recrutement")]
        public string Equipe_recrutement { get; set; }

        public string Type_entretien { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Localisation { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        public string Duree { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public int Heure { get; set; }

        public virtual Candidature RendezVous { get; set; }
    }
}
