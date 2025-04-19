using ErrorOr;

namespace EduRankCR.Application.Common.Errors;

public static class Errors
{
    public static class Auth
    {
        public static readonly Error InvalidCredentials = Error.Unauthorized(
            code: "Auth.InvalidCredentials",
            description: "The provided credentials are invalid.");
        public static readonly Error Unauthorized = Error.Unauthorized(
            code: "Auth.Unauthorized",
            description: "You are not authorized to perform this action.");
    }

    public static class User
    {
        public static readonly Error AvatarNotFound = Error.NotFound(
            code: "User.AvatarNotFound",
            description: "The user avatar was not found.");
        public static readonly Error NullNewEmail = Error.Conflict(
            code: "User.NullNewEmail",
            description: "When changing the email, the new email must be provided.");
        public static readonly Error NullInformation = Error.Validation(
            code: "User.NullInformation",
            description: "At least one of the fields must be provided.");
        public static readonly Error SameEmail = Error.Conflict(
            code: "User.SameEmail",
            description: "The provided email is the same as the current one.");
        public static readonly Error SameUserName = Error.Conflict(
            code: "User.SameUserName",
            description: "The provided username is the same as the current one.");
        public static readonly Error NotFound = Error.NotFound(
            code: "User.NotFound",
            description: "The user was not found.");
        public static readonly Error NotConfirmed = Error.Unauthorized(
            code: "User.NotConfirmed",
            description: "The user is not confirmed.");
        public static readonly Error DuplicateEmail = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "The email is already in use.");
        public static readonly Error DuplicateUserName = Error.Conflict(
            code: "User.DuplicateUserName",
            description: "The username is already in use.");
        public static readonly Error AlreadyConfirmed = Error.Conflict(
            code: "User.AlreadyConfirmed",
            description: "The user is already confirmed.");
        public static readonly Error InvalidPassword = Error.Conflict(
            code: "User.InvalidPassword",
            description: "The provided password is invalid.");
    }

    public static class Token
    {
        public static readonly Error NotFound = Error.NotFound(
            code: "Token.NotFound",
            description: "The token was not found.");
        public static readonly Error AlreadyExists = Error.Conflict(
            code: "Token.AlreadyExists",
            description: "The token already exists.");
    }

    public static class Storage
    {
        public static readonly Error UploadFailed = Error.Failure(
            code: "Storage.UploadFailed",
            description: "The file upload failed.");
    }

    public static class Institution
    {
        public static readonly Error NotFound = Error.NotFound(
            code: "Institution.NotFound",
            description: "The institution was not found.");
        public static readonly Error AlreadyExists = Error.Conflict(
            code: "Institution.AlreadyExists",
            description: "The institution already exists.");
        public static readonly Error AlreadyInReview = Error.Conflict(
            code: "Institution.AlreadyInReview",
            description: "The institution is already in review.");
        public static readonly Error NullRatingAggregate = Error.NotFound(
            code: "Institution.NullRatingAggregate",
            description: "The institution rating aggregate was not found.");
    }
}