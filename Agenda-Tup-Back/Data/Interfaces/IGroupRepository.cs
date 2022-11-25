using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IGroupRepository
    {
        public List<Group> GetAllGroups();
        public Group? GetGroupById(int groupId);
        public void CreateGroups(GroupForCreation dto);
    }
}
