CREATE TABLE Institutes_Reviews_Summaries (
    InstituteId         UNIQUEIDENTIFIER PRIMARY KEY,
    TotalReviews        INT NOT NULL DEFAULT 0,
    TotalAverageScore   DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (TotalAverageScore BETWEEN 0.0 AND 5.0),
    Reputation          DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Reputation BETWEEN 0.0 AND 5.0),
    Opportunities       DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Opportunities BETWEEN 0.0 AND 5.0),
    Happiness           DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Happiness BETWEEN 0.0 AND 5.0),
    Location            DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Location BETWEEN 0.0 AND 5.0),
    Facilities          DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Facilities BETWEEN 0.0 AND 5.0),
    Social              DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Social BETWEEN 0.0 AND 5.0),
    Clubs               DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Clubs BETWEEN 0.0 AND 5.0),
    Internet            DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Internet BETWEEN 0.0 AND 5.0),
    Security            DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Security BETWEEN 0.0 AND 5.0),
    Food                DECIMAL(2,1) NOT NULL DEFAULT 0.0 CHECK (Food BETWEEN 0.0 AND 5.0),
    UpdatedAt           DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Institutes_Reviews_Summaries_Institutes FOREIGN KEY (InstituteId)
        REFERENCES Institutes(InstituteId) ON DELETE CASCADE
);
