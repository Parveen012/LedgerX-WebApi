using Application.Dtos;
using Application.ShopSettings;
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
        private readonly IShopSettingApplication _shopSettingApplication;

        public ShopSettingsController(IShopSettingApplication shopSettingApplication)
        {
            _shopSettingApplication = shopSettingApplication;
        }

        [HttpPost]
        public async Task<ActionResult> AddShopSetting(CreateUpdateShopSettingsDto input)
        {
            try
            {
                await _shopSettingApplication.AddShopSetting(input);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }

        }


        [HttpGet]
        public async Task<List<GetShopSettingsDto>> GetAll()
        {
            return await _shopSettingApplication.GetAllShopSettings();
        }

        [HttpGet("{id}")]
        public async Task<GetShopSettingsDto> GetById(int id)
        {
            return await _shopSettingApplication.GetShopSettingById(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shopSettingApplication.DeleteShopSetting(id);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, CreateUpdateShopSettingsDto input)
        {
            await _shopSettingApplication.UpdateShopSetting(id, input);

        }

    }
}
