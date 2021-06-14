using System.Runtime.InteropServices;

namespace ConsoleHelperLib.pInvoke
{

    [StructLayout(LayoutKind.Explicit)]
    public struct CHAR_INFO
    {
        [FieldOffset(0)] public CHAR_UNION Char;


        [FieldOffset(2)] public short Attributes;

    }
}