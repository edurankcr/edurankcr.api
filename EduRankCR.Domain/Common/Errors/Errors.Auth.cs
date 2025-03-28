using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Auth.InvalidCred",
            description: "Invalid credentials.");

        public static Error Unauthorized => Error.Unauthorized(
            code: "Auth.Unauthorized",
            description: "Login to access this resource.");
    }
}