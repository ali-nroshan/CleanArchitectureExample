using ErrorOr;
using Mapster;
using MediatR;
using Project.Application.Contracts.Persistence;
using Project.Application.DTOs.Wallet;
using Project.Application.Features.Wallet.Requests.Queries;

namespace Project.Application.Features.Wallet.Handlers.Queries;

public class GetWalletsQueryHandler(IWalletRepository walletRepository) : IRequestHandler<GetWalletsQuery, ErrorOr<IEnumerable<WalletDto>>>
{
    private readonly IWalletRepository _walletRepository = walletRepository;

    public async Task<ErrorOr<IEnumerable<WalletDto>>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        var wallets = await _walletRepository.GetWalletsAsync();
        return wallets.Adapt<List<WalletDto>>();
    }
}