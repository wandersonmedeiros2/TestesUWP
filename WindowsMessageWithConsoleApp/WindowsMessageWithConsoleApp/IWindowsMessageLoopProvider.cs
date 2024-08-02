using WindowsMessageWithConsoleApp.MessageHandlers;

namespace WindowsMessageWithConsoleApp
{
    public interface IWindowsMessageLoopProvider
    {
        void Register(IWindowsMessgeListern listern);
        void StartLoop();
        void StopLoop();
        void Unregister(WindowsMessage windowsMessage);
    }
}