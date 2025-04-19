﻿CREATE TABLE Institutions_Ratings_Aggregate (
    InstitutionRatingAggregateId UNIQUEIDENTIFIER PRIMARY KEY,
    Location FLOAT DEFAULT 0,
    Happiness FLOAT DEFAULT 0,
    Safety FLOAT DEFAULT 0,
    Reputation FLOAT DEFAULT 0,
    Opportunities FLOAT DEFAULT 0,
    Internet FLOAT DEFAULT 0,
    Food FLOAT DEFAULT 0,
    Social FLOAT DEFAULT 0,
    Facilities FLOAT DEFAULT 0,
    Clubs FLOAT DEFAULT 0,
    OverallAverage FLOAT DEFAULT 0,
    ReviewCount INT DEFAULT 0,

    FOREIGN KEY (InstitutionRatingAggregateId) REFERENCES Institutions(InstitutionId) ON DELETE CASCADE
);
