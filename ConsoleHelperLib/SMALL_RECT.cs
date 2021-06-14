using System.Runtime.InteropServices;

namespace ConsoleHelperLib.pInvoke
{
    /// <summary>
    /// Defines the coordinates of the upper left and lower right corners of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SMALL_RECT
    {
        /// <summary>
        /// The x-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Left;

        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Top;

        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Right;

        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Bottom;

        /// <summary>
        /// Constructor of the struct.
        /// </summary>
        /// <param name="Left">The x-coordinate of the upper left corner of the rectangle.</param>
        /// <param name="Right">The x-coordinate of the lower right corner of the rectangle.</param>
        /// <param name="Top">The y-coordinate of the upper left corner of the rectangle.</param>
        /// <param name="Bottom">The y-coordinate of the lower right corner of the rectangle.</param>
        public SMALL_RECT(short Left, short Top, short Right, short Bottom)
        {
            this.Left = Left;
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
        }
    }
}