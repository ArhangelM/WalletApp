namespace WalletApp.DTO.Dto.Requests
{
    public class GetByIdRequestDto<TKey>
    {
        public TKey Id { get; set; } = default!;
        public string[]? Filter { get; set; }
    }
}
