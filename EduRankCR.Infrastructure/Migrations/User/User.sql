CREATE TABLE Users
(
    UserId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    EmailConfirmed BIT NOT NULL DEFAULT 0,
    NewEmail NVARCHAR(255) NULL,
    Password NVARCHAR(255) NOT NULL,
    Role TINYINT NOT NULL,
    Status TINYINT NOT NULL,
    AvatarUrl NVARCHAR(500) NULL,
    Biography NVARCHAR(1000) NULL,
    BirthDate DATE NOT NULL,
    PasswordChangedAt DATETIME NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT CHK_BirthDate
        CHECK (BirthDate <= DATEADD(YEAR, -18, GETDATE()) AND BirthDate >= DATEADD(YEAR, -100, GETDATE()))
);

CREATE INDEX IX_Users_EmailConfirmed ON Users (EmailConfirmed);
CREATE INDEX IX_Users_Name ON Users (Name);
CREATE INDEX IX_Users_LastName ON Users (LastName);
CREATE INDEX IX_Users_Role ON Users (Role);
CREATE INDEX IX_Users_Status ON Users (Status);
CREATE INDEX IX_Users_CreatedAt ON Users (CreatedAt DESC);
CREATE INDEX IX_Users_PasswordChangedAt ON Users (PasswordChangedAt);
CREATE INDEX IX_Users_NewEmail ON Users (NewEmail);
CREATE INDEX IX_Users_UserName ON Users (UserName);
CREATE INDEX IX_Users_Role_Status ON Users (Role, Status);
