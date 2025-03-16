using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Teacher
    {
        public static Error NotFound =>
            Error.NotFound(code: "Teacher.NotFound", description: "Teacher not found in the system.");
        public static Error NotApproved =>
            Error.Conflict(code: "Teacher.NotApproved", description: "Teacher is not approved.");
        public static Error ReviewAlreadyExists =>
            Error.Conflict(code: "Teacher.ReviewAlreadyExists", description: "Teacher review already exists.");
        public static Error ReviewNotFound =>
            Error.NotFound(code: "Teacher.ReviewNotFound", description: "Teacher review not found in the system.");
    }
}