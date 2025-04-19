CREATE TABLE Users_Tokens
(
    TokenId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    Token NVARCHAR(255) NOT NULL UNIQUE,
    Type TINYINT NOT NULL,
    ExpiresAt DATETIME2 NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_UsersTokens_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE INDEX IX_UserTokens_UserId_Type ON Users_Tokens (UserId, Type);
CREATE INDEX IX_UserTokens_Token ON Users_Tokens (Token);
CREATE INDEX IX_UserTokens_ExpiresAt ON Users_Tokens (ExpiresAt);
