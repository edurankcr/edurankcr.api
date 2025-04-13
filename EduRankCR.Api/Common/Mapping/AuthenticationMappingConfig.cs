using EduRankCR.Application.Commands.Auth.Common;
using EduRankCR.Application.Commands.Auth.Queries.Login;
using EduRankCR.Application.Commands.Institute.Common;
using EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;
using EduRankCR.Application.Commands.Profile.Common;
using EduRankCR.Application.Commands.Register.Commands.Register;
using EduRankCR.Application.Commands.Reviews.Common;
using EduRankCR.Contracts.Auth;
using EduRankCR.Contracts.Institute;
using EduRankCR.Contracts.Profile;
using EduRankCR.Contracts.Register;
using EduRankCR.Contracts.Reviews;
using EduRankCR.Domain.InstituteAggregate.Entities;

using Mapster;

namespace EduRankCR.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginAuthQuery>();

        config.NewConfig<LoginResult, LoginResponse>()
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Token, src => src.Token);

        config.NewConfig<ProfileResult, ProfileResponse>()
            .Map(dest => dest, src => src.User);

        config.NewConfig<SearchInstituteResult, SearchInstituteResponse>()
            .Map(dest => dest.Institute, src => src.Institute)
            .Map(dest => dest.Summary, src => src.Summary);

        config.NewConfig<Institute, InstituteResponse>()
            .Map(dest => dest.InstituteId, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Type, src => (byte)src.Type)
            .Map(dest => dest.Province, src => (byte)src.Province)
            .Map(dest => dest.Url, src => src.Url)
            .Map(dest => dest.Status, src => (byte)src.Status);

        config.NewConfig<InstituteSummary, InstituteSummaryResponse>()
            .Map(dest => dest.InstituteId, src => src.Id.Value)
            .Map(dest => dest.TotalReviews, src => src.TotalReviews)
            .Map(dest => dest.TotalAverageScore, src => src.TotalAverageScore)
            .Map(dest => dest.Reputation, src => src.Reputation)
            .Map(dest => dest.Opportunities, src => src.Opportunities)
            .Map(dest => dest.Happiness, src => src.Happiness)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.Facilities, src => src.Facilities)
            .Map(dest => dest.Social, src => src.Social)
            .Map(dest => dest.Clubs, src => src.Clubs)
            .Map(dest => dest.Internet, src => src.Internet)
            .Map(dest => dest.Security, src => src.Security)
            .Map(dest => dest.Food, src => src.Food)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

        config.NewConfig<ChangeAvatarRequest, ChangeAvatarProfileCommand>()
            .Map(dest => dest.Avatar, src => src.Avatar);

        config.NewConfig<SearchInstituteResult, SearchInstituteResponse>()
            .Map(dest => dest, src => src);

        config.NewConfig<LastReviewsResult, LastReviewsResponse>()
            .Map(dest => dest, src => src);
    }
}