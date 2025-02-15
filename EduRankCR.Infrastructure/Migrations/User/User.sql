CREATE TABLE Users
(
    Id             UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name           NVARCHAR(32)     NOT NULL,
    Lastname       NVARCHAR(64)     NOT NULL,
    Username       NVARCHAR(18)     NOT NULL UNIQUE,
    Email          NVARCHAR(255)    NOT NULL UNIQUE,
    EmailConfirmed BIT              NOT NULL DEFAULT 0,
    Birthdate      DATE             NOT NULL,
    Password       NVARCHAR(255)    NOT NULL,
    Role           TINYINT          NOT NULL DEFAULT 0,
    Status         TINYINT          NOT NULL DEFAULT 0,
    NewEmail       NVARCHAR(255)    NULL,
    AvatarUrl      NVARCHAR(255)    NULL,
    Biography      NVARCHAR(512)    NULL,
    CreatedAt      DATETIME2(3)     NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt      DATETIME2(3)     NOT NULL DEFAULT SYSUTCDATETIME(),

    -- Constraints
    CONSTRAINT pk_users PRIMARY KEY CLUSTERED (Id),
    Constraint fk_users_username Unique (Username),
    Constraint fk_users_email Unique (Email),
    CONSTRAINT chk_users_birthdate CHECK (Birthdate BETWEEN DATEADD(YEAR, -100, CAST(GETDATE() AS DATE)) AND GETDATE()),
    CONSTRAINT chk_users_status CHECK (Status BETWEEN 0 AND 2),
    CONSTRAINT chk_users_role CHECK (Role BETWEEN 0 AND 3)
);

-- Indexing
CREATE INDEX ix_users_username ON Users (Username);
CREATE INDEX ix_users_email ON Users (Email);
CREATE INDEX ix_users_status ON Users (Status);
CREATE INDEX ix_users_createdat ON Users (CreatedAt);
