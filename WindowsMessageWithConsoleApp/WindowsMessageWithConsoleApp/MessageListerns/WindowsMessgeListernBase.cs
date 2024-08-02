using System.ComponentModel;

namespace WindowsMessageWithConsoleApp.MessageHandlers
{
    public abstract class WindowsMessgeListernBase : IWindowsMessgeListern
    {
        public WindowsMessage WindowsMessageListened { get; protected set; }

        public WindowsMessgeListernBase()
        {
            WindowsMessageListened = WindowsMessage.WM_NULL;
        }

        public virtual bool CanExecute(Message message)
        {
            return ((WindowsMessage)message.Msg) == WindowsMessageListened;
        }

        public abstract void Handle(Message message);        
    }
}
