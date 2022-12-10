using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IGroupRepository
    {
        public List<Group> GetAllGroups();
        public Group? GetGroupById(int Id);
        //public Group? GetGroupByContact();
        public void CreateGroups(GroupForCreation dto);
        public void AddContact(GroupForUpdate dto);
    }
}
