namespace WinFormsApp1.NativeWin32
{
    public enum DeviceNotificationFlags : int    {
        DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000, //O parâmetro hRecipient é um identificador de janela. 
        DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001, // O parâmetro hRecipient é um identificador de status de serviço.
        DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004 //Notifica o destinatário de eventos de interface do dispositivo para todas as classes de interface do dispositivo. (O membro dbcc_classguid é ignorado.) Esse valor só poderá ser usado se o membro dbch_devicetype for DBT_DEVTYP_DEVICEINTERFACE.
    }
}
