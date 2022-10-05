using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUI
{
    public class FUIApplication
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private bool AppThreadRunning;
        private FUIWindow window;

        public void BindWindow(FUIWindow window)
        {
            this.window = window;
        }

        public void HideConsole()
        {
            Console.Title = "FUI Application Host";
            IntPtr intptr = FindWindow("ConsoleWindowClass", "FUI Application Host");
            if (intptr != IntPtr.Zero)
                ShowWindow(intptr, 0);
            GC.Collect();
        }
        
        public void Stop()
        {
            AppThreadRunning = false;
            GC.Collect();
            Environment.Exit(0);
        }

        public void RunApp()
        {
            AppThreadRunning = true;
            window.Show();
            System.Windows.Forms.Application.Run();
        }
    }
}
