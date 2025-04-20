CREATE TABLE Teachers_Institutions
(
    TeacherInstitutionId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    TeacherId UNIQUEIDENTIFIER NOT NULL,
    InstitutionId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_TeachersInstitutions_Teacher FOREIGN KEY (TeacherId) REFERENCES Teachers(TeacherId),
    CONSTRAINT FK_TeachersInstitutions_Institution FOREIGN KEY (InstitutionId) REFERENCES Institutions(InstitutionId)
);
