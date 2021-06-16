using System.Runtime.InteropServices;

namespace ConsoleHelperLib
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CHAR_UNION
    {
        [FieldOffset(0)] public char UnicodeChar;

        [FieldOffset(0)] public byte AsciiChar;
    }
}