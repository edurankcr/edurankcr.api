﻿using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.ValueObjects;
using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IInstituteRepository
{
    Task<Institute?> Find(InstituteId instituteId);
    Task<(Institute? Institute, InstituteSummary? Summary)> Details(InstituteId instituteId);
    Task<Institute?> FindLastByUserId(UserId userId);
    Task Create(Institute institute);
    Task<InstituteReview?> FindReviewByInstitute(UserId userId, InstituteId instituteId);
    Task CreateReview(InstituteReview instituteReview, InstituteId instituteId, UserId userId);
    Task UpdateReview(
        ReviewId reviewId,
        decimal? Reputation,
        decimal? Opportunities,
        decimal? Happiness,
        decimal? Location,
        decimal? Facilities,
        decimal? Social,
        decimal? Clubs,
        decimal? Internet,
        decimal? Security,
        decimal? Food,
        string? ExperienceText);
}