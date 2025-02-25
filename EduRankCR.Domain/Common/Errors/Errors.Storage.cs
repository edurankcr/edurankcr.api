using ErrorOr;

namespace EduRankCR.Domain.Common.Errors;

public static partial class Errors
{
    public static class Storage
    {
        public static Error UploadFailed =>
            Error.Conflict(code: "storage.upload_failed", description: "Failed to upload file to storage.");
    }
}