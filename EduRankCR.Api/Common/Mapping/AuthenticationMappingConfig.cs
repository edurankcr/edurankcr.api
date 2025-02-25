using EduRankCR.Application.Auth.Common;
using EduRankCR.Application.Auth.Queries.Login;
using EduRankCR.Application.Profile.Commands.Avatar;
using EduRankCR.Application.Profile.Common;
using EduRankCR.Application.Register.Commands.Register;
using EduRankCR.Contracts.Auth;
using EduRankCR.Contracts.Common;
using EduRankCR.Contracts.Profile;
using EduRankCR.Contracts.Register;

using Mapster;

namespace EduRankCR.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<LoginResult, LoginResponse>()
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Token, src => src.Token);
        config.NewConfig<ProfileResult, ProfileResponse>()
            .Map(dest => dest, src => src.User);
        config.NewConfig<ChangeAvatarRequest, ChangeAvatarCommand>()
            .Map(dest => dest.Avatar, src => src.Avatar);
    }
}