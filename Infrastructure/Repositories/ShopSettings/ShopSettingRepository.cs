using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ShopSettings;

public class ShopSettingRepository:IShopSettingRepository
{
    private readonly DataContext _datacontext;

    public ShopSettingRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }
    public async Task Create(ShopSetting shopSettings)
    {
        await _datacontext.ShopSettings.AddAsync(shopSettings);
        await _datacontext.SaveChangesAsync();
    }

    public Task Delete(ShopSetting shopSettings)
    {

        shopSettings.IsDeleted = true;
        shopSettings.IsActive = false;
        _datacontext.ShopSettings.Update(shopSettings);
        return _datacontext.SaveChangesAsync();

    }

    public async Task<List<ShopSetting>> GetAll()
    {
        return await _datacontext.ShopSettings.Include(x=>x.User).ToListAsync();
    }

    public async Task<ShopSetting> GetById(int id)
    {
        return await _datacontext.ShopSettings.Include(x => x.User).FirstAsync(x => x.Id == id);
    }

    public Task Update(ShopSetting shopSettings)
    {
        _datacontext.ShopSettings.Update(shopSettings);
        return _datacontext.SaveChangesAsync();

    }
}
