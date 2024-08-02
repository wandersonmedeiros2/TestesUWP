using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMessageWithConsoleApp.MessageHandlers
{
    internal enum DBT
    {
        DBT_DEVNODES_CHANGED = 0x0007,
        DBT_QUERYCHANGECONFIG = 0x0017,
        DBT_CONFIGCHANGED = 0x0018,
        DBT_CONFIGCHANGECANCELED = 0x0019,
        DBT_DEVICEARRIVAL = 0x8000,
        DBT_DEVICEQUERYREMOVE = 0x8001,
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
        DBT_DEVICEREMOVEPENDING = 0x8003,
        DBT_DEVICEREMOVECOMPLETE = 0x8004,
        DBT_DEVICETYPESPECIFIC = 0x8005,
        DBT_CUSTOMEVENT = 0x8006,
        DBT_USERDEFINED = 0xffff
    }

    public class DeviceChangeListern : WindowsMessgeListernBase
    {
        private IWindowsMessageLoopProvider _loopProvider;

        public DeviceChangeListern(IWindowsMessageLoopProvider provider) {

            WindowsMessageListened = WindowsMessage.WM_DEVICECHANGE;
            _loopProvider = provider;
        }

        public override void Handle(Message message)
        {
            if (!CanExecute(message))
            {
                return;
            }

            ExecuteHandler(message);
        }

        private void ExecuteHandler(Message message)
        {
           Console.WriteLine($"Change dervice: {(DBT) message.WParam}");
            _loopProvider.StopLoop();
        }
    }
}
