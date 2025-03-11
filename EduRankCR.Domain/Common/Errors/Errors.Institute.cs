using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Institute
    {
        public static Error NotFound =>
            Error.NotFound(code: "Institute.NotFound", description: "Institute not found in the system.");
    }
}