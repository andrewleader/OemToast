using EdgeToastBackgroundProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace EdgeToastBackgroundProject
{
    public sealed class PreinstallTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // This task will only run once, after OOBE is completed and user is logged into the desktop.

            // Schedule the notification to be shown later (in 5 minutes).
            ToastHelper.ScheduleNotification();
        }
    }
}
