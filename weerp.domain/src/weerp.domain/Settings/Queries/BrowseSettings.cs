using MicroS_Common.Types;
using weerp.domain.Settings.Dto;

namespace weerp.domain.Settings.Queries
{
    public class BrowseSettings : PagedQueryBase, IQuery<PagedResult<SettingDto>>
    {
        public string Type { get; set; }
    }
}
