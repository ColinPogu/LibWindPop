using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibWindPop.Effects.Reanim
{
    public class ReanimatorTrack
    {
        [JsonPropertyName("name")]
        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string? Name = null;

        [JsonPropertyName("transforms")]
        [JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public List<ReanimatorTransform> Transforms = new List<ReanimatorTransform>();
    }
}
