using WalletApp.DAL.Models;

namespace WalletApp.DAL.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        BaseRepository<User, int> Users { get; }
        BaseRepository<CardBalance, int> CardBalances { get; }
        BaseRepository<Transaction, int> Transactions { get; }
        Task SaveAsync();
    }
}
