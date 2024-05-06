using ErrorOr;
using MediatR;
using Project.Application.DTOs.Wallet;

namespace Project.Application.Features.Wallet.Requests.Commands;

public record CreateWalletCommand(WalletDto WalletDto) : IRequest<ErrorOr<Unit>>;