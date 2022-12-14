

using System.Security.Claims;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")] //api/Nombre del controlador
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;

        public ContactsController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllContacts(userId));
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOneById(int Id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllContacts(userId).Where(x => x.Id == Id));
        }

        [HttpPost]
        public IActionResult CreateContact(ContactForCreation dto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                _contactRepository.CreateContacts(dto, userId);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactForCreation dto)
        {
            try
            {
                 int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                _contactRepository.UpdateContacts(dto, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteContactsById(int Id)
        {
            try
            {
                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
                if (role.Value == "Admin")
                {
                    _contactRepository.DeleteContacts(Id);
                }
                else
                {
                    _contactRepository.ArchiveContacts(Id);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
    
}
