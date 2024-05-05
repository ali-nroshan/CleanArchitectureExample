namespace Project.Domain.Entities;

public class Wallet(Guid walletId, uint walletBalance, DateTime walletCreateDate)
{
    public Guid WalletId { get; set; } = walletId;
    public uint WalletBalance { get; set; } = walletBalance;
    public DateTime WalletCreateDate { get; set; } = walletCreateDate;
}