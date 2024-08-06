using System.Text.Json.Serialization;

namespace LibWindPop.Effects.Reanim
{
    [JsonConverter(typeof(JsonStringEnumConverter<ReanimScaleType>))]
    public enum ReanimScaleType : sbyte
    {
        NoScale = 0,
        InvertAndScale = 1,
        ScaleFromPC = -1,
    }
}
