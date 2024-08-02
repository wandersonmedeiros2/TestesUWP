namespace WindowsMessageWithConsoleApp.MessageHandlers
{
    public interface IWindowsMessgeListern
    {
        WindowsMessage WindowsMessageListened { get; }

        bool CanExecute(Message message);
        void Handle(Message message);
    }
}