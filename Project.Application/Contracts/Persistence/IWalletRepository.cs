using Project.Domain.Entities;

namespace Project.Application.Contracts.Persistence;

public interface IWalletRepository
{
    Task<IEnumerable<Wallet>> GetWalletsAsync();
    Task<Wallet> GetWalletAsync(Guid walletId);
    Task AddWallet(Wallet wallet);
    Task<bool> IsWalletExistAsync(Guid walletId);
}