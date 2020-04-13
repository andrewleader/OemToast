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
            // It usually takes around 5-15 minutes for the task to run (and often runs closer to 15 minutes).

            // Show the notification
            try
            {
                ToastHelper.ShowToast();
            }
            catch (Exception ex)
            {
                var errorContent = new ToastContentBuilder().AddText("[Debug] PreinstallTask exception occurred").AddText(ex.ToString(), hintWrap: true).GetToastContent();
                ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(errorContent.GetXml()) { ExpirationTime = DateTime.Now.AddMinutes(5) });
            }
        }
    }
}
