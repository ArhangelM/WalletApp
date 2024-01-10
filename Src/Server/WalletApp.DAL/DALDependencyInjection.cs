using Microsoft.Extensions.DependencyInjection;
using WalletApp.DAL.Base;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DAL.Models;

namespace WalletApp.DAL
{
    public static class DALDependencyInjection
    {
        public static void AddDAL(this IServiceCollection services)
        {
            services.AddScoped<IWalletAppEntities, WalletAppEntities>();
            services.AddTransient<BaseRepository<User, int>>();
            services.AddTransient<BaseRepository<CardBalance, int>>();
            services.AddTransient<BaseRepository<Transaction, int>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
