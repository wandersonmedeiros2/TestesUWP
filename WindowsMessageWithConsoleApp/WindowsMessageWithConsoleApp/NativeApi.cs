using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace WindowsMessageWithConsoleApp
{
    //https://learn.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.dllimportattribute?view=net-8.0
    //https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessage

    public static class NativeApi
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, EntryPoint = "GetMessage")]
        public extern static int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
    }
}
