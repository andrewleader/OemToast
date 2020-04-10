# OemToast
OEM toast notification app for Edge and Xbox notification after first boot

## Some key points

* **Disabling the app list entry** - The app shouldn't appear in Start/apps list. To achieve that, in the `Package.appxmanifest`, we set `<uap:VisualElements AppListEntry="none"`.
* **Preinstall task** - In order to run code when the app is first installed (so that we can schedule notifications), we use the preinstall task. That's also specified in the manifest (`preInstalledConfigTask`).
* **Two separate apps** - The only way the app logo and app name of the toast can be configured is the app's manifest, we can't dynamically swap out the app logo/name. Therefore, we need to have a separate app for the Xbox toast so it can have an Xbox icon.
* **Square44x44Logo icon** - The Square44x44Logo in the Assets folder is the logo that's used in the left of the notification. But the `altform-unplated` versions (and lightunplated) are the ones that are actually used.
* **Handling app header in Action Center being clicked** - Users can click the top app header inside Action Center, which will launch the app no matter what. We then handle that app activation and launch Edge. Users will see the app's splash screen and then the app will close after Edge is launched, so not the perfect experience, but it should be a niche case anyone clicks on the header within Action Center.
* **Testing the preinstall task** - The only way to test the task is to have an OEM create an image with the app and set up the computer/VM from scratch.