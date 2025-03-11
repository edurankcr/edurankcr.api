CREATE TABLE Institutes (
    InstituteId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NULL, -- Allowed to be left without user in case of closure
    Name NVARCHAR(200) NOT NULL,
    Type TINYINT NOT NULL DEFAULT 0,
    Province TINYINT NOT NULL DEFAULT 0,
    District SMALLINT NOT NULL DEFAULT 0,
    Url NVARCHAR(350),
    Status TINYINT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Institutes_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserID) ON DELETE SET NULL -- If the user is deleted, the institute is left without an user
);

-- Index on Foreign Key (UserId) to speed up joins and lookups
CREATE INDEX IX_Institutes_UserId ON Institutes(UserId);

-- Index on Name for faster text searches
CREATE INDEX IX_Institutes_Name ON Institutes(Name);

-- Composite Index on Type, Province, and District for filtering and grouping
CREATE INDEX IX_Institutes_Type_Province_District ON Institutes(Type, Province, District);

-- Index on Status for filtering active/inactive institutes
CREATE INDEX IX_Institutes_Status ON Institutes(Status);

-- Index on CreatedAt for queries that fetch recently added institutes
CREATE INDEX IX_Institutes_CreatedAt ON Institutes(CreatedAt);

-- Index on UpdatedAt for queries tracking changes over time
CREATE INDEX IX_Institutes_UpdatedAt ON Institutes(UpdatedAt);

-- Covering Index for common queries that involve Name, Type, Province, and District
CREATE INDEX IX_Institutes_Covering
    ON Institutes(Name, Type, Province, District)
    INCLUDE (Status, CreatedAt);
