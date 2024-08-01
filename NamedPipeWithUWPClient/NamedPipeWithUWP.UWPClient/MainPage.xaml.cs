using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NamedPipeWithUWP.UWPClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string PIPE_NAME = @"\pipe\PipeTeste";
        private static int PIPE_BUFFER_SIZE = 65535;
        private NamedPipeClientStream _clientPipe;

        public MainPage()
        {
            this.InitializeComponent();
            _clientPipe = new NamedPipeClientStream(".", PIPE_NAME, PipeDirection.InOut);
        }

        private void BtSend_click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!_clientPipe.IsConnected)
                {
                    _clientPipe.Connect(3000);                    
                }

                string strMessage = tbMessage.Text;
                if (!string.IsNullOrWhiteSpace(strMessage))
                {
                    byte[] message = Encoding.ASCII.GetBytes(strMessage.Trim());
                    _clientPipe.Write(message, 0, message.Length);
                    _clientPipe.WaitForPipeDrain();
                }
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync().AsTask().Wait();                
            }
        }
    }
}
