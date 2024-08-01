// See https://aka.ms/new-console-template for more information

using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace NamedPipeWithUWP.AppServer
{
    public class Program
    {
        private static string PIPE_NAME = @"\.\pipe\PipeTeste";
        private static int PIPE_BUFFER_SIZE = 65535;

        static void Main(string[] args)
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            Console.WriteLine("Hello World!");


            SecurityIdentifier securityPackagedApps = new SecurityIdentifier(WellKnownSidType.WinBuiltinAnyPackageSid, null); //allow UWP connect
            SecurityIdentifier securityOthers= new SecurityIdentifier(WellKnownSidType.WorldSid, null);

            PipeAccessRights pipePermissions = PipeAccessRights.Read | PipeAccessRights.CreateNewInstance | PipeAccessRights.Write | PipeAccessRights.FullControl;

            PipeSecurity pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(new PipeAccessRule(securityOthers, pipePermissions,  AccessControlType.Allow));
            pipeSecurity.AddAccessRule(new PipeAccessRule(securityPackagedApps, pipePermissions, AccessControlType.Allow));


            Console.WriteLine("Creating NamedPipe...");
            NamedPipeServerStream pipeServer = NamedPipeServerStreamAcl.Create(PIPE_NAME, PipeDirection.InOut, 10, PipeTransmissionMode.Byte,PipeOptions.None, PIPE_BUFFER_SIZE, PIPE_BUFFER_SIZE, pipeSecurity);
            Console.WriteLine("Waiting conneciton...");

            pipeServer.WaitForConnection();

            /*Memory<byte> message = new Memory<byte>();
            Span<byte> byteMessage = message.Span;*/

            byte[] message = new byte[PIPE_BUFFER_SIZE];
            pipeServer.Read(message);

            Console.WriteLine($"Received: {Encoding.ASCII.GetString(message)}");

        }        
    }
}