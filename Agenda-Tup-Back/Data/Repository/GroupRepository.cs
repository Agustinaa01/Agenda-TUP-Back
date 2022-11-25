
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
        public Group? GetGroupById(int groupId)
        {
            return _context.Groups.SingleOrDefault(u => u.Id == groupId);
        }
        public List<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }
        public void CreateGroups(GroupForCreation dto)
        {
            _context.Groups.Add(_mapper.Map<Group>(dto));
            _context.SaveChanges();
        }


    }


}
