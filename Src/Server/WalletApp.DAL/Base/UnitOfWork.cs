using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DAL.Models;

namespace WalletApp.DAL.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletAppEntities _dbContext;
        private BaseRepository<User, int> _userRepository;
        private BaseRepository<CardBalance, int> _cardBalanceRepository;
        private BaseRepository<Transaction, int> _transactionRepository;

        public UnitOfWork(DbContextOptions optionsBuilder)
        {
            _dbContext = new WalletAppEntities(optionsBuilder);
        }
        
        public BaseRepository<User, int> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new BaseRepository<User, int>(_dbContext);
                return _userRepository;
            }
        }

        public BaseRepository<CardBalance, int> CardBalances
        {
            get
            {
                if (_cardBalanceRepository == null)
                    _cardBalanceRepository = new BaseRepository<CardBalance, int>(_dbContext);
                return _cardBalanceRepository;
            }
        }

        public BaseRepository<Transaction, int> Transactions
        {
            get
            {
                if (_transactionRepository == null)
                    _transactionRepository = new BaseRepository<Transaction, int>(_dbContext);
                return _transactionRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
