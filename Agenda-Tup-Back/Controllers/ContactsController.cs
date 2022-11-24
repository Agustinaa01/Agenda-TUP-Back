

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

        public ContactsController(IContactRepository contactRepository)
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
                var id = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                _contactRepository.CreateContacts(createContactDTO, Int32.Parse(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDTO);
        }

        [HttpPut]
        public IActionResult UpdateContact(ContactForCreation dto)
        {
            try
            {
                var id = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                _contactRepository.UpdateContacts(dto, Int32.Parse(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                _contactRepository.DeleteContacts(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
        //[HttpDelete]
        ////[Route("{Id}")]
        //public IActionResult DeleteContactsById(int Id)
        //{
        //    try
        //    {
        //        string role = HttpContext.User.FindFirst("role").Value;
        //        if (role == "Admin")
        //        {
        //            _contactRepository.DeleteContacts(Id);
        //        }
        //        else
        //        {
        //            _contactRepository.ArchiveContacts(Id);
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
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
