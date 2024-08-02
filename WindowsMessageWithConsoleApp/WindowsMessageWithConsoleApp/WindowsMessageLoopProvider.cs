using System.ComponentModel;
using System.Windows.Interop;
using WindowsMessageWithConsoleApp.MessageHandlers;

namespace WindowsMessageWithConsoleApp
{
    public class WindowsMessageLoopProvider : Form, IWindowsMessageLoopProvider
    {
        private Dictionary<WindowsMessage, IWindowsMessgeListern> _listerns;
        private Thread _thread;
        private bool _continueLoop;
        private object objectLock = new object();

        public WindowsMessageLoopProvider()
        {
            _listerns = new Dictionary<WindowsMessage, IWindowsMessgeListern>();
            _thread = new Thread(ExecuteMessageLoop);
            _continueLoop = true;
            Visible = false;
            SuspendLayout();
            ResumeLayout(false);
        }

        public void Register(IWindowsMessgeListern listern)
        {
            if (listern == null)
            {
                return;
            }

            if ((listern.WindowsMessageListened == WindowsMessage.WM_NULL))
            {
                throw new InvalidEnumArgumentException("WindowsMessageListened não foi configurado");
            }

            if (!_listerns.ContainsKey(listern.WindowsMessageListened))
            {
                _listerns[listern.WindowsMessageListened] = listern;
            }
        }

        public void Unregister(WindowsMessage windowsMessage)
        {
            if (_listerns.ContainsKey(windowsMessage))
            {
                _listerns.Remove(windowsMessage);
            }
        }

        private void Execute(Message message)
        {
            WindowsMessage windowsMessage = (WindowsMessage)message.Msg;
            if (_listerns.TryGetValue(windowsMessage, out IWindowsMessgeListern? listern))
            {
                listern.Handle(message);
            }
        }

        protected override void WndProc(ref Message m)
        {
            Execute(m);

            base.WndProc(ref m);
        }

        public void StartLoop()
        {
            _thread.Start();
        }

        public void StartLoopAndWait()
        {
            _thread.Start();
            _thread.Join();
        }

        private void ExecuteMessageLoop()
        {
            ChangeLoopState(true);
            MSG msg = default;
            nint handle = Handle;
            while (_continueLoop)
            {
                NativeApi.GetMessage(out msg, Handle, 0, 0);
            }

        }

        public void StopLoop()
        {
            ChangeLoopState(false);
            _thread.Join();
        }

        private void ChangeLoopState(bool value)
        {
            lock (objectLock)
            {
                _continueLoop = value;
            }
        }
    }
}
