using System;
using System.Runtime.InteropServices;

namespace SessionManagement
{
    internal class APIHelper
    {

        private static readonly uint WM_KEYDOWN = 256u;

        private static readonly uint WM_CHAR = 258u;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void SendString(IntPtr handle, string text)
        {
            foreach (char value in text)
            {
                PostMessage(handle, WM_CHAR, (IntPtr)((int)value), IntPtr.Zero);
            }
            PostMessage(handle, WM_KEYDOWN, (IntPtr)13L, IntPtr.Zero);
        }






        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, int wPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    }
}
