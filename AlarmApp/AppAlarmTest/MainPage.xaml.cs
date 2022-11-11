using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppAlarmTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ToastNotifier _toastNotifier =  ToastNotificationManager.CreateToastNotifier();
        private string _toastID;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var toast = new ToastContentBuilder()
                             .AddText("Sample Toast App")
                             .AddText("The is a sample message.")
                             .SetToastDuration(ToastDuration.Long);

            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toast.GetXml(), DateTime.Now.AddMinutes(1));
            _toastID = scheduledToast.Id;
            _toastNotifier.AddToSchedule(scheduledToast);            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<ScheduledToastNotification> scheduled = _toastNotifier.GetScheduledToastNotifications();

            foreach (var t in scheduled)
            {
                if (t.Id.Equals( _toastID))
                {
                    _toastNotifier.RemoveFromSchedule(t);
                }
            }

        }
    }
}
