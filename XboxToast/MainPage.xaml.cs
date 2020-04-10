using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using XboxToastBackgroundProject.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XboxToast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonSchedule15Minutes_Click(object sender, RoutedEventArgs e)
        {
            await SchedulingHelper.ScheduleTimeTriggerTaskAsync(15);

            await new MessageDialog("Scheduled!").ShowAsync();
        }

        private async void ButtonSchedule24Hours_Click(object sender, RoutedEventArgs e)
        {
            await SchedulingHelper.ScheduleTimeTriggerTaskAsync();

            await new MessageDialog("Scheduled!").ShowAsync();
        }
    }
}
