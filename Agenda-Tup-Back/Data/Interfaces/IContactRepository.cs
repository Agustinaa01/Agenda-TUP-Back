using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllContacts();
        public void CreateContacts(ContactForCreation dto, int Id);
        public void UpdateContacts(ContactForCreation dto, int Id);
        public void DeleteContacts(int Id);
        public void ArchiveContacts(int Id);

        //public void CreateGroup(AddToGroupForcreation dto);
        //public void AddToGroup(string Id, string groupName);
    }
}

