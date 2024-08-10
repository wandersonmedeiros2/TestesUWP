namespace WinFormsApp1.Base
{
    public interface IDerviceEventRegisterManager
    {
        void RegisterListernHandle(nint handle, Guid deviceInterfaceGuid);
        void UnregisterListernHandle(nint handle);
    }
}