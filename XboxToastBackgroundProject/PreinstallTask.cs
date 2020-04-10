﻿using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using XboxToastBackgroundProject.Helpers;

namespace XboxToastBackgroundProject
{
    public sealed class PreinstallTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // This task will only run once, after OOBE is completed and user is logged into the desktop.

            // Schedule the TimeTrigger task
            var deferral = taskInstance.GetDeferral();

#if DEBUG
            // When in debug, schedule for 5 minutes so we can see it work sooner
            await SchedulingHelper.ScheduleTimeTriggerTaskAsync(5);

            // Also show a debug notification so that we know it ran
            var content = new ToastContentBuilder().AddText("[Debug] PreinstallTask ran").AddText("Xbox toast scheduled for 5 minutes from now").GetToastContent();
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()) { ExpirationTime = DateTime.Now.AddMinutes(1) });
#else
            // Otherwise it gets scheduled for 24 hours from now
            await SchedulingHelper.ScheduleTimeTriggerTaskAsync();
#endif

            deferral.Complete();
        }
    }
}
