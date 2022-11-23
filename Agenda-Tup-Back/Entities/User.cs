using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id unico, se autogenera
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public Rol Rol { get; set; } = Rol.User;
        
    }
}
