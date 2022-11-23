using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using AutoMapper;

namespace Agenda_Tup_Back.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AgendaApiContext context, IMapper autoMapper)
        { 
            _context = context;
            _mapper = autoMapper;
        }
        public User? GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
        public User? ValidarUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public void CreateUsers(UserForCreation dto)
        {
            _context.Users.Add(_mapper.Map<User>(dto)); //mapear de dto a mascota
            _context.SaveChanges();
        }
        //public void UpdateUsers(UserForCreation dto)
        //{
        //    _context.Users.Update(_mapper.Map<User>(dto));
        //}
        //public void DeleteUsers(string id)
        //{
        //    _context.Users.Remove(_context.Users.Single(c => c.Id == id));
        //}
    
        //public void ArchiveUsers(string Id)
        //{
        //    User user = _context.Users.FirstOrDefault(u => u.Id == Id);
        //    if (user != null)
        //    {
        //        user.state = State.Archived;
        //        _context.Update(user);
        //    }
        //}
    }   
}
