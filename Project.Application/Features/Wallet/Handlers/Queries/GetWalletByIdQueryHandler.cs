using ErrorOr;
using Mapster;
using MediatR;
using Project.Application.Contracts.Persistence;
using Project.Application.DTOs.Wallet;
using Project.Application.Features.Wallet.Requests.Queries;
using Project.Domain.Common.Errors;

namespace Project.Application.Features.Wallet.Handlers.Queries;

public class GetWalletByIdQueryHandler(IWalletRepository walletRepository) : IRequestHandler<GetWalletByIdQuery, ErrorOr<WalletDto>>
{
    private readonly IWalletRepository _walletRepository = walletRepository;

    public async Task<ErrorOr<WalletDto>> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetWalletAsync(request.WalletId);
        if (wallet is null)
            return Errors.Wallet.NotFoundWallet;

        return wallet.Adapt<WalletDto>();
    }
}