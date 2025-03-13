namespace EduRankCR.Application.DTOs;

public class TeacherSummaryDto
{
    public Guid TeacherId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid InstituteId { get; set; }
    public string InstituteName { get; set; } = string.Empty;

    public TeacherSummaryDto() { }

    public TeacherSummaryDto(Guid teacherId, string name, string lastName, Guid instituteId, string instituteName)
    {
        TeacherId = teacherId;
        Name = name;
        LastName = lastName;
        InstituteId = instituteId;
        InstituteName = instituteName;
    }
}