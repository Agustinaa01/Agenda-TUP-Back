
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        [HttpGet]
        public IActionResult GetAllGroup()
        {
            return Ok(_groupRepository.GetAllGroups());

        }

        [HttpGet("(groupName)")]
        public IActionResult GetAllGrouName()
        {
            return Ok(_groupRepository.GetAllGroupsNames());

        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetGroupById(int Id)
        {
            //User user = _userRepository.GetUserById(Id);
            //var dto = _automapper.Map<GetUserByIdResponse>(user);
            try
            {
                return Ok(_groupRepository.GetGroupById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateGroup(GroupForCreation dto, int id)
        {
            try
            {
                _groupRepository.CreateGroups(dto);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }
        [HttpPost("AddContacts")]
        public  IActionResult AddContact(GroupForUpdate dto)
        {
            try
            {
                _groupRepository.AddContact(dto);
                return Created("Created", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }
        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteContactsById(int Id)
        {
            try
            {
                 _groupRepository.DeleteGroup(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
