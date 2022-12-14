using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agenda_Tup_Back.Entities
{
    public class Group
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string? Description { get; set; }
        public ICollection<Contact> Contacts { get; set; }

    }
}

