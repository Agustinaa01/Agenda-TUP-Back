using Agenda_Tup_Back.Data.DTO;
using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Data.Repository;
using Agenda_Tup_Back.Data.Repository.Implementations;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Agenda_Tup_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _automapper;
        public UsersController(IUserRepository userRepository) //en el contructor de dicha entre parentesis 
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetUserById(int Id)
        {
            User user = _userRepository.GetUserById(Id);
            var dto = _automapper.Map<GetUserByIdResponse>(user);
            try
            {
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserForCreation dto)
        {
            try
            {
                _userRepository.CreateUsers(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", dto);
        }
        //[HttpPut]
        //public IActionResult UpdateUser(UserForCreation userCreationDTO)
        //{
        //    try
        //    {
        //        _userRepository.UpdateUsers(userCreationDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return NoContent();
        //}


        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {

                if (_userRepository.GetUserById(id).UserName == "Admin")
                {
                    _userRepository.DeleteUsers(id);
                }
                else
                {
                    _userRepository.ArchiveUsers(id);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

