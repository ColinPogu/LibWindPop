using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using LibWindPop.Utils.Extension;
using System.IO;

namespace LibWindPop.Effects.Compiled
{
    public static class Compiled32Shell
    {
        public const int MAGIC_COMPILED_32 = -559022380;

        public static MemoryStream Decode(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            int head = stream.ReadInt32LE();
            if (head != MAGIC_COMPILED_32)
            {
                stream.Seek(-4, SeekOrigin.Current);
                stream.CopyTo(ms);
            }
            else
            {
                int size = stream.ReadInt32LE();
                using (InflaterInputStream zlibStream = new InflaterInputStream(stream))
                {
                    zlibStream.IsStreamOwner = false;
                    zlibStream.CopyTo(ms);
                }
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
