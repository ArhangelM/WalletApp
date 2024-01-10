using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Models;

namespace WalletApp.DAL.Configurations
{
    public class CardBalanceConfiguration : IEntityTypeConfiguration<CardBalance>
    {
        public void Configure(EntityTypeBuilder<CardBalance> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique();

            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
