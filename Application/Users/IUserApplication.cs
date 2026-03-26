using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface IUserApplication
    {
        public Task AddUser(CreateUpdateUserDto input);
        public Task UpdateUser(int id, CreateUpdateUserDto input);
        public Task DeleteUser(int id);
        public Task<GetUserDto> GetUserById(int id);
        public Task<List<GetUserDto>> GetAllUsers();
    }
}
