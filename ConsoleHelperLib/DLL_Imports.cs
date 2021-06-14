using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace ConsoleHelperLib.pInvoke
{
    public static class DLL_Imports
    {
        #region kernel32.dll

        /// <summary>
        /// Writes character and color attribute data to a specified rectangular block of character cells 
        /// in a console screen buffer. The data to be written is taken from a correspondingly sized rectangular 
        /// block at a specified location in the source buffer.
        /// </summary>
        /// <param name="hConsoleOutput">A handle to the console screen buffer. The handle must have the <b>GENERIC_WRITE</b> access right. For more information, see <a href="https://docs.microsoft.com/en-us/windows/console/console-buffer-security-and-access-rights">Console Buffer Security and Access Rights</a>.</param>
        /// <param name="lpBuffer">The data to be written to the console screen buffer. This pointer is treated as the origin of a two-dimensional array of <see cref="CHAR_INFO"/> structures whose size is specified by the dwBufferSize parameter.</param>
        /// <param name="dwBufferSize">The size of the buffer pointed to by the lpBuffer parameter, in character cells. The X member of the <see cref="COORD"/> structure is the number of columns; the Y member is the number of rows.</param>
        /// <param name="dwBufferCoord"></param>
        /// <param name="lpWriteRegion"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
            SafeFileHandle hConsoleOutput,
            CHAR_INFO[] lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpWriteRegion
        );

        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <remarks>Remarks: 
        /// <para>To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. 
        /// For more information, see Using the <a href="https://docs.microsoft.com/en-us/windows/win32/winprog/using-the-windows-headers">Windows Headers</a>.</para>
        /// <para>For an application that is hosted inside a pseudoconsole session, this function returns a window handle for message queue purposes only. 
        /// The associated window is not displayed locally as the pseudoconsole is serializing all actions to a stream for presentation on another 
        /// terminal window elsewhere.</para>
        /// </remarks>
        /// <returns>
        /// The return value is a handle to the window used by the console associated with the
        /// calling process or <c>NULL</c> if there is no such associated console.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "GetConsoleWindow")]
        public static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Retrieves the calling thread's last-error code value. 
        /// The last-error code is maintained on a per-thread basis. 
        /// Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <remarks>
        /// Calling GetLastError directly via PInvoke is not guaranteed to work due to the CLR's 
        /// internal interaction with the operating system. Instead, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </remarks>
        /// <returns>The return value is the calling thread's last-error code.</returns>
        [Obsolete("Calling GetLastError directly via PInvoke is not guaranteed to work due to the CLR's internal interaction with the operating system. Instead, call Marshal.GetLastWin32Error.", true)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetLastError();
        #endregion

        #region user32.dll

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// <para><see cref="IntPtr"/> <paramref name="hWnd"/>: A handle to the window.</para>
        /// <para><see cref="RECT"/> <paramref name="rc"/>: A pointer to a <seealso cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</para>
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="hWnd">A handle to the window.</param>  
        /// <param name="rc">A pointer to a <seealso cref="RECT"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>: 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError()"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "GetWindowRect")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// These windows are ordered according to their appearance on the screen. 
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// <para><see cref="IntPtr"/> <paramref name="hWnd"/>: A handle to the window.                                                                                                                                  </para>   
        /// <para><see cref="IntPtr"/> <paramref name="hWndInsertAfter"/>: A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values.</para>
        /// <para><see cref="int"/> <paramref name="X"/>: The new position of the left side of the window, in client coordinates.                                                                                     </para>
        /// <para><see cref="int"/> <paramref name="Y"/>: The new position of the top of the window, in client coordinates.                                                                                           </para>
        /// <para><see cref="int"/> <paramref name="cx"/>: The new width of the window, in pixels.                                                                                                                    </para>
        /// <para><see cref="int"/> <paramref name="cy"/>: The new height of the window, in pixels.                                                                                                                   </para>
        /// <para><see cref="uint"/> <paramref name="uFlags"/>: The window sizing and positioning flags.                                                                                                               </para>
        /// </summary>
        /// <remarks>
        /// <para>Remarks:</para>
        /// <para>As part of the Vista re-architecture, all services were moved off the interactive desktop into Session 0. hwnd and window manager operations are only effective inside a session and cross-session attempts to manipulate the hwnd will fail. For more information, see The Windows Vista Developer Story: Application Compatibility Cookbook.                                               </para>
        /// <para>If you have changed certain window data using SetWindowLong, you must call SetWindowPos for the changes to take effect.Use the following combination for uFlags: SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED.                                                                                                                                                                  </para>
        /// <para>A window can be made a topmost window either by setting the hWndInsertAfter parameter to HWND_TOPMOST and ensuring that the SWP_NOZORDER flag is not set, or by setting a window's position in the Z order so that it is above any existing topmost windows. When a non-topmost window is made topmost, its owned windows are also made topmost. Its owners, however, are not changed.       </para>
        /// <para>If neither the SWP_NOACTIVATE nor SWP_NOZORDER flag is specified(that is, when the application requests that a window be simultaneously activated and its position in the Z order changed), the value specified in hWndInsertAfter is used only in the following circumstances.                                                                                                              </para>
        ///<list type="bullet">
        ///     <item>Neither the HWND_TOPMOST nor HWND_NOTOPMOST flag is specified in hWndInsertAfter. </item>
        ///     <item>The window identified by hWnd is not the active window. </item>
        ///     </list>
        /// <para>An application cannot activate an inactive window without also bringing it to the top of the Z order.Applications can change an activated window's position in the Z order without restrictions, or it can activate a window and then move it to the top of the topmost or non-topmost windows.                                                                                              </para>
        /// <para>If a topmost window is repositioned to the bottom (HWND_BOTTOM) of the Z order or after any non-topmost window, it is no longer topmost.When a topmost window is made non-topmost, its owners and its owned windows are also made non-topmost windows.                                                                                                                                       </para>
        /// <para>A non-topmost window can own a topmost window, but the reverse cannot occur.Any window (for example, a dialog box) owned by a topmost window is itself made a topmost window, to ensure that all owned windows stay above their owner.                                                                                                                                                       </para>
        /// <para>If an application is not in the foreground, and should be in the foreground, it must call the SetForegroundWindow function.                                                                                                                                                                                                                                                                  </para>
        /// <para>To use SetWindowPos to bring a window to the top, the process that owns the window must have SetForegroundWindow permission.</para>
        /// </remarks>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values.</param>
        /// <param name="X">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="Y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError()"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary>
        /// Changes the position and dimensions of the specified window. For a top-level window, 
        /// the position and dimensions are relative to the upper-left corner of the screen. 
        /// For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// <para><see cref="IntPtr"/> <paramref name="hWnd"/>: A handle to the window. </para>
        /// <para><see cref="int"/> <paramref name="X"/>: The new position of the left side of the window. </para>
        /// <para><see cref="int"/> <paramref name="Y"/>: The new position of the top of the window. </para>
        /// <para><see cref="int"/> <paramref name="nWidth"/>: The new width of the window. </para>
        /// <para><see cref="int"/> <paramref name="nHeight"/>: The new height of the window. </para>
        /// <para><see cref="bool"/> <paramref name="bRepaint"/>: Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window. </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Remarks:
        /// </para>
        /// <para>
        ///  If the bRepaint parameter is TRUE, the system sends the WM_PAINT message to the window procedure immediately 
        /// after moving the window (that is, the MoveWindow function calls the UpdateWindow function). If bRepaint is 
        /// FALSE, the application must explicitly invalidate or redraw any parts of the window and parent window that 
        /// need redrawing.
        /// </para>
        /// <para>
        /// MoveWindow sends the WM_WINDOWPOSCHANGING, WM_WINDOWPOSCHANGED, WM_MOVE, WM_SIZE, and WM_NCCALCSIZE messages 
        /// to the window.
        /// </para>
        /// </remarks>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="X">The new position of the left side of the window.</param>
        /// <param name="Y">The new position of the top of the window.</param>
        /// <param name="nWidth">The new width of the window.</param>
        /// <param name="nHeight">The new height of the window.</param>
        /// <param name="bRepaint">Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, 
        /// call <see cref="GetLastError()"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        #endregion

    }
}
