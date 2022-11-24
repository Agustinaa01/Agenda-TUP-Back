using Agenda_Tup_Back.Data.Interfaces;
using Agenda_Tup_Back.Data.Repository;
using Agenda_Tup_Back.Data.Repository.Implementations;
using Agenda_Tup_Back.DTO;
using Agenda_Tup_Back.Entities;
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
        public UsersController(IUserRepository userRepository) //en el contructor de dicha entre parentesis 
        {
            _userRepository = userRepository;
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_userRepository.GetAllUsers());
        //}

        //[HttpGet]
        //[Route("{Id}")]
        //public IActionResult GetUserById(int Id)
        //{
        //    //User user = _userRepository.GetUserById(Id);
        //    //var dto = _automapper.Map<GetUserById>(Id);
        //    try
        //    {
        //        return Ok(_userRepository.GetUserById(Id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public IActionResult CreateUser(UserForCreation userDTO)
        {
            try
            {
                _userRepository.CreateUsers(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", userDTO);
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

        //[HttpDelete]
        //[Route("{Id}")]
        //public IActionResult DeleteUser(string Id)
        //{
        //    try
        //    {
        //        _userRepository.DeleteUsers(Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok();
        //}
    } 
}

