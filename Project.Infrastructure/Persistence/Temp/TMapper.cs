using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Temp;

public static class TMapper
{
    public static Wallet? ToWallet(this TWalletDto? wallet)
    {
        if (wallet is null) return null;
        return new Wallet(Guid.Parse(wallet.WalletId), wallet.WalletBalance, wallet.WalletCreateDate);
    }

    public static TWalletDto ToTWalletDto(this Wallet wallet)
    {
        return new TWalletDto { WalletId = wallet.WalletId.ToString(), WalletCreateDate = wallet.WalletCreateDate, WalletBalance = wallet.WalletBalance };
    }

    public static IEnumerable<Wallet> ToWallets(this IEnumerable<TWalletDto> wallets)
    {
        int n = wallets.Count();
        var result = new Wallet[n];
        foreach (var wallet in wallets)
            result[--n] = wallet.ToWallet()!;
        return result;
    }
}