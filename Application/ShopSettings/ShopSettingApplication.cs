using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.ShopSettings;
using Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ShopSettings
{
    public class ShopSettingApplication:IShopSettingApplication
    {
        private readonly IShopSettingRepository _shopSettingRepository;

        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public ShopSettingApplication(IShopSettingRepository shopSettingRepository, IMapper mapper, IUserRepository userRepository)
        {
            _shopSettingRepository = shopSettingRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task AddShopSetting(CreateUpdateShopSettingsDto input)
        {
            var user = _shopSettingRepository.GetById(input.UserId);
            if (user == null)
            {
                throw new Exception("User id Doesn't Exists");
            }
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
            var user = _shopSettingRepository.GetById(input.UserId);
            if (user == null)
            {
                throw new Exception("User id Doesn't Exists");
            }
            _mapper.Map(input, shopSetting);
            await _shopSettingRepository.Update(shopSetting);
        }


    }
}
