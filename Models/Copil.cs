using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Copil
    
    {
            public int ID { get; set; } // Cheie primara

            [Required(ErrorMessage = "Numele este obligatoriu!")]
            [StringLength(20, ErrorMessage = "Numele nu poate avea mai mult de 20 de caractere")]
            public string Nume { get; set; } // Numele copilului

            [Required(ErrorMessage = "Prenumele este obligatoriu!")]
            [StringLength(20, ErrorMessage = "Prenumele nu poate avea mai mult de 20 de caractere")]
            public string Prenume { get; set; } // Prenumele copilului

            [DataType(DataType.Date)] // Format camp data

            [Required(ErrorMessage = "Data nasterii este obligatorie!")]
            [Display(Name = "Data nasterii")]
            public DateTime DataNasterii { get; set; } // Data nasterii

            [DataType(DataType.Date)] // Format camp data

            [Required(ErrorMessage = "Data intrarii in sistem este obligatorie!")]
            [Display(Name = "Data intrarii in sistem")]
            public DateTime DataIntrariiInSistem { get; set; } // Data intrarii in sistem

            public int? ProvenientaID { get; set; } // Cheie straina catre clasa Provenienta
            
            public Provenienta? Provenienta { get; set; } // Relatie cu clasa Provenienta
           
            public int? LocatieID { get; set; } // Cheie straina catre clasa Locatie
            
            public Locatie? Locatie { get; set; } // Relatie cu clasa Locatie
            public string FullName => $"{Nume} {Prenume}"; // Proprietate calculata
    }


}
