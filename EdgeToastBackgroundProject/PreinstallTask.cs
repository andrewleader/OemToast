using EdgeToastBackgroundProject.Helpers;
using Microsoft.Toolkit.Uwp.Notifications;
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
            try
            {
                ToastHelper.ScheduleNotification();
            }
            catch (Exception ex)
            {
                var errorContent = new ToastContentBuilder().AddText("[Debug] PreinstallTask exception occurred").AddText(ex.ToString(), hintWrap: true).GetToastContent();
                ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(errorContent.GetXml()) { ExpirationTime = DateTime.Now.AddMinutes(5) });
            }

#if VERBOSE
            // When compiled in verbose, show a notification so that we know it ran
            var content = new ToastContentBuilder().AddText("[Debug] PreinstallTask ran").AddText($"Edge toast scheduled for {DateTime.Now.AddMinutes(5).ToShortTimeString()} (5 minutes from now)").GetToastContent();
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()) { ExpirationTime = DateTime.Now.AddMinutes(6) });
#endif
        }
    }
}
