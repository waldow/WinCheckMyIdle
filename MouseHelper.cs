using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinCheckMyIdle
{
    public class MouseHelper
    {
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public uint X;
            public uint Y;


        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);


        public static void MoveMouse()
        {
            //  Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            lpPoint.X = lpPoint.X + 1;
            lpPoint.Y = lpPoint.Y + 1;
            mouse_event(MOUSEEVENTF_MOVE, 1, 1, 0, 0);
        }
    }

    internal static partial class NativeMethods
    {



    }
}