
using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
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
        public IActionResult GetAllGroups()
        {
            return Ok(_groupRepository.GetAllGroups());
        }


        [HttpPost]
        public IActionResult CreateGroups(GroupForCreation dto)
        {
            try
            {
                var groups = _groupRepository.GetAllGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }
    }
}
