using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Base
{
    public class DerviceEventRegisterManager : IDerviceEventRegisterManager
    {
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
            throw new NotImplementedException();
        }

        public void UnregisterListernHandle(nint handle)
        {
            throw new NotImplementedException();
        }
    }
}
