

using System.Security.Claims;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContactsController(IContactRepository contactRepository, IUserRepository userRepository, IMapper autoMapper)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
            _mapper = autoMapper;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllContacts(userId));
        }

        //[HttpGet]
        //[Route("{Id}")]
        //public IActionResult GetOneById(int Id)
        //{
        //    int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
        //    return Ok(_contactRepository.GetContactsById(userId));
        //}
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {

                var contacto = _contactRepository.GetContactById(id);

                if (contacto == null)
                {
                    return NotFound();
                }

                var contactoDto = _mapper.Map<ContactForCreation>(contacto);

                return Ok(contactoDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactForCreation dto)
        {
            try
            {
                var contacto = _mapper.Map<Contact>(dto);

                if (id != contacto.Id)
                {
                    return NotFound();
                }

                var contactoItem = _contactRepository.GetContactById(id);

                if (contactoItem == null)
                {
                    return NotFound();
                }

                _contactRepository.UpdateContacts(contacto);

                var contactoModificado = _contactRepository.GetContactById(id);

                var contactoModificadoDto = _mapper.Map<ContactForCreation>(contactoModificado);

                return Ok(contactoModificadoDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
