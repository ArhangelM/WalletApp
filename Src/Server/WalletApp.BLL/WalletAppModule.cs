using Microsoft.Extensions.DependencyInjection;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services;

namespace WalletApp.BLL
{
    public static class WalletAppModule
    {
        public static void AddServiceModule(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICardBalanceService, CardBalanceService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IDailyPointsService, DailyPointsService>();
        }
    }
}
