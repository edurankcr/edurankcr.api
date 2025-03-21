﻿namespace EduRankCR.Application.Commands.Institute.Common;

public record SearchInstituteResponse(
    string Name,
    int Type,
    int Province,
    int District,
    string? Url);