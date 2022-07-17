using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static AppRecrutement.Enums.Enums;

namespace AppRecrutement.Models
{
    //[Table("Candidatures")]
    public class Candidature
    {
            public Candidature()
            {
            }

            [Key]
            public Guid CandidatureID { get; set; }


            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Date de postulation")]
            public string Date_postulation { get; set; }


            public string Etat { get; set; }


            [Required]
            [Display(Name = "Curriculum Vitae")]
            public string Curriculum_Vitae { get; set; }

            public float Score { get; set; }
            public Guid OffreFK { get; set; }
            public string CandidatFK { get; set; }
            [ForeignKey("CandidatFK")]

            public virtual ApplicationUser Candidat { get; set; }

            [ForeignKey("OffreFK")]
            
            public virtual Offre Correspondance { get; set; }
            public virtual ICollection<TestTechnique> Tests { get; set; }
            public virtual ICollection<EntretienRH> EntretienRHs { get; set; }
    }
    
}
