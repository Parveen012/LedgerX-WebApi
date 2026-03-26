using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public class UserApplication:IUserApplication
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public UserApplication(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddUser(CreateUpdateUserDto input)
        {
            var user = _mapper.Map<User>(input);
            await _userRepository.Create(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return;
            }
            await _userRepository.Delete(user);
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return new GetUserDto();
            }
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task UpdateUser(int id, CreateUpdateUserDto input)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return;
            }
            _mapper.Map(input, user);
            await _userRepository.Update(user);
        }
    }
}
