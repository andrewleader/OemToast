using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using XboxToastBackgroundProject.Helpers;

namespace XboxToastBackgroundProject
{
    public sealed class PreinstallTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // This task will only run once, after OOBE is completed and user is logged into the desktop.

            // Schedule the TimeTrigger 24 hours from now
            var deferral = taskInstance.GetDeferral();
            await SchedulingHelper.ScheduleTimeTriggerTaskAsync();
            deferral.Complete();
        }
    }
}
