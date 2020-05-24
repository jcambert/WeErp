using MicroS_Common.Repository;
using System.Threading.Tasks;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Dto;
using weerp.domain.Settings.Queries;

namespace weerp.Services.Settings.Repositories
{
    public interface ISettingsRepository : IBrowseRepository<Setting, BrowseSettings,SettingDto>
    {
        Task<bool> ExistsAsync(int numero);
    }
}
