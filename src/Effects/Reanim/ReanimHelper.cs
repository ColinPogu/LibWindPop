using System.Runtime.CompilerServices;

namespace LibWindPop.Effects.Reanim
{
    public class ReanimHelper
    {
        public const float DEFAULT_FIELD_PLACEHOLDER = -10000f;
        public const float DEFAULT_FIELD_PLACEHOLDER_WP = -99999f;

        public static bool IsNull(float prop)
        {
            return prop == DEFAULT_FIELD_PLACEHOLDER || prop == DEFAULT_FIELD_PLACEHOLDER_WP;
        }

        public static float? Clean(float prop)
        {
            if (prop == DEFAULT_FIELD_PLACEHOLDER)
            {
                return null;
            }
            return prop;
        }
    }
}
