Create Table Users
(
    Id             UNIQUEIDENTIFIER Not Null Default Newid(),
    Name           NVARCHAR(32) Not Null,
    Lastname       NVARCHAR(64) Not Null,
    Username       NVARCHAR(18) Not Null Unique,
    Email          NVARCHAR(255) Not Null Unique,
    EmailConfirmed BIT Not Null Default 0,
    Birthdate      DATE Not Null,
    Password       NVARCHAR(255) Not Null,
    Role           TINYINT Not Null Default 0,
    Status         TINYINT Not Null Default 0,
    NewEmail       NVARCHAR(255) Null,
    AvatarUrl      NVARCHAR(255) Null,
    Biography      NVARCHAR(512) Null,
    CreatedAt      DATETIME2(3) Not Null Default Sysutcdatetime(),
    UpdatedAt      DATETIME2(3) Not Null Default Sysutcdatetime(),
    
    -- Constraints 
    Constraint pk_users Primary Key Clustered (Id),
    Constraint fk_users_username Unique (Username),
    Constraint fk_users_email Unique (Email),
    Constraint chk_users_birthdate Check (Birthdate Between Dateadd(year, -100,Cast(Getdate() As DATE)) And Getdate()),
    Constraint chk_users_status Check (Status Between 0 And 2),
    Constraint chk_users_role Check (Role Between 0 And 3)
);

-- Indexing
Create Index ix_users_username
    On users(Username);

Create Index ix_users_email
    On users(Email);

Create Index ix_users_status
    On users(Status);

Create Index ix_users_createdat
    On users(Createdat); 