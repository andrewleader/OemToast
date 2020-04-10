using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Foundation;

namespace XboxToastBackgroundProject.Helpers
{
    public static class SchedulingHelper
    {
        public static IAsyncAction ScheduleTimeTriggerTaskAsync()
        {
            return ScheduleTimeTriggerTaskHelperAsync(60 * 1440).AsAsyncAction();
        }
        public static IAsyncAction ScheduleTimeTriggerTaskAsync(uint minutesFromNow)
        {
            return ScheduleTimeTriggerTaskHelperAsync(minutesFromNow).AsAsyncAction();
        }

        private static async Task ScheduleTimeTriggerTaskHelperAsync(uint minutesFromNow)
        {
            await BackgroundExecutionManager.RequestAccessAsync();

            TimeTrigger timeTrigger = new TimeTrigger(minutesFromNow, oneShot: true);
            var condition = new SystemCondition(SystemConditionType.UserPresent);
            RegisterBackgroundTask("TimeTriggerNotification", timeTrigger, condition);
        }

        //
        // Register a background task with the specified taskEntryPoint, name, trigger,
        // and condition (optional).
        //
        // taskEntryPoint: Task entry point for the background task.
        // taskName: A name for the background task.
        // trigger: The trigger for the background task.
        // condition: Optional parameter. A conditional event that must be true for the task to fire.
        //
        private static BackgroundTaskRegistration RegisterBackgroundTask(string taskName,
                                                                        IBackgroundTrigger trigger,
                                                                        IBackgroundCondition condition)
        {
            //
            // Check for existing registrations of this background task.
            //

            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {

                if (cur.Value.Name == taskName)
                {
                    //
                    // The task is already registered.
                    //

                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }

            //
            // Register the background task.
            //

            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.SetTrigger(trigger);

            if (condition != null)
            {

                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;
        }
    }
}
