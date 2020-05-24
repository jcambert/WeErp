using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.domain.Settings.Dto;
using weerp.domain.Settings.Queries;

namespace weerp.api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISettingsService
    {
        [AllowAnyStatusCode]
        [Get("settings/{id}")]
        Task<SettingDto> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("settings")]
        Task<PagedResult<SettingDto>> BrowseAsync([Query] BrowseSettings query);
    }
}
