using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Adoptie
    {
        public int ID { get; set; } // Cheie primara
        [Display(Name = "Copil")]

        public int? CopilID { get; set; } // Cheie straina catre clasa Copil
        
        public Copil? Copil { get; set; } // Relatie cu clasa Copil
        [Display(Name = "Adoptator")]

        public int? AdoptatorID { get; set; } // Cheie straina catre clasa Adoptator
       
        public Adoptator? Adoptator { get; set; } // Relatie cu clasa Adoptator
       
        [Display(Name = "Data adoptiei")]
        [DataType(DataType.Date)] // Format camp data
        [Required(ErrorMessage = "Data adoptiei este obligatorie!")]
        public DateTime DataAdoptiei { get; set; } // Data adoptiei

        [Display(Name = "Stare adoptie")]
        [Required(ErrorMessage = "Starea adoptiei este obligatorie!")]
        public string StareAdoptie { get; set; } // Starea adoptiei (in derulare, finalizata etc.)
    }

}
