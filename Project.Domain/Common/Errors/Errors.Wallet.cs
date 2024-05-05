using ErrorOr;

namespace Project.Domain.Common.Errors;

public static class Errors
{
    public static class Wallet
    {
        public static Error DuplicateWallet => Error.Conflict("Wallet.Duplicate");
        public static Error NotFoundWallet => Error.NotFound("Wallet.NotFound");
    }
}