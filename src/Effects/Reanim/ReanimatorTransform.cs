using System.Text.Json.Serialization;

namespace LibWindPop.Effects.Reanim
{
    public class ReanimatorTransform
    {
        [JsonPropertyName("x")]
        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? TransX = null;

        [JsonPropertyName("y")]
        [JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? TransY = null;

        [JsonPropertyName("sx")]
        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ScaleX = null;

        [JsonPropertyName("sy")]
        [JsonPropertyOrder(4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? ScaleY = null;

        [JsonPropertyName("kx")]
        [JsonPropertyOrder(5)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? SkewX = null;

        [JsonPropertyName("ky")]
        [JsonPropertyOrder(6)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? SkewY = null;

        [JsonPropertyName("f")]
        [JsonPropertyOrder(7)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Frame = null;

        [JsonPropertyName("a")]
        [JsonPropertyOrder(8)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Alpha = null;

        [JsonPropertyName("i")]
        [JsonPropertyOrder(9)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Image = null;

        [JsonPropertyName("font")]
        [JsonPropertyOrder(10)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Font = null;

        [JsonPropertyName("text")]
        [JsonPropertyOrder(11)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text = null;

        public bool IsNull()
        {
            return TransX == null
                   && TransY == null
                   && ScaleX == null
                   && ScaleY == null
                   && SkewX == null
                   && SkewY == null
                   && Frame == null
                   && Alpha == null
                   && Image == null
                   && Font == null
                   && Text == null;
        }
    }
}
