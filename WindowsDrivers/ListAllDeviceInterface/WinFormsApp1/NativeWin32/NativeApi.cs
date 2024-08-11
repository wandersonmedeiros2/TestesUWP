using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace WinFormsApp1.NativeWin32
{
    public static class NativeApi
    {
        
        [DllImport("Cfgmgr32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "CM_Get_Device_Interface_List_Size")]
        public static extern IntPtr CM_Get_Device_Interface_List_Size(out int pulLen, Guid InterfaceClassGuid, string pDeviceID, ulong ulFlags);

        [DllImport("Cfgmgr32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "CM_Get_Device_Interface_List")]
        public static extern IntPtr CM_Get_Device_Interface_List(Guid InterfaceClassGuid, string pDeviceID, char[] Buffer, int BufferLen, ulong ulFlags);

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "RegisterDeviceNotification")]
        public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, int Flags);

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "RegisterDeviceNotification")]
        public static extern IntPtr UnregisterDeviceNotification(IntPtr Handle);

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "CreateFile")]
        public static extern int CreateFile(string lpFileName, long dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes,  int dwCreationDisposition,  int dwFlagsAndAttributes,  IntPtr hTemplateFile);

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "CreateFile")]
        public static extern int CloseHandle(IntPtr hObject);

    }
}
