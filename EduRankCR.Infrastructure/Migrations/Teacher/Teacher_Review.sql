CREATE TABLE Teachers_Reviews (
    ReviewId            UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId              UNIQUEIDENTIFIER NOT NULL,
    TeacherId           UNIQUEIDENTIFIER NULL,  -- Allowed to be left without teacher in case of closure
    InstituteId         UNIQUEIDENTIFIER NULL,  -- Allowed to be left without institution in case of closure
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
        REFERENCES Teachers(TeacherId) ON DELETE NO ACTION,

    CONSTRAINT FK_TeachersReviews_Institutions FOREIGN KEY (InstituteId)
        REFERENCES Institutes(InstituteId) ON DELETE NO ACTION
);

-- Index on Foreign Keys to speed up JOINs
CREATE INDEX IX_TeacherReviews_UserId ON Teachers_Reviews(UserId);
CREATE INDEX IX_TeacherReviews_TeacherId ON Teachers_Reviews(TeacherId);
CREATE INDEX IX_TeacherReviews_InstituteId ON Teachers_Reviews(InstituteId);

-- Index for filtering by Status (e.g., approved/pending/deleted reviews)
CREATE INDEX IX_TeacherReviews_Status ON Teachers_Reviews(Status);

-- Index for filtering by CourseMode (e.g., online/in-person/hybrid courses)
CREATE INDEX IX_TeacherReviews_CourseMode ON Teachers_Reviews(CourseMode);

-- Composite Index for filtering by TeacherId and Status (commonly used together)
CREATE INDEX IX_TeacherReviews_Teacher_Status ON Teachers_Reviews(TeacherId, Status);

-- Composite Index for filtering by InstituteId and Status (common filter for institution-based searches)
CREATE INDEX IX_TeacherReviews_Institute_Status ON Teachers_Reviews(InstituteId, Status);

-- Composite Index for filtering by FreeCourse and CourseMode (useful for searching courses)
CREATE INDEX IX_TeacherReviews_FreeCourse_CourseMode ON Teachers_Reviews(FreeCourse, CourseMode);

-- Composite Index for filtering by ProfessorRating and DifficultyRating (common filters in review aggregations)
CREATE INDEX IX_TeacherReviews_Professor_Difficulty_Rating ON Teachers_Reviews(ProfessorRating, DifficultyRating);

-- Index for sorting by CreatedAt (e.g., latest reviews first)
CREATE INDEX IX_TeacherReviews_CreatedAt ON Teachers_Reviews(CreatedAt DESC);

-- Composite Index for filtering and sorting by TeacherId and CreatedAt
CREATE INDEX IX_TeacherReviews_Teacher_CreatedAt ON Teachers_Reviews(TeacherId, CreatedAt DESC);

-- Composite Index for filtering and sorting by InstituteId and CreatedAt
CREATE INDEX IX_TeacherReviews_Institute_CreatedAt ON Teachers_Reviews(InstituteId, CreatedAt DESC);

-- Covering Index for performance on key review retrieval queries
CREATE INDEX IX_TeacherReviews_Teacher_ProfessorRating_Experience
    ON Teachers_Reviews(TeacherId, ProfessorRating) INCLUDE (ExperienceText, DifficultyRating, Status, CreatedAt);

-- Covering Index for retrieving institute-related review details efficiently
CREATE INDEX IX_TeacherReviews_Institute_ProfessorRating_Experience
    ON Teachers_Reviews(InstituteId, ProfessorRating) INCLUDE (ExperienceText, DifficultyRating, Status, CreatedAt);
