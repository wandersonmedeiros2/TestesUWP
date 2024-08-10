using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.NativeWin32
{
    //https://learn.microsoft.com/pt-br/windows/win32/api/dbt/ns-dbt-dev_broadcast_handle
    //https://learn.microsoft.com/pt-br/windows/win32/devio/device-events

    [StructLayout (LayoutKind.Sequential)]
    public class DevBroadcastHandle
    {
        int dbch_size;
        int dbch_devicetype;
        int dbch_reserved;
        IntPtr dbch_handle;
        IntPtr dbch_hdevnotify;
        Guid dbch_eventguid;
        long dbch_nameoffset;
        int dbch_data;
    }
}
