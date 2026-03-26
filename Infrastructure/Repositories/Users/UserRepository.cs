using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Users;

public class UserRepository:IUserRepository
{
    private readonly DataContext _datacontext;

    public UserRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }

    public async Task Create(User user)
    {
        await _datacontext.Users.AddAsync(user);
        await _datacontext.SaveChangesAsync();
    }

    public Task Delete(User user)
    {

        user.IsDeleted = true;
        user.IsActive = false;
        _datacontext.Users.Update(user);
        return _datacontext.SaveChangesAsync();

    }

    public async Task<List<User>> GetAll()
    {
        return await _datacontext.Users.ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _datacontext.Users.FindAsync(id);
    }

    public Task Update(User user)
    {
        _datacontext.Users.Update(user);
        return _datacontext.SaveChangesAsync();

    }
}
