using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Models;

namespace WalletApp.DAL
{
    public interface IWalletAppEntities
    {
        DbSet<User> Users { get; set; }
        DbSet<CardBalance> CardBalances { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}
