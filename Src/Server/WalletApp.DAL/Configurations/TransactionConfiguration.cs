using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Models;

namespace WalletApp.DAL.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique();

            builder.HasOne(d => d.CardBalance)
                .WithMany()
                .HasForeignKey(d => d.CardBalanceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(s => s.CardBalance).AutoInclude();
            builder.Navigation(s => s.User).AutoInclude();
        }
    }
}
