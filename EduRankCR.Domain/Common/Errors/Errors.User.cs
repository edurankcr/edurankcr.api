using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error UsernameTaken =>
            Error.Conflict(code: "User.UsernameTaken", description: "The username is already in use.");

        public static Error EmailTaken =>
            Error.Conflict(code: "User.EmailTaken", description: "The email is already in use.");

        public static Error EmailCurrentInUse =>
            Error.Conflict(code: "User.EmailCurrentInUse", description: "The email is already in use by the user.");

        public static Error NotFound =>
            Error.NotFound(code: "User.NotFound", description: "User not found in the system.");

        public static Error EmailNotConfirmed =>
            Error.Forbidden(code: "User.EmailNotConfirmed", description: "The email is not confirmed.");

        public static Error EmailAlreadyConfirmed =>
            Error.Conflict(code: "User.EmailAlreadyConfirmed", description: "The email is already confirmed.");
    }
}