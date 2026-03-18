using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.ShopSettings;

public interface IShopSettingRepository
{
    public Task Create(ShopSetting shopSettings);
    public Task<ShopSetting> GetById(int id);
    public Task<List<ShopSetting>> GetAll();
    public Task Update(ShopSetting shopSettings);
    public Task Delete(ShopSetting shopSettings);
}
