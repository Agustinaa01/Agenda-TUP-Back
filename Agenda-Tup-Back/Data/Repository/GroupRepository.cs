
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var groups = _context.Groups
            .Include(c=> c.Contacts)
            .ToList();
            return groups;
        }
        public Group? GetGroupById(int Id)
        {
            return _context.Groups.SingleOrDefault(u => u.Id == Id);
        }
        public void CreateGroups(GroupForCreation dto)
        {
            //Group group = _mapper.Map<Group>(dto);
            //group.ContactId = Id;
            //_context.Groups.Add(group);
            //_context.SaveChanges();
            _context.Groups.Add(_mapper.Map<Group>(dto));
            _context.SaveChanges();
        }
        public void AddContact(GroupForUpdate dto)
        {
            var contact = _context.Contacts
                .Where(c => c.Id == dto.ContactId)
                .Include(c => c.Groups)
                .FirstOrDefault();
            var group = _context.Groups.Find(dto.GroupId);
            contact.Groups.Add(group);
            _context.SaveChanges();
        }

    }


}
