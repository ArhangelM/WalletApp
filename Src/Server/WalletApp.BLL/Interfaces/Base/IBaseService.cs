using WalletApp.DTO.Dto.Requests;

namespace WalletApp.BLL.Interfaces.Base
{
    public interface IBaseService<TDto, TKey>
    {
        Task Create(TDto pass);
        List<TDto> GetAll(GetAllRequestDto request);
        Task<TDto> GetById(GetByIdRequestDto<TKey> request);
        Task Update(TDto dtoToUpdate);
        Task DeleteAsync(TKey id);
    }
}
