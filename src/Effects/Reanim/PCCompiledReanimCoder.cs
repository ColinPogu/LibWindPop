using LibWindPop.Effects.Compiled;
using LibWindPop.Utils;
using LibWindPop.Utils.Extension;
using System.IO;
using System.Text;

namespace LibWindPop.Effects.Reanim
{
    public static class PCCompiledReanimCoder
    {
        private static readonly Encoding _encoding = EncodingType.utf_8.GetEncoding();

        public static ReanimatorDefinition Decode(Stream streamInput)
        {
            using (Stream stream = Compiled32Shell.Decode(streamInput))
            {
                ReanimatorDefinition reanim = new ReanimatorDefinition();
                reanim.DoScale = ReanimScaleType.ScaleFromPC;
                stream.ReadInt64LE();
                int trackCount = stream.ReadInt32LE();
                reanim.Fps = stream.ReadFloat32LE();
                stream.ReadInt64LE();
                for (int i = 0; i < trackCount; i++)
                {
                    ReanimatorTrack track = new ReanimatorTrack();
                    InitializeTrack(track, stream);
                    reanim.Tracks.Add(track);
                }
                for (int i = 0; i < trackCount; i++)
                {
                    ReadTrack(reanim.Tracks[i], stream);
                }
                return reanim;
            }
        }

        private static void InitializeTrack(ReanimatorTrack track, Stream stream)
        {
            stream.ReadInt64LE();
            int transformCount = stream.ReadInt32LE();
            for (int i = 0; i < transformCount; i++)
            {
                track.Transforms.Add(new ReanimatorTransform());
            }
        }

        private static void ReadTrack(ReanimatorTrack track, Stream stream)
        {
            int nameSize = stream.ReadInt32LE();
            track.Name = stream.ReadString(nameSize, _encoding);
            stream.ReadInt32LE();
            int transformCount = track.Transforms.Count;
            for (int i = 0; i < transformCount; i++)
            {
                ReadTransform(track.Transforms[i], stream);
            }
            for (int i = 0; i < transformCount; i++)
            {
                ReadTransformObject(track.Transforms[i], stream);
            }
        }

        private static void ReadTransform(ReanimatorTransform transform, Stream stream)
        {
            transform.TransX = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.TransY = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.SkewX = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.SkewY = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.ScaleX = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.ScaleY = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.Frame = ReanimHelper.Clean(stream.ReadFloat32LE());
            transform.Alpha = ReanimHelper.Clean(stream.ReadFloat32LE());
            stream.ReadInt32LE();
            stream.ReadInt32LE();
            stream.ReadInt32LE();
        }

        private static void ReadTransformObject(ReanimatorTransform transform, Stream stream)
        {
            transform.Image = stream.ReadString(stream.ReadInt32LE(), _encoding);
            transform.Font = stream.ReadString(stream.ReadInt32LE(), _encoding);
            transform.Text = stream.ReadString(stream.ReadInt32LE(), _encoding);
        }
    }
}
