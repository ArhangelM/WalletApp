using System.ComponentModel;

namespace WalletApp.DTO.Dto.Requests
{
    public class GetAllRequestDto
    {
        [DefaultValue(10)]
        public int Take { get; set; }

        [DefaultValue(null)]
        public string[]? filter { get; set; }
    }
}
