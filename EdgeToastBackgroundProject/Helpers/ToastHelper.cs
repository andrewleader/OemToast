using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace EdgeToastBackgroundProject.Helpers
{
    public static class ToastHelper
    {
        /// <summary>
        /// Edge's custom protocol, so that we launch specifically Edge.
        /// </summary>
        private const string ProtocolUrl = "microsoft-edge:";

        public static string GetProtocolUrl()
        {
            return ProtocolUrl;
        }

        public static XmlDocument GenerateEdgeHeroOceanGifContent()
        {
            return new ToastContent()
            {
                Launch = ProtocolUrl,
                ActivationType = ToastActivationType.Protocol,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "It's time to expect more from the web",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "World class performance with more privacy, more productivity, and more value while you browse."
                            }
                        },
                        HeroImage = new ToastGenericHeroImage()
                        {
                            Source = "ms-appx:///Assets/edgehero.gif"
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Try Microsoft Edge", ProtocolUrl)
                        {
                            ActivationType = ToastActivationType.Protocol
                        },
                        new ToastButtonDismiss()
                    }
                }
            }.GetXml();
        }

        public static XmlDocument GenerateEdgeHeroLogoStaticContent()
        {
            return new ToastContent()
            {
                Launch = ProtocolUrl,
                ActivationType = ToastActivationType.Protocol,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "It's time to expect more from the web",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "World class performance with more privacy, more productivity, and more value while you browse."
                            }

                        },
                        HeroImage = new ToastGenericHeroImage()
                        {
                            Source = "ms-appx:///Assets/edgelogo.png"
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Try Microsoft Edge", ProtocolUrl)
                        {
                            ActivationType = ToastActivationType.Protocol
                        },
                        new ToastButtonDismiss()
                    }
                }
            }.GetXml();
        }

        public static XmlDocument GenerateEdgeOceanGifContent()
        {
            return new ToastContent()
            {
                Launch = ProtocolUrl,
                ActivationType = ToastActivationType.Protocol,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "It's time to expect more from the web",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "World class performance with more privacy, more productivity, and more value while you browse."
                            },
                            new AdaptiveImage()
                            {
                                Source = "ms-appx:///Assets/edgehero.gif"
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Try Microsoft Edge", ProtocolUrl)
                        {
                            ActivationType = ToastActivationType.Protocol
                        },
                        new ToastButtonDismiss()
                    }
                }
            }.GetXml();
        }

        public static XmlDocument GenerateEdgeLogoStaticContent()
        {
            return new ToastContent()
            {
                Launch = ProtocolUrl,
                ActivationType = ToastActivationType.Protocol,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "It's time to expect more from the web",
                                HintMaxLines = 1
                            },
                            new AdaptiveText()
                            {
                                Text = "World class performance with more privacy, more productivity, and more value while you browse."
                            },
                            new AdaptiveImage()
                            {
                                Source = "ms-appx:///Assets/edgelogo.png"
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Try Microsoft Edge", ProtocolUrl)
                        {
                            ActivationType = ToastActivationType.Protocol
                        },
                        new ToastButtonDismiss()
                    }
                }
            }.GetXml();
        }

        public static void ShowToast()
        {
            // Create the desired toast visual content
            var content = GenerateEdgeHeroOceanGifContent();

            // Create a notification
            var notif = new ToastNotification(content)
            {
                Tag = "EdgePromotion"
            };

            // And show it
            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }
    }
}
