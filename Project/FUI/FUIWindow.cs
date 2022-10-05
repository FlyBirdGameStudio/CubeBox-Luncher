using FUI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;

namespace FUI
{
    public abstract class FUIWindow : UIThreadModel
    {
        private readonly Window window;
        private readonly FUIWindowBase ui;

        public FUIWindow()
        {
            window = new Window()
            {
                WindowStyle = WindowStyle.None
            };
            ui = new FUIWindowBase();
            
            window.Content = ui;
            window.Closed += (s, e) => OnClosed();

            WindowChrome chrome = new WindowChrome()
            {
                GlassFrameThickness = new Thickness(-1)
            };
            WindowChrome.SetWindowChrome(window, chrome);

            GC.Collect();
        }

        public FUIWindow(Window window)
        {
            this.window = window;
        }

        public override void OnAction()
        {
            window.Dispatcher.Invoke(() =>
            {
                window.ShowDialog();
            });
        }

        public abstract void OnClosed();

        public void Show()
        {
            Start();
        }
    }
}
