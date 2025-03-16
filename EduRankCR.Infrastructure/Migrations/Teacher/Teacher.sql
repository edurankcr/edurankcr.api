CREATE TABLE Teachers (
    TeacherId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Status TINYINT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Teachers_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserID) ON DELETE CASCADE,
);

-- Index on Foreign Key to speed up JOINs with Users
CREATE INDEX IX_Teachers_UserId ON Teachers(UserId);

-- Index for filtering by Status (e.g., active/inactive teachers)
CREATE INDEX IX_Teachers_Status ON Teachers(Status);

-- Index for sorting by CreatedAt (e.g., retrieving recently added teachers)
CREATE INDEX IX_Teachers_CreatedAt ON Teachers(CreatedAt DESC);

-- Composite Index for searching by Name and LastName (common search pattern)
CREATE INDEX IX_Teachers_Name_LastName ON Teachers(Name, LastName);

-- Composite Index for filtering and sorting by Status and CreatedAt
CREATE INDEX IX_Teachers_Status_CreatedAt ON Teachers(Status, CreatedAt DESC);
