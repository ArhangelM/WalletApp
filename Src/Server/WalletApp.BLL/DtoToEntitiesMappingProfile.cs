using AutoMapper;
using WalletApp.DAL.Models;
using WalletApp.DTO.Dto;

namespace WalletApp.BLL
{
    public class DtoToEntitiesMappingProfile : Profile
    {
        public DtoToEntitiesMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<CardBalance, CardBalanceDto>().AfterMap((entity, dto) =>
            {
                dto.Available = entity.Limit - entity.Balance;
            }); 
            CreateMap<CardBalanceDto, CardBalance>();

            CreateMap<Transaction, TransactionDto>().AfterMap((entity, dto) =>
            {
                dto.Description = entity.Pending ? entity.Description.Insert(0, "Pending - ") : entity.Description;
                dto.Date = (DateTime.Now - entity.Date).Days > 7 ? entity.Date.ToString("dd/MM/yyy") : entity.Date.ToString("dddd");

                if (entity.UserId != entity.CardBalance!.UserId)
                    dto.Description = dto.Description.Insert(0, $"{entity.User!.Login} - ");
                //Суму, вважаю, потрібно аналізувати на стороні клієнта.
                //Можливо, потрібно буде проводити над нею операції
            });
            CreateMap<TransactionDto, Transaction>();
        }
    }
}
