using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ShopSettings
{
    public interface IShopSettingApplication
    {
        public Task AddShopSetting(CreateUpdateShopSettingsDto input);
        public Task UpdateShopSetting(int id, CreateUpdateShopSettingsDto input);
        public Task DeleteShopSetting(int id);
        public Task<GetShopSettingsDto> GetShopSettingById(int id);
        public Task<List<GetShopSettingsDto>> GetAllShopSettings();
    }
}
