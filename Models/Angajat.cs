using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Angajat
    {
        public int ID { get; set; } // Cheie primara

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [StringLength(20, ErrorMessage = "Numele nu poate avea mai mult de 20 de caractere")]
        public string Nume { get; set; } // Numele angajatului

        [Required(ErrorMessage = "Prenumele este obligatoriu!")]
        [StringLength(20, ErrorMessage = "Prenumele nu poate avea mai mult de 20 de caractere")]
        public string Prenume { get; set; } // Prenumele angajatului

        public string Functie { get; set; } // Functia angajatului

        [Display(Name = "Centru")]
        public int? CentruID { get; set; } // Cheie straina catre clasa Locatie
       
        public Locatie? Centru { get; set; } // Relatie cu clasa Locatie
    }

}
