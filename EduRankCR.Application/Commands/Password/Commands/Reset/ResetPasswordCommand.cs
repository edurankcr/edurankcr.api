﻿using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Password.Commands.Reset;

public record ResetPasswordCommand(string TokenId, string NewPassword) : IRequest<ErrorOr<BoolResult>>;