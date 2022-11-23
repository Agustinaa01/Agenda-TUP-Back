using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Data.Repository;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")] //api/Nombre del controlador
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_contactRepository.GetAllContacts());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOneById(int Id)
        {
            return Ok(_contactRepository.GetAllContacts().Where(x => x.Id == Id));
        }

        [HttpPost]
        public IActionResult CreateContact(ContactForCreation createContactDTO)
        {
            try
            {
                _contactRepository.CreateContacts(createContactDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDTO);
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactForCreation dto, int Id)
        {
            try
            {
                _contactRepository.UpdateContacts(dto, Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete]
        //[Route("{Id}")]
        public IActionResult DeleteContactsById(int Id)
        {
            try
            {
                string role = HttpContext.User.FindFirst("role").Value;
                if (role == "Admin")
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
        //[HttpPost]
        //public IActionResult CreateGroup(AddToGroupForcreation dto)
        //{
        //    try
        //    {
        //        _contactRepository.CreateGroup(dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Created("Created", dto);
        //}

        //[HttpPut]
        //public IActionResult AddToGroup(string Id, string groupName)
        //{
        //    try
        //    {
        //        _contactRepository.AddToGroup(Id, groupName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return NoContent();
        //}

    }
    
}
