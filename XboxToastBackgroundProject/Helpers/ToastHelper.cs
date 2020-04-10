using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace XboxToastBackgroundProject.Helpers
{
    public static class ToastHelper
    {
        /// <summary>
        /// Idk what the Xbox protocol is for the game pass? Someone needs to fill this in
        /// </summary>
        private const string ProtocolUrl = "xbox:";

        public static void ShowToast()
        {
            var content = new ToastContent()
            {
                Launch = ProtocolUrl,
                ActivationType = ToastActivationType.Protocol,
                Scenario = ToastScenario.Reminder,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Xbox Game Pass",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "Get the game pass!"
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Try Game Pass", ProtocolUrl)
                        {
                            ActivationType = ToastActivationType.Protocol
                        },
                        new ToastButtonDismiss()
                    }
                }
            };

            var notif = new ToastNotification(content.GetXml());

            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }
    }
}
