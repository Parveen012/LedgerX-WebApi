using Application.Dtos;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class mapping:Profile
    {
        public mapping() {

            CreateMap<CreateUpdateCustomerDto, Customer>();
            CreateMap<Customer,GetCustomerDto>();

            CreateMap<CreateUpdateTransactionDto, Transaction>();
            CreateMap<Transaction,GetTransactionDto>();

            CreateMap<CreateUpdateShopSettingsDto, ShopSetting>();
            CreateMap<ShopSetting,GetShopSettingsDto>();

            CreateMap<CreateUpdateUserDto, User>();
            CreateMap<User,GetUserDto>();


        }
    }
}
