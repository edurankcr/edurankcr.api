namespace EduRankCR.Application.DTOs;

public class InstituteSummaryDto
{
    public Guid InstituteId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Type { get; set; }
    public int Province { get; set; }
    public int District { get; set; }
    public string? Url { get; set; }

    public InstituteSummaryDto() { }

    public InstituteSummaryDto(Guid instituteId, string name, int type, int province, int district, string? url)
    {
        InstituteId = instituteId;
        Name = name;
        Type = type;
        Province = province;
        District = district;
        Url = url;
    }
}