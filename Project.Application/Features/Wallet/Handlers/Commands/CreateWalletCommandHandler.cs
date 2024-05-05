using ErrorOr;
using MediatR;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Wallet.Requests.Commands;
using Project.Domain.Common.Errors;

namespace Project.Application.Features.Wallet.Handlers.Commands;

public class CreateWalletCommandHandler(IWalletRepository walletRepository) : IRequestHandler<CreateWalletCommand, ErrorOr<Unit>>
{
    private readonly IWalletRepository _walletRepository = walletRepository;

    public async Task<ErrorOr<Unit>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        if (await _walletRepository.IsWalletExistAsync(request.WalletId))
            return Errors.Wallet.DuplicateWallet;

        var wallet = new Domain.Entities.Wallet(request.WalletId, request.WalletBalance, DateTime.UtcNow.Date);
        await _walletRepository.AddWallet(wallet);

        return Unit.Value;
    }
}