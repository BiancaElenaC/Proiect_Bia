using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Locatie
    {
        public int ID { get; set; } // Cheie primara

        [Display(Name = "Nume centru")]
        public string NumeCentru { get; set; } // Numele centrului
        
        public string Adresa { get; set; } // Adresa centrului

        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu 07 si sa aiba 10 cifre")]

        public string Telefon { get; set; } // Numarul de telefon al  centrului
        
        public int Capacitate { get; set; } // Capacitatea centrului
        
        public ICollection<Copil>? Copii { get; set; } // Relatie cu clasa Copil
        
        public ICollection<Angajat>? Angajati { get; set; } // Relatie cu clasa Angajat
    }

}
