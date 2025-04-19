CREATE TABLE Institutions_Recommendations (
    InstitutionRecommendationId UNIQUEIDENTIFIER NOT NULL,
    RecommendedInstitutionId UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (InstitutionRecommendationId, RecommendedInstitutionId),
    FOREIGN KEY (InstitutionRecommendationId) REFERENCES Institutions(InstitutionId) ON DELETE CASCADE,
    FOREIGN KEY (RecommendedInstitutionId) REFERENCES Institutions(InstitutionId) ON DELETE NO ACTION
);
