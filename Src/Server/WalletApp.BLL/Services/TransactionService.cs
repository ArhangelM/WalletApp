using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services.Base;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DAL.Models;
using WalletApp.DTO.Dto;
using WalletApp.DTO.Dto.Requests;

namespace WalletApp.BLL.Services
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionService : BaseService<TransactionDto, Transaction, int>, ITransactionService
    {
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //Також можна добавити сортування та властивість Skip, якщо планується виводи посторінково
        public override List<TransactionDto> GetAll(GetAllRequestDto request) =>
            base.GetAll(request)
            .Take(request.Take)
            .ToList();
    }
}
