using System;
using System.IO.Pipes;
using System.Text;

namespace NamedPipeWithUWP.NetFrameworkClient
{
    internal class Program
    {
        private static string PIPE_NAME = @"\pipe\PipeTeste";        
        private static NamedPipeClientStream _clientPipe;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Type the message: ");
                string strMessage = Console.ReadLine();

                _clientPipe = new NamedPipeClientStream(".", PIPE_NAME, PipeDirection.InOut);
                if (!_clientPipe.IsConnected)
                {
                    _clientPipe.Connect(3000);
                }

                if (!string.IsNullOrWhiteSpace(strMessage))
                {
                    byte[] message = Encoding.ASCII.GetBytes(strMessage.Trim());
                    _clientPipe.Write(message, 0, message.Length);
                    _clientPipe.WaitForPipeDrain();
                    Console.Write("Message sent");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
