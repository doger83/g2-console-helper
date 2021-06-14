using System;

namespace ConsoleHelperLib.pInvoke
{
    public static class Constants
    {
        #region SetWindowPos() hWndInsertAfter values

        /// <summary>
        /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, 
        /// the window loses its topmost status and is placed at the bottom of all other windows. 
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). 
        /// This flag has no effect if the window is already a non-topmost window. 
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>
        /// Places the window at the top of the Z order. 
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>
        /// Places the window above all non-topmost windows. 
        /// The window maintains its topmost position even when it is deactivated. 
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        #endregion

        #region SetWindowPos() uFlags

        /// <summary>
        ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
        /// </summary>
        public static readonly uint SWP_ASYNCWINDOWPOS = 0x4000;

        /// <summary>
        ///     Prevents generation of the WM_SYNCPAINT message.
        /// </summary>
        public static readonly uint SWP_DEFERERASE = 0x2000;

        /// <summary>
        ///     Draws a frame (defined in the window's class description) around the window.
        /// </summary>
        public static readonly uint SWP_DRAWFRAME = 0x0020;

        /// <summary>
        ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
        /// </summary>
        public static readonly uint SWP_FRAMECHANGED = 0x0020;

        /// <summary>
        ///     Hides the window.
        /// </summary>
        public static readonly uint SWP_HIDEWINDOW = 0x0080;

        /// <summary>
        ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
        /// </summary>
        public static readonly uint SWP_NOACTIVATE = 0x0010;

        /// <summary>
        ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
        /// </summary>
        public static readonly uint SWP_NOCOPYBITS = 0x0100;

        /// <summary>
        ///     Retains the current position (ignores X and Y parameters).
        /// </summary>
        public static readonly uint SWP_NOMOVE = 0x0002;

        /// <summary>
        ///     Does not change the owner window's position in the Z order.
        /// </summary>
        public static readonly uint SWP_NOOWNERZORDER = 0x0200;

        /// <summary>
        ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </summary>
        public static readonly uint SWP_NOREDRAW = 0x0008;

        /// <summary>
        ///     Same as the SWP_NOOWNERZORDER flag.
        /// </summary>
        public static readonly uint SWP_NOREPOSITION = 0x0200;

        /// <summary>
        ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
        /// </summary>
        public static readonly uint SWP_NOSENDCHANGING = 0x0400;

        /// <summary>
        ///     Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        public static readonly uint SWP_NOSIZE = 0x0001;

        /// <summary>
        ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
        /// </summary>
        public static readonly uint SWP_NOZORDER = 0x0004;

        /// <summary>
        ///     Displays the window.
        /// </summary>
        public static readonly uint SWP_SHOWWINDOW = 0x0040;
        #endregion
    }
}
