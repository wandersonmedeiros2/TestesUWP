using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using WinFormsApp1.NativeWin32;

namespace WinFormsApp1.Base
{
    public class DerviceEventRegisterManager : IDerviceEventRegisterManager
    {
        private const ulong CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES = 0x00000001;
        private const int CR_SUCCESS = 0x00000000;
        private Dictionary<nint, nint> _Handles = new Dictionary<nint, nint>();

        public void RegisterListernHandle(nint handle, Guid deviceInterfaceGuid)
        {            
            string devicePath = GetDevicePathByGuid(deviceInterfaceGuid);
            nint handleDevice = GetHandleDevice(devicePath);

            RegisterNotification(handle, handleDevice);
        }

        private void RegisterNotification(nint handle, nint handleDevice)
        {
            throw new NotImplementedException();
        }

        private nint GetHandleDevice(string devicePath)
        {
            throw new NotImplementedException();
        }

        private string GetDevicePathByGuid(Guid deviceInterfaceGuid)
        {
            string deviceDrivePath = string.Empty;
            int deviceInterfaceListLength = 0;
                                                                 
            IntPtr result = NativeApi.CM_Get_Device_Interface_List_Size(out deviceInterfaceListLength, deviceInterfaceGuid, null, CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES);

            if (result != CR_SUCCESS)
            {
                throw new Exception($"Erro ao recuperar o tamanho do path do drive da inteface {deviceInterfaceGuid}");
            }

            result = 0;

            char[] deviceInterfaceListBuffer = new char[deviceInterfaceListLength];
            result = NativeApi.CM_Get_Device_Interface_List(deviceInterfaceGuid, null, deviceInterfaceListBuffer, deviceInterfaceListLength, CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES);

            if (result != CR_SUCCESS)
            {
                throw new Exception($"Erro ao recuperar o path do drive da inteface {deviceInterfaceGuid.ToString()}");
            }

            deviceDrivePath = new string(deviceInterfaceListBuffer);

            Debug.WriteLine(deviceDrivePath);

            return deviceDrivePath;
        }

        public void UnregisterListernHandle(nint handle)
        {
            throw new NotImplementedException();
        }
    }
}

