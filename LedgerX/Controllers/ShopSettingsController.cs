using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopSettingsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ShopSettingsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public void Create(CreateUpdateShopSettingsDto input)
        {
            bool isUserExisits = _dataContext.Users.Any(p => p.Id == input.UserId);
            if (!isUserExisits)
            {
                throw new BadHttpRequestException($"User ID {input.UserId} doesn't exists");

            }
            var shopSettings = new ShopSettings
            {
                UserId = input.UserId,
                Email = input.Email,
                PhoneNumber= input.PhoneNumber,
                GstNumber = input.GstNumber,
                ShopName = input.ShopName,
                OwnerName = input.OwnerName,

            };
            _dataContext.Add(shopSettings);
            _dataContext.SaveChanges();
        }

        [HttpGet]
        public List<GetShopSettingsDto> Get()
        {
            return _dataContext.ShopSettings.Include(x => x.User).Select(x => new GetShopSettingsDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Email= x.Email,
                PhoneNumber= x.PhoneNumber,
                GstNumber= x.GstNumber,
                OwnerName= x.OwnerName,
                ShopName=x.ShopName,
                User=x.User
               
            }).ToList();
        }

    }
}
