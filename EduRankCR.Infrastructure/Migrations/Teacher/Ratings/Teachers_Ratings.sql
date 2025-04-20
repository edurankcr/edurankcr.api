CREATE TABLE Teachers_Ratings
(
    TeacherRatingId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    TeacherId UNIQUEIDENTIFIER NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Clarity TINYINT NOT NULL,
    Knowledge TINYINT NOT NULL,
    Respect TINYINT NOT NULL,
    Fairness TINYINT NOT NULL,
    Punctuality TINYINT NOT NULL,
    Motivation TINYINT NOT NULL,
    WouldTakeAgain BIT NOT NULL,
    Testimony NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    UpdatedAt DATETIME2 NULL,
    Status TINYINT NOT NULL,
    CONSTRAINT FK_TeacherRatings_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId),
    CONSTRAINT FK_TeacherRatings_User FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
