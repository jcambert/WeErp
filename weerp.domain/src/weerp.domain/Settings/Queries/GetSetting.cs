using MicroS_Common.Types;
using System;
using weerp.domain.Settings.Dto;

namespace weerp.domain.Settings.Queries
{
    public class GetSetting : IQuery<SettingDto>
    {
        public Guid Id { get; set; }
    }
}
