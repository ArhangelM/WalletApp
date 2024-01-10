using System.ComponentModel;

namespace WalletApp.DTO.Dto
{
    public class CardBalanceDto
    {
        public int Id { get; set; }

        [DefaultValue(1500)]
        public float Limit { get; set; }
        public float Balance { get; set; }
        public float Available { get; set; }

        public UserDto? User { get; set; }
        public int UserId { get; set; }

        public ICollection<TransactionDto>? Transactions { get; set; }
    }
}
