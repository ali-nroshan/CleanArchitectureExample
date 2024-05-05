using ErrorOr;
using MediatR;

namespace Project.Application.Features.Wallet.Requests.Commands;

public record CreateWalletCommand(Guid WalletId, uint WalletBalance) : IRequest<ErrorOr<Unit>>;