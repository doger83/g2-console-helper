using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleHelperLib
{
    public static partial class ConsoleUtils
    {
        #region kernel32.dll

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr GetConsoleWindow();


        #endregion

    }
}
