using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WalletApp.DTO.Enums;

namespace WalletApp.DAL.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Sum { get; set; }
        public TransactionType Type { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }
        public bool Pending { get; set; }
        public string? IconPath { get; set; }

        public CardBalance? CardBalance { get; set; }
        public int CardBalanceId { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }

    }
}
