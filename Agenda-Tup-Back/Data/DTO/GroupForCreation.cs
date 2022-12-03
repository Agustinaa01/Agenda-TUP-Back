using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.DTO
{
    public class GroupForCreation
    {
        public string GroupName { get; set; }
        public ICollection<int> ContactsIds { get; set; }
    }
}
