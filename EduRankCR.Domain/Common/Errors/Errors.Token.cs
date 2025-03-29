using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Token
    {
        public static Error NotFound =>
            Error.NotFound(code: "Token.NotFound", description: "Token not found.");
        public static Error AlreadyExists =>
            Error.Conflict(code: "Token.AlreadyExists", description: "Token already exists.");
        public static Error InvalidToken =>
            Error.Conflict(code: "Token.Invalid", description: "Invalid token.");
        public static Error AlreadyUsed =>
            Error.Conflict(code: "Token.AlreadyUsed", description: "Token already used.");
        public static Error AlreadyExpired =>
            Error.Conflict(code: "Token.AlreadyExpired", description: "Token already expired.");
    }
}