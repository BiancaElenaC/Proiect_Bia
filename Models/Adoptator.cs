using System.ComponentModel.DataAnnotations;

namespace Proiect__Bia.Models
{
    public class Adoptator
    {
        public int ID { get; set; } // Cheie primara

        [Required(ErrorMessage = "Numele este obligatoriu!")]
        [StringLength(20, ErrorMessage = "Numele nu poate avea mai mult de 20 de caractere")]
        public string Nume { get; set; } // Numele adoptatorului

        [Required(ErrorMessage = "Prenumele este obligatoriu!")]
        [StringLength(20, ErrorMessage = "Prenumele nu poate avea mai mult de 20 de caractere")]
        public string Prenume { get; set; } // Prenumele adoptatorului
        
        public string Adresa { get; set; } // Adresa adoptatorului

        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu 07 si sa aiba 10 cifre")]

        public string Telefon { get; set; } // Numarul de telefon al adoptatorului

        [Required(ErrorMessage = "Adresa de email este obligatorie!")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida")]

        public string Email { get; set; } // Email- ul adoptatorului
       
        public string CNP { get; set; } // Codul Numeric Personal
        
        public ICollection<Adoptie>? Adoptii { get; set; } // Relatie cu clasa Adoptie
                                                         
        public string FullName => $"{Nume} {Prenume}"; // Proprietate calculata pentru a ne putea folosi de ea
    }

}
