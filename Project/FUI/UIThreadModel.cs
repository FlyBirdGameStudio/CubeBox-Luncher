using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FUI
{
    public abstract class UIThreadModel
    {
        private readonly Thread thread;

        public UIThreadModel()
        {
            thread = new Thread(OnAction);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Name = "UIThread";
        }

        public void Start()
        {
            thread.Start();
            GC.Collect();
        }

        public void Stop()
        {
            thread.Join();
            thread.Interrupt();
            GC.Collect();
        }

        public abstract void OnAction();
    }
}
