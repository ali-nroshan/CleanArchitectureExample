using ErrorOr;
using Mapster;
using MediatR;
using Project.Application.Contracts.Persistence;
using Project.Application.DTOs.Wallet;
using Project.Application.Features.Wallet.Requests.Queries;
using Project.Domain.Common.Errors;

namespace Project.Application.Features.Wallet.Handlers.Queries;

public class GetWalletsQueryHandler(IWalletRepository walletRepository) : IRequestHandler<GetWalletsQuery, ErrorOr<IEnumerable<WalletDto>>>
{
    private readonly IWalletRepository _walletRepository = walletRepository;

    public async Task<ErrorOr<IEnumerable<WalletDto>>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        var wallets = await _walletRepository.GetWalletsAsync();
        if (wallets is null || !wallets.Any())
            return Errors.Wallet.NotFoundWallet;
        return wallets.Adapt<List<WalletDto>>();
    }
}