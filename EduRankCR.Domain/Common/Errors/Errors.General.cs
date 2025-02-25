using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class General
    {
        public static Error ValueCanNotBeNull =>
            Error.Validation(code: "General.ValueCanNotBeNull", description: "Value can not be null.");

        public static Error NothingToUpdate =>
            Error.Conflict(code: "General.NothingToUpdate", description: "Nothing to update.");
    }
}