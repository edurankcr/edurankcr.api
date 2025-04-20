using EduRankCR.Application.Search.Common;
using EduRankCR.Contracts.Search.Responses;

using Mapster;

namespace EduRankCR.Api.Common.Mapping;

public class SearchMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SearchMeta, SearchMetaResponse>();

        config.NewConfig<SearchInstitutionItem, SearchInstitutionResponse>()
            .Map(dest => dest.InstitutionId, src => src.InstitutionId);

        config.NewConfig<SearchTeacherItem, SearchTeacherResponse>()
            .Map(dest => dest.TeacherId, src => src.TeacherId);

        config.NewConfig<SearchResult, SearchResponse>()
            .Map(dest => dest.Meta, src => src.Meta)
            .Map(dest => dest.Results, src => new SearchResultsResponse(
                src.Institutions.Adapt<List<SearchInstitutionResponse>>(),
                src.Teachers.Adapt<List<SearchTeacherResponse>>()));
    }
}