using WalletApp.DTO.Enums;

namespace WalletApp.DTO.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Sum { get; set; }
        public TransactionType Type { get; set; }
        public string Date { get; set; } = null!;
        public bool Pending { get; set; }
        public string? IconPath { get; set; }

        public CardBalanceDto? CardBalance { get; set; }
        public int CardBalanceId { get; set; }

        public UserDto? User { get; set; }
        public int UserId { get; set; }
    }
}
