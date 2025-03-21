﻿using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public record CreateInstituteCommand(
    string Name,
    int Type,
    int Province,
    int District,
    string? Url,
    string UserId) : IRequest<ErrorOr<BoolResult>>;