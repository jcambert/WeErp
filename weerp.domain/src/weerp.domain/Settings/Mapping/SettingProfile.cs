using AutoMapper;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Dto;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Messages.Events;

namespace weerp.domain.Settings.Mapping
{
    public class SettingProfile:Profile
    {
        public SettingProfile()
        {
            CreateMap<CreateSetting, Setting>().ConstructUsing(e =>
               new Setting(e.Id, e.Numero, e.Description, e.Type, e.StringValue, e.IntegerValue, e.DoubleValue, e.DateValue)
           );
            CreateMap<CreateSetting, SettingCreated>().ConstructUsing(e =>
                new SettingCreated(e.Id, e.Numero, e.Description, e.Type, e.StringValue, e.IntegerValue, e.DoubleValue, e.DateValue)
            );
            CreateMap<Setting, SettingDto>().ConstructUsing(e =>
                 new SettingDto() { Id = e.Id, Numero = e.Numero, Description = e.Description, Type = e.Type, StringValue = e.StringValue, IntegerValue = e.IntegerValue, DoubleValue = e.DoubleValue, DateValue = e.DateValue }
            );
        }
    }
}
