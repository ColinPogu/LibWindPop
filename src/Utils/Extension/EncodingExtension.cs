using System.Collections.Generic;
using System.Text;

namespace LibWindPop.Utils.Extension
{
    internal static class EncodingExtension
    {
        private static Dictionary<EncodingType, Encoding> _cache = new Dictionary<EncodingType, Encoding>();

        public static Encoding GetEncoding(this EncodingType encodingType)
        {
            if (_cache.TryGetValue(encodingType, out Encoding? ans))
            {
                return ans;
            }
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding value = Encoding.GetEncoding((int)encodingType);
                _cache.Add(encodingType, value);
                return value;
            }
            catch
            {
                return Encoding.ASCII;
            }
        }
    }
}
