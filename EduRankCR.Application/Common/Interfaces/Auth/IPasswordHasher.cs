﻿namespace EduRankCR.Application.Common.Interfaces.Auth;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
