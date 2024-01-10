using WalletApp.BLL.Interfaces.Base;
using WalletApp.DTO.Dto;

namespace WalletApp.BLL.Interfaces
{
    public interface ITransactionService : IBaseService<TransactionDto, int>
    {
    }
}
