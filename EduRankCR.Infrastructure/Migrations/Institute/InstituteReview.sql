CREATE TABLE InstitutesReviews (
    ReviewId            UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId              UNIQUEIDENTIFIER NOT NULL,
    InstituteId         UNIQUEIDENTIFIER NULL,  -- Allowed to be left without institute in case of closure
    Reputation          DECIMAL(2,1) NOT NULL CHECK (Reputation BETWEEN 1.0 AND 5.0),
    Opportunities       DECIMAL(2,1) NOT NULL CHECK (Opportunities BETWEEN 1.0 AND 5.0),
    Happiness           DECIMAL(2,1) NOT NULL CHECK (Happiness BETWEEN 1.0 AND 5.0),
    Location            DECIMAL(2,1) NOT NULL CHECK (Location BETWEEN 1.0 AND 5.0),
    Facilities          DECIMAL(2,1) NOT NULL CHECK (Facilities BETWEEN 1.0 AND 5.0),
    Social              DECIMAL(2,1) NOT NULL CHECK (Social BETWEEN 1.0 AND 5.0),
    Clubs               DECIMAL(2,1) NOT NULL CHECK (Clubs BETWEEN 1.0 AND 5.0),
    Internet            DECIMAL(2,1) NOT NULL CHECK (Internet BETWEEN 1.0 AND 5.0),
    Security            DECIMAL(2,1) NOT NULL CHECK (Security BETWEEN 1.0 AND 5.0),
    Food                DECIMAL(2,1) NOT NULL CHECK (Food BETWEEN 1.0 AND 5.0),
    ExperienceText      NVARCHAR(510) NOT NULL,
    Status              TINYINT NOT NULL DEFAULT 0,
    CreatedAt           DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt           DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_InstitutesReviews_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserID) ON DELETE CASCADE, -- If a user is deleted, the review is deleted.

    CONSTRAINT FK_InstitutesReviews_Institutes FOREIGN KEY (InstituteId)
        REFERENCES Institutes(InstituteId) ON DELETE SET NULL
);

-- Index on Foreign Keys to speed up JOINs
CREATE INDEX IX_InstitutesReviews_UserId ON InstitutesReviews(UserId);
CREATE INDEX IX_InstitutesReviews_InstituteId ON InstitutesReviews(InstituteId);

-- Index for filtering by Status (e.g., approved/pending/deleted reviews)
CREATE INDEX IX_InstitutesReviews_Status ON InstitutesReviews(Status);

-- Composite Index for queries filtering by InstituteId and Status
CREATE INDEX IX_InstitutesReviews_Institute_Status ON InstitutesReviews(InstituteId, Status);

-- Index for sorting by CreatedAt (e.g., latest reviews first)
CREATE INDEX IX_InstitutesReviews_CreatedAt ON InstitutesReviews(CreatedAt DESC);

-- Composite Index for filtering and sorting by InstituteId and CreatedAt
CREATE INDEX IX_InstitutesReviews_Institute_CreatedAt ON InstitutesReviews(InstituteId, CreatedAt DESC);

-- Composite Index for retrieving overall ratings efficiently
CREATE INDEX IX_InstitutesReviews_Reputation_Opportunities_Happiness
    ON InstitutesReviews(Reputation, Opportunities, Happiness);

-- Covering Index for performance on key review retrieval queries
CREATE INDEX IX_InstitutesReviews_Institute_Rating_Experience
    ON InstitutesReviews(InstituteId, Reputation) INCLUDE (ExperienceText, Status, CreatedAt);
