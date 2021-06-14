using System;
using System.Drawing;           // NOTE: Project + Add Reference required
using System.Windows.Forms;     // NOTE: Project + Add Reference required
using static ConsoleHelperLib.pInvoke.Constants;
using static ConsoleHelperLib.pInvoke.DLL_Imports;


namespace ConsoleHelperLib
{
    public static class ConsoleUtils
    {
        /// <summary>
        /// Sets the position of the console window relative to the upper-left corner of the screen at the given input.
        /// </summary>
        /// <remarks>
        /// <para><see cref="int"/> <paramref name="posX"/>: The new position of the left side of the window, in client coordinates.</para>
        /// <para><see cref="int"/> <paramref name="posY"/>: The new position of the top of the window, in client coordinates.</para>
        /// </remarks>
        /// <param name="posX">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="posY">The new position of the top of the window, in client coordinates.</param>
        public static void PositionConsole(int posX, int posY)
        {
            IntPtr consoleWnd = GetConsoleWindow();
            SetWindowPos(consoleWnd, HWND_TOP, posX, posY, 0, 0, SWP_NOSIZE | SWP_NOZORDER | SWP_SHOWWINDOW);
        }

        /// <summary>
        /// Sets the position of the console window to the center of the screen.
        /// </summary>
        public static void CenterConsole()
        {
            IntPtr hWin = GetConsoleWindow();
            GetWindowRect(hWin, out RECT rc);
            Screen scr = Screen.FromPoint(new Point(rc.Left, rc.Top));
            int x = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.Right - rc.Left)) / 2;
            int y = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.Bottom - rc.Top)) / 2;
            MoveWindow(hWin, x, y, rc.Right - rc.Left, rc.Bottom - rc.Top, false);
        }
    }
}