using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.ShopSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ShopSettings
{
    public class ShopSettingApplication:IShopSettingApplication
    {
        private readonly IShopSettingRepository _shopSettingRepository;

        private readonly IMapper _mapper;
        public ShopSettingApplication(IShopSettingRepository shopSettingRepository, IMapper mapper)
        {
            _shopSettingRepository = shopSettingRepository;
            _mapper = mapper;
        }

        public async Task AddShopSetting(CreateUpdateShopSettingsDto input)
        {
            var shopSetting = _mapper.Map<ShopSetting>(input);
            await _shopSettingRepository.Create(shopSetting);
        }

        public async Task DeleteShopSetting(int id)
        {
            var shopSetting = await _shopSettingRepository.GetById(id);
            if (shopSetting == null)
            {
                return;
            }
            await _shopSettingRepository.Delete(shopSetting);
        }

        public async Task<List<GetShopSettingsDto>> GetAllShopSettings()
        {
            var shopSettings = await _shopSettingRepository.GetAll();
            return _mapper.Map<List<GetShopSettingsDto>>(shopSettings);
        }

        public async Task<GetShopSettingsDto> GetShopSettingById(int id)
        {
            var shopSetting = await _shopSettingRepository.GetById(id);
            if (shopSetting == null)
            {
                return new GetShopSettingsDto();
            }
            return _mapper.Map<GetShopSettingsDto>(shopSetting);
        }

        public async Task UpdateShopSetting(int id, CreateUpdateShopSettingsDto input)
        {
            var shopSetting = await _shopSettingRepository.GetById(id);
            if (shopSetting == null)
            {
                return;
            }
            _mapper.Map(input, shopSetting);
            await _shopSettingRepository.Update(shopSetting);
        }


    }
}
