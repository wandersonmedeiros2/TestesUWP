namespace WinFormsApp1.NativeWin32
{
    public enum DbtDeviceType : int
    {
        DBT_DEVTYP_OEM = 0x00000000, //OEM- or IHV-defined device type. This structure is a DEV_BROADCAST_OEM structure.
        DBT_DEVTYP_VOLUME = 0x00000002, //Logical volume. This structure is a DEV_BROADCAST_VOLUME structure.
        DBT_DEVTYP_PORT = 0x00000003, //Port device (serial or parallel). This structure is a DEV_BROADCAST_PORT structure.
        DBT_DEVTYP_DEVICEINTERFACE = 0x00000005, //Class of devices. This structure is a DEV_BROADCAST_DEVICEINTERFACE structure.
        DBT_DEVTYP_HANDLE = 0x00000006 //File system handle. This structure is a DEV_BROADCAST_HANDLE structure.
    }
}
