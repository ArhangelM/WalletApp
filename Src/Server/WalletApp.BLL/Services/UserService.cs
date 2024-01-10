using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Common;               //Needed
using WalletApp.BLL.Common.Auth;          //Needed
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services.Base;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DAL.Models;
using WalletApp.DTO.Dto;
using WalletApp.DTO.Dto.Requests;         //Needed

namespace WalletApp.BLL.Services
{
    [ApiController]
    [Route("[controller]")]
    public class UserService : BaseService<UserDto, User, int>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /*
        // For registration
        [HttpPost]
        [Route("[action]")]
        public async Task<Tuple<string, UserDto>> RegistrationAsync(UserDto user)
        {
            user.Password = MD5ForPassword.HashPassword(user.Password);
            await _unitOfWork.Users.Create(_mapper.Map<UserDto, User>(user));
            await _unitOfWork.SaveAsync();
            var dbUser = _unitOfWork.Users.GetAll().FirstOrDefault(s => s.Login == user.Login);

            return new Tuple<string, UserDto>(
                    await Task.Run(GenerateTokenHelper.GetToken),
                    _mapper.Map<User, UserDto>(dbUser));
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<Tuple<string, UserDto>?> AuthorizationAsync(AuthorizationDto user)
        {
            var userHash = MD5ForPassword.HashPassword(user.Password);
            var dbUser = _unitOfWork.Users.GetAll().FirstOrDefault(s => s.Login == user.Login);
            if (userHash == dbUser?.Password)
            {
                return new Tuple<string, UserDto>(
                    await Task.Run(GenerateTokenHelper.GetToken),
                    _mapper.Map<User, UserDto>(dbUser));
            }

            return null;
        }
        */
    }
}
