using System;
using System.Diagnostics.CodeAnalysis;

namespace LibWindPop.Utils
{
    public static class SureHelper
    {
        public static void MakeSure([DoesNotReturnIf(false)] bool value)
        {
            if (!value)
            {
                throw new Exception();
            }
        }
    }
}
