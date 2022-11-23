using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agenda_Tup_Back.Models.Enum;

namespace Agenda_Tup_Back.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string CelularNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Alias { get; set; }

        public string? Email { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } //Usuario al que pertenece
        public int UserId { get; set; }
    }

}
