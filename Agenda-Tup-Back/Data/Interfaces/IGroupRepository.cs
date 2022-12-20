using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IGroupRepository
    {
        public List<Group> GetAllGroups(int id);
        public List<Group> GetAllGroupsNames(int id);
        public Group? GetGroupById(int Id);
        public void CreateGroups(GroupForCreation dto);
        public void AddContact(GroupForUpdate dto);
        public void DeleteGroup(int id);

    }
}
