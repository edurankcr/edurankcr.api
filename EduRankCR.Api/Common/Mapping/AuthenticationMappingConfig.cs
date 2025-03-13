using EduRankCR.Application.Commands.Auth.Common;
using EduRankCR.Application.Commands.Auth.Queries.Login;
using EduRankCR.Application.Commands.Institute.Common;
using EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;
using EduRankCR.Application.Commands.Profile.Common;
using EduRankCR.Application.Commands.Register.Commands.Register;
using EduRankCR.Contracts.Auth;
using EduRankCR.Contracts.Profile;
using EduRankCR.Contracts.Register;

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
            .Map(dest => dest, src => src);
        config.NewConfig<ChangeAvatarRequest, ChangeAvatarProfileCommand>()
            .Map(dest => dest.Avatar, src => src.Avatar);

        config.NewConfig<SearchInstituteResult, SearchInstituteResponse>()
            .Map(dest => dest.Name, src => src.Institute.Name)
            .Map(dest => dest.Type, src => src.Institute.Type)
            .Map(dest => dest.Province, src => src.Institute.Province)
            .Map(dest => dest.District, src => src.Institute.District)
            .Map(dest => dest.Url, src => src.Institute.Url);
    }
}