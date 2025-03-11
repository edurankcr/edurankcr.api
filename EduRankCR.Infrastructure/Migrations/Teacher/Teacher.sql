CREATE TABLE Teachers (
    TeacherId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    InstituteId UNIQUEIDENTIFIER NULL,  -- Allowed to be left without institute in case of closure
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Status TINYINT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Teachers_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserID) ON DELETE CASCADE, -- If a user is deleted, the teacher is deleted.

    CONSTRAINT FK_Teachers_Institutes FOREIGN KEY (InstituteId)
        REFERENCES Institutes(InstituteId) ON DELETE SET NULL -- If the institute is deleted, the teacher is left without an institute
);

-- Index on Foreign Keys to speed up JOINs
CREATE INDEX IX_Teachers_UserId ON Teachers(UserId);
CREATE INDEX IX_Teachers_InstituteId ON Teachers(InstituteId);

-- Index for filtering by Status (e.g., active/inactive teachers)
CREATE INDEX IX_Teachers_Status ON Teachers(Status);

-- Index for sorting by CreatedAt (useful for recent records queries)
CREATE INDEX IX_Teachers_CreatedAt ON Teachers(CreatedAt DESC);

-- Composite Index for common queries involving InstituteId and Status
CREATE INDEX IX_Teachers_Institute_Status ON Teachers(InstituteId, Status);

-- Covering Index for common queries selecting Name, LastName, and filtering by Status
CREATE INDEX IX_Teachers_Status_Name_LastName ON Teachers(Status, Name, LastName) INCLUDE (TeacherId);

-- Composite Index for filtering and sorting by CreatedAt
CREATE INDEX IX_Teachers_Status_CreatedAt ON Teachers(Status, CreatedAt DESC);
