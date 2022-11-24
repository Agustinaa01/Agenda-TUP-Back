using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using AutoMapper;

namespace Agenda_Tup_Back.Data.Repository
{
    public class ContactRepository: IContactRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(AgendaApiContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }
        public void CreateContacts(ContactForCreation dto, int Id)
        {
            var newContact = _mapper.Map<Contact>(dto);
            newContact.UserId = Id;
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
        }
        public void UpdateContacts(ContactForCreation dto, int Id)
        {
            var newContact = _mapper.Map<Contact>(dto);
            newContact.UserId = Id;
            _context.Contacts.Update(newContact);
            _context.SaveChanges();
        }
        public void DeleteContacts(int Id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == Id));
            _context.SaveChanges();
        }
        public void ArchiveContacts(int Id)
        {
            Contact contacts = _context.Contacts.FirstOrDefault(u => u.Id == Id);
            if (contacts != null)
            {
                contacts.state = State.Archived;
                _context.Update(contacts);
            }
            _context.SaveChanges();
        }

    }


}
