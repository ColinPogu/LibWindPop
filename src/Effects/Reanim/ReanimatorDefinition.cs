using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibWindPop.Effects.Reanim;

public class ReanimatorDefinition
{
    [JsonPropertyName("doScale")]
    [JsonPropertyOrder(1)]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ReanimScaleType DoScale = ReanimScaleType.ScaleFromPC;
    
    [JsonPropertyName("fps")]
    [JsonPropertyOrder(2)]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float Fps = 12.0f;
    
    [JsonPropertyName("tracks")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public List<ReanimatorTrack> Tracks = new List<ReanimatorTrack>();
}
