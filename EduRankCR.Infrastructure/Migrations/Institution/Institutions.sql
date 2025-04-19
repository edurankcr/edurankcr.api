CREATE TABLE Institutions (
    InstitutionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX),
    Province TINYINT NOT NULL,
    Type TINYINT NOT NULL,
    WebsiteUrl NVARCHAR(255),
    AiReviewSummary NVARCHAR(MAX),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    Status TINYINT NOT NULL
);

CREATE INDEX IX_Institutions_Name ON Institutions (Name);
CREATE INDEX IX_Institutions_Province ON Institutions (Province);
CREATE INDEX IX_Institutions_Type ON Institutions (Type);
CREATE INDEX IX_Institutions_Status ON Institutions (Status);
CREATE INDEX IX_Institutions_CreatedAt ON Institutions (CreatedAt DESC);
