using Application.Users;
using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }



        [HttpPost]
        public async Task<ActionResult> AddUser(CreateUpdateUserDto input)
        {
            try
            {
                await _userApplication.AddUser(input);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }


        }


        [HttpGet]
        public async Task<List<GetUserDto>> GetAll()
        {
            return await _userApplication.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<GetUserDto> GetById(int id)
        {
            return await _userApplication.GetUserById(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userApplication.DeleteUser(id);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, CreateUpdateUserDto input)
        {
            await _userApplication.UpdateUser(id, input);

        }
    }
}
