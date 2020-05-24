using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.domain.Settings.Messages.Commands
{
    public class CreateSetting : SettingBaseCommand
    {
        [JsonConstructor]
        public CreateSetting(Guid id,
            int numero,
            string description,
            string type,
            string stringValue,
            int? intValue,
            double? doubleValue,
            DateTime? dtValue)
        {
            Id = id;
            Numero = numero;
            Description = description;
            Type = type;
            StringValue = stringValue;
            IntegerValue = intValue;
            DoubleValue = doubleValue;
            DateValue = dtValue;
        }
        public override Guid Id { get; set; }
        public int Numero { get; }

        public string Description { get; }

        public string Type { get; }

        public string StringValue { get; }

        public int? IntegerValue { get; }

        public double? DoubleValue { get; }

        public DateTime? DateValue { get; }
    }
}
