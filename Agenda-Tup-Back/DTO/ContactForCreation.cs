using System.ComponentModel.DataAnnotations;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.DTO
{
    public class ContactForCreation
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Alias { get; set; }
        public string CelularNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Email { get; set; }
        public User? User;
    }
}
