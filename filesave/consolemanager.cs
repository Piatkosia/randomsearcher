using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Tools
{
    public class consolemanager
    {
        static Nullable<bool> state = null;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        public static bool showconsole (){
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
            state = true;
            return true;
        }
        public static bool hideconsole (){
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            state = false;
            return false;
        }

    }
    
}
