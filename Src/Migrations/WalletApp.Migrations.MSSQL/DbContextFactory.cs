using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WalletApp.DAL;

namespace WalletApp.Migrations.MSSQL
{
    public class DbContextFactory : IDesignTimeDbContextFactory<WalletAppEntities>
    {
        public WalletAppEntities CreateDbContext(string[] args)
        {
            var contextBuilder = new DbContextOptionsBuilder<WalletAppEntities>();
            contextBuilder.UseSqlServer("Server=fake;Database=db;User=root;Password=root;", config =>
            {
                config.MigrationsAssembly("WalletApp.Migrations.MSSQL");
            });
            return new WalletAppEntities(contextBuilder.Options);
        }
    }
}
