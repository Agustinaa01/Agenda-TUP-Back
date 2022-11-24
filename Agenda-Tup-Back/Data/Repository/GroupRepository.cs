
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Entities;
using AutoMapper;

namespace Agenda_Tup_Back.Data.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public GroupRepository(AgendaApiContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }
        public void CreateGroups(GroupForCreation dto, int Id)
        {
            var newContact = _mapper.Map<Contact>(dto);
            newContact.GroupId = Id;
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
        }
       

    }


}
