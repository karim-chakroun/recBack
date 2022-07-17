using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRecrutement.Models
{
    //[Table("TestTechniques")]
    public class TestTechnique
    {
        public TestTechnique()
        {
        }

        [Key]
        public Guid TestID { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse e-mail de distinataire")]
        public string Destination { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de dépot")]
        public string Date_depot { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        public string Duree { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "lien de test")]
        public string lien_test { get; set; }

        public virtual Candidature Test { get; set; }
    }
}
