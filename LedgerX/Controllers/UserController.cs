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
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public void Create(CreateUpdateUserDto input)
        {
            var user = new User
            {
                Role=input.Role,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address1 = input.Address1,
                Address2 = input.Address2,
                City = input.City,
                State = input.State,
                Country = input.Country,
                PinCode = input.PinCode,
                Password = input.Password,
               
            };
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();


        }


        [HttpGet]
        public List<GetUserDto> Get()
        {
            return _dataContext.Users.Select(x => new GetUserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.State,
                Country = x.Country,
                PinCode = x.PinCode,
                Role=x.Role.ToString(),
            }).ToList();
        }

    }
}
