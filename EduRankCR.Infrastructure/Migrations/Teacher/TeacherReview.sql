CREATE TABLE TeachersReviews (
    ReviewId            UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId              UNIQUEIDENTIFIER NOT NULL,
    TeacherId           UNIQUEIDENTIFIER NULL,  -- Allowed to be left without institute in case of closure
    FreeCourse          BIT NOT NULL,
    CourseCode          NVARCHAR(64) NULL,
    CourseMode          TINYINT NOT NULL DEFAULT 0,
    ProfessorRating     DECIMAL(2,1) NOT NULL CHECK (ProfessorRating BETWEEN 1.0 AND 5.0),
    DifficultyRating    DECIMAL(2,1) NOT NULL CHECK (DifficultyRating BETWEEN 1.0 AND 5.0),
    WouldTakeAgain      BIT NULL,
    MandatoryAttendance BIT NULL,
    GradeReceived       NVARCHAR(5),
    ExperienceText      NVARCHAR(510) NOT NULL,
    Status              TINYINT NOT NULL DEFAULT 0,
    CreatedAt           DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt           DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_TeachersReviews_Users FOREIGN KEY (UserId)
        REFERENCES Users(UserID) ON DELETE CASCADE, -- If a user is deleted, the review is deleted.

    CONSTRAINT FK_TeachersReviews_Teachers FOREIGN KEY (TeacherId)
        REFERENCES Teachers(TeacherId) ON DELETE NO ACTION
);

-- Index on Foreign Keys to speed up JOINs
CREATE INDEX IX_TeachersReviews_UserId ON TeachersReviews(UserId);
CREATE INDEX IX_TeachersReviews_TeacherId ON TeachersReviews(TeacherId);

-- Index for filtering by Status (e.g., approved/pending/deleted reviews)
CREATE INDEX IX_TeachersReviews_Status ON TeachersReviews(Status);

-- Index for filtering by CourseMode (e.g., online/in-person/hybrid courses)
CREATE INDEX IX_TeachersReviews_CourseMode ON TeachersReviews(CourseMode);

-- Composite Index for queries filtering by TeacherId and Status
CREATE INDEX IX_TeachersReviews_Teacher_Status ON TeachersReviews(TeacherId, Status);

-- Composite Index for filtering by FreeCourse and CourseMode (common filters for course searches)
CREATE INDEX IX_TeachersReviews_FreeCourse_CourseMode ON TeachersReviews(FreeCourse, CourseMode);

-- Composite Index for filtering by ProfessorRating and DifficultyRating (useful for review aggregation)
CREATE INDEX IX_TeachersReviews_Professor_Difficulty_Rating ON TeachersReviews(ProfessorRating, DifficultyRating);

-- Index for sorting by CreatedAt (e.g., latest reviews first)
CREATE INDEX IX_TeachersReviews_CreatedAt ON TeachersReviews(CreatedAt DESC);

-- Covering Index for retrieving key review data quickly
CREATE INDEX IX_TeachersReviews_Teacher_ProfessorRating_Experience
    ON TeachersReviews(TeacherId, ProfessorRating) INCLUDE (ExperienceText, DifficultyRating, Status, CreatedAt);
