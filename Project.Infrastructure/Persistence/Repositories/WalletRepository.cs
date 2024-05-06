using Project.Application.Contracts.Persistence;
using Project.Domain.Entities;
using Project.Infrastructure.Persistence.Temp;
using System.Data.SQLite;

namespace Project.Infrastructure.Persistence.Repositories;

public class WalletRepository(SQLiteConnection connection) : BaseRepository<TWalletDto>(connection), IWalletRepository
{
    public async Task AddWallet(Wallet wallet)
    {
        string query = $"INSERT INTO Wallets (WalletId, WalletBalance, WalletCreateDate) VALUES (@WalletId, @WalletBalance, @WalletCreateDate)";
        await AddAsync(query, wallet.ToTWalletDto());
    }

    public async Task<Wallet?> GetWalletAsync(Guid walletId)
    {
        string query = $"SELECT * FROM Wallets WHERE WalletId = \"{walletId}\"";
        return (await GetAsync(query)).ToWallet();
    }

    public async Task<IEnumerable<Wallet>> GetWalletsAsync()
    {
        string query = "SELECT * FROM Wallets";
        return (await GetAllAsync(query)).ToWallets();
    }

    public async Task<bool> IsWalletExistAsync(Guid walletId)
    {
        var wallet = await GetWalletAsync(walletId);
        if (wallet is null) return false;
        return true;
    }
}