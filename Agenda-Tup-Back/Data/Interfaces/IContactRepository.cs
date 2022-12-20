using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.Data.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllContacts(int id);
        public Contact GetContactById(int Id);
        public void CreateContacts(ContactForCreation dto, int Id);
        public void UpdateContacts(Contact contacto);
        public void DeleteContacts(int Id);
        public void ArchiveContacts(int Id);

    }
}

