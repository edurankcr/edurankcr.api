using EduRankCR.Application.Account.Commands.UploadAvatar;
using EduRankCR.Application.Account.Common;
using Mapster;

namespace EduRankCR.Api.Common.Mapping;

public class AccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UploadAvatarResult, UploadAvatarCommand>();
    }
}