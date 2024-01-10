using System.ComponentModel;

namespace WalletApp.DAL.Models
{
    public class CardBalance
    {
        public int Id { get; set; }

        [DefaultValue(1500)]
        public float Limit { get; set; }
        public float Balance { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
