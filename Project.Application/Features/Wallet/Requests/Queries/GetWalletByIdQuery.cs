using ErrorOr;
using MediatR;
using Project.Application.DTOs.Wallet;

namespace Project.Application.Features.Wallet.Requests.Queries;

public record GetWalletByIdQuery(Guid WalletId) : IRequest<ErrorOr<WalletDto>>;