using LibWindPop.Utils.FileSystem;
using LibWindPop.Utils.Logger;
using System.IO;
using System.Text;

namespace LibWindPop.Texts.LawnStrings
{
    public static class TodStringFile
    {
        public static void Write(LawnStringDictionary<string, string> gStringProperties, string theFileName, IFileSystem fileSystem, ILogger logger)
        {
            using (Stream stream = fileSystem.Create(theFileName))
            {
                Write(gStringProperties, stream, logger);
            }
        }

        public static void Write(LawnStringDictionary<string, string> gStringProperties, Stream stream, ILogger logger)
        {
            using (StreamWriter streamWriter = new StreamWriter(stream, encoding: Encoding.Unicode, leaveOpen: true))
            {
                int count = gStringProperties.Count;
                for (int i = 0; i < count; i++)
                {
                    var pair = gStringProperties[i];
                    streamWriter.Write('[');
                    streamWriter.Write(pair.Key);
                    streamWriter.WriteLine(']');
                    streamWriter.WriteLine(pair.Value);
                    streamWriter.WriteLine();
                }
            }
        }

        public static LawnStringDictionary<string, string>? Read(Stream stream, ILogger logger)
        {
            LawnStringDictionary<string, string> gStringProperties = new LawnStringDictionary<string, string>();
            using (StreamReader streamReader = new StreamReader(stream, leaveOpen: true))
            {
                string theFileText = streamReader.ReadToEnd();
                if (!TodStringListReadItems(theFileText, gStringProperties, logger))
                {
                    return null;
                }
            }
            return gStringProperties;
        }

        public static LawnStringDictionary<string, string>? Read(string theFileName, IFileSystem fileSystem, ILogger logger)
        {
            using (Stream stream = fileSystem.OpenRead(theFileName))
            {
                return Read(stream, logger);
            }
        }

        private static bool TodStringListReadName(string theFileText, ref string theName, ref int theStartIndex, ILogger logger)
        {
            int aNameStartIndex = theFileText.IndexOf('[', theStartIndex);
            if (aNameStartIndex == -1)
            {
                int spn = StrSpn(theFileText, " \n\r\t", theStartIndex);
                if (spn != (theFileText.Length - theStartIndex))
                {
                    logger.LogError("Failed to find string name");
                    return false;
                }
                theName = string.Empty;
                return true;
            }
            else
            {
                int aNameEndIndex = theFileText.IndexOf(']', aNameStartIndex + 1);
                if (aNameEndIndex == -1)
                {
                    logger.LogError("Failed to find ']'");
                    return false;
                }
                int aCount = aNameEndIndex - aNameStartIndex - 1;
                theName = theFileText.Substring(aNameStartIndex + 1, aCount);
                if (theName.Length == 0)
                {
                    logger.LogError("Name Too Short");
                    return false;
                }
                theStartIndex += aCount + 2;
                return true;
            }
        }

        private static void TodStringRemoveReturnChars(ref string theValue)
        {
            theValue = theValue.Replace("\r", "");
        }

        private static bool TodStringListReadValue(string theFileText, ref string theValue, ref int theStartIndex, ILogger logger)
        {
            int aValueEndIndex = theFileText.IndexOf('[', theStartIndex);
            int aLen = aValueEndIndex != -1 ? (aValueEndIndex - theStartIndex) : (theFileText.Length - theStartIndex);
            theValue = theFileText.Substring(theStartIndex, aLen).Trim();
            TodStringRemoveReturnChars(ref theValue);
            theStartIndex += aLen;
            return true;
        }

        private static bool TodStringListReadItems(string theFileText, LawnStringDictionary<string, string> gStringProperties, ILogger logger)
        {
            int aPtr = 0;
            string aName = string.Empty;
            string aValue = string.Empty;
            while (true)
            {
                if (!TodStringListReadName(theFileText, ref aName, ref aPtr, logger))
                {
                    return false;
                }
                if (aName.Length == 0)
                {
                    return true;
                }
                if (!TodStringListReadValue(theFileText, ref aValue, ref aPtr, logger))
                {
                    return false;
                }
                string aNameUpper = aName.ToUpper();
                gStringProperties.Add(aNameUpper, aValue);
            }
        }

        private static int StrSpn(string InputString, string Mask, int start)
        {
            int count = 0;
            for (int i = start; i < InputString.Length; i++)
            {
                if (!Mask.Contains(InputString[i]))
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}
