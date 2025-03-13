﻿CREATE TABLE Users
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

-- Indexes
CREATE INDEX IDX_User_UserName ON Users (UserName);
CREATE INDEX IDX_User_Email ON Users (Email);
