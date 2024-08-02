// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Windows.Interop;
using WindowsMessageWithConsoleApp.MessageHandlers;

namespace WindowsMessageWithConsoleApp
{
    public class Program
    {
        public static WindowsMessageLoopProvider s_windowsMessageLoopProvider = new WindowsMessageLoopProvider();        

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");            
            s_windowsMessageLoopProvider.Register(new DeviceChangeListern(s_windowsMessageLoopProvider));            
            s_windowsMessageLoopProvider.StartLoopAndWait();
            s_windowsMessageLoopProvider.StartLoop();
            return;
        }        
    }
}
