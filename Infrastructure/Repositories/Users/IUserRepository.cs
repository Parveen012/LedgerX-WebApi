using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        public Task Create(User user);
        public Task<User> GetById(int id);
        public Task<List<User>> GetAll();
        public Task Update(User user);
        public Task Delete(User user);
    }
}
