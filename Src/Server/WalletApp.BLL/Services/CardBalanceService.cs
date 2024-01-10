using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services.Base;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DAL.Models;
using WalletApp.DTO.Dto;

namespace WalletApp.BLL.Services
{
    [ApiController]
    [Route("[controller]")]
    public class CardBalanceService : BaseService<CardBalanceDto, CardBalance, int>, ICardBalanceService
    {
        public CardBalanceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("[action]")]
        public string PaymentStatus() 
        {
            return $"You’ve paid your {DateTime.Now:MMMM} balance";
        }
    }
}
