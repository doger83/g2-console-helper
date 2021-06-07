using System;
using System.ComponentModel;
using System.Drawing;           // NOTE: Project + Add Reference required
using System.Windows.Forms;     // NOTE: Project + Add Reference required
using System.Runtime.InteropServices;
using ConsoleHelperLib;

namespace ConsoleHelperLib
{
    public static partial class ConsoleUtils
    {
        // P/Invoke declarations
        private struct RECT { public int left, top, right, bottom; }
        //[DllImport("kernel32.dll", SetLastError = true)]
        //private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);



        //var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
        //Imports.SetWindowPos(consoleWnd, 0, centerLeft, centerTop, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
        //System.Console.ReadLine();

        //private static readonly IntPtr HWND_BOTTOM = (IntPtr)1;
        //private static readonly IntPtr HWND_NOTOPMOST = (IntPtr)(-2);
        //private static readonly IntPtr HWND_TOP = (IntPtr)0;
        //private static readonly IntPtr HWND_TOPMOST = (IntPtr)(-1);

        public static uint SWP_NOSIZE = 1;
        public static uint SWP_NOZORDER = 4;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);

        /// <summary>
        /// Sets the position of the console window relative to the upper-left corner of the screen at the given input.
        /// </summary>
        /// <remarks>
        /// <para><paramref name="posX"/>: The new position of the left side of the window, in client coordinates.</para>
        /// <para><paramref name="posY"/>: The new position of the top of the window, in client coordinates.</para>
        /// </remarks>
        /// <param name="posX">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="posY">The new position of the top of the window, in client coordinates.</param>
        public static void PositionConsole(int posX, int posY)
        {
            IntPtr consoleWnd = GetConsoleWindow();
            SetWindowPos(consoleWnd, 0, posX, posY, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
        }

        /// <summary>
        /// Sets the position of the console window center in the middle of the screen
        /// </summary>
        public static void CenterConsole()
        {

            IntPtr hWin = GetConsoleWindow();
            GetWindowRect(hWin, out RECT rc);
            Screen scr = Screen.FromPoint(new Point(rc.left, rc.top));
            int x = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.right - rc.left)) / 2;
            int y = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.bottom - rc.top)) / 2;
            MoveWindow(hWin, x, y, rc.right - rc.left, rc.bottom - rc.top, false);
        }

    }
}