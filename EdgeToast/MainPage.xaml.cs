using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using EdgeToastBackgroundProject.Helpers;
using Windows.Data.Xml.Dom;
using Windows.UI.Popups;
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EdgeToast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(300, 300);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

#if DEBUG
            // When in debug we add the session connected test, so we can test behavior when user logs in, rather than having to test installing the OS image from scratch.
            RegisterDebugSessionConnectedTask();
#endif
        }

#if DEBUG
        private void RegisterDebugSessionConnectedTask()
        {
            // This task runs every time the user logs in, which then invokes the same code as the preinstall task would. Used only for testing purposes.
            var trigger = new SystemTrigger(SystemTriggerType.SessionConnected, oneShot: false);
            BackgroundTasksHelper.RegisterBackgroundTask("EdgeToastBackgroundProject.PreinstallTask", "SessionConnectedTask", trigger, null);
        }
#endif

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var toastContent = ToastHelper.GenerateEdgeHeroOceanGifContent();

            ShowToast(toastContent);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var toastContent = ToastHelper.GenerateEdgeHeroLogoStaticContent();

            ShowToast(toastContent);
        }


        private void Button_Std_Click(object sender, RoutedEventArgs e)
        {
            var toastContent = ToastHelper.GenerateEdgeOceanGifContent();

            ShowToast(toastContent);
        }

        private void Button_Std_Click_1(object sender, RoutedEventArgs e)
        {
            var toastContent = ToastHelper.GenerateEdgeLogoStaticContent();

            ShowToast(toastContent);
        }

        private void ShowToast(XmlDocument content)
        {
            // Create the toast notification
            var toastNotif = new ToastNotification(content);

            // And send the notification
            ToastNotificationManager.CreateToastNotifier().Show(toastNotif);
        }

        private void SimulatePreinstall_Click(object sender, RoutedEventArgs e)
        {
            ToastHelper.ShowToast();
        }
    }
}
