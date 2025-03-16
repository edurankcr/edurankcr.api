using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Institute
    {
        public static Error NotFound =>
            Error.NotFound(code: "Institute.NotFound", description: "Institute not found in the system.");
        public static Error ReviewAlreadyExists =>
            Error.Conflict(code: "Institute.ReviewAlreadyExists", description: "Review already exists for this institute.");
        public static Error NotApproved =>
            Error.Conflict(code: "Institute.NotApproved", description: "Institute is not approved.");
        public static Error ReviewNotFound =>
            Error.NotFound(code: "Institute.ReviewNotFound", description: "Review not found in the system.");
    }
}