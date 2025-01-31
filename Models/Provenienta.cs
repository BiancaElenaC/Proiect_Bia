using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Provenienta
    {
        public int ID { get; set; } // Cheie primara

        [Display(Name = "Tip provenienta")]

        [Required(ErrorMessage = "Provenienta este obligatorie!")]
       
        public string TipProvenienta { get; set; } // Tipul provenientei (Abandon, Preluare etc.)
       
        public ICollection<Copil>? Copii { get; set; } // Relatie cu clasa Copil
    }

}
