using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCred", description: "Invalid credentials.");
        public static Error Unauthorized => Error.Validation(code: "Auth.Unauthorized", description: "Login to access this resource.");
    }
}