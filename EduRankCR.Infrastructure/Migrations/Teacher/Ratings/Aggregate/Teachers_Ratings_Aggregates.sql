CREATE TABLE Teachers_Ratings_Aggregates
(
    TeacherId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Clarity FLOAT NOT NULL,
    Knowledge FLOAT NOT NULL,
    Respect FLOAT NOT NULL,
    Fairness FLOAT NOT NULL,
    Punctuality FLOAT NOT NULL,
    Motivation FLOAT NOT NULL,
    WouldTakeAgainRatio FLOAT NOT NULL,
    OverallAverage FLOAT NOT NULL,
    ReviewCount INT NOT NULL,
    CONSTRAINT FK_TeacherAggregates_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId)
);
