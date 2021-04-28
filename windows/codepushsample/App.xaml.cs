using Microsoft.ReactNative;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace codepushsample
{
    sealed partial class App : ReactApplication
    {
        public App()
        {
#if BUNDLE
            JavaScriptBundleFile = "index.windows";
            InstanceSettings.UseWebDebugger = false;
            InstanceSettings.UseFastRefresh = false;
#else
            JavaScriptBundleFile = "index";
            InstanceSettings.UseWebDebugger = true;
            InstanceSettings.UseFastRefresh = true;
#endif

#if DEBUG
            InstanceSettings.UseDeveloperSupport = true;
#else
            InstanceSettings.UseDeveloperSupport = false;
#endif

            Microsoft.ReactNative.Managed.AutolinkedNativeModules.RegisterAutolinkedNativeModulePackages(PackageProviders); // Includes any autolinked modules

            PackageProviders.Add(new Microsoft.ReactNative.Managed.ReactPackageProvider());
            PackageProviders.Add(new ReactPackageProvider());

            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Microsoft.CodePush.ReactNative.CodePushConfig.SetHost(Host);
            Dictionary<string, string> configMap = new Dictionary<string, string>();
            configMap.Add("appVersion", "1.0.0");
            configMap.Add("deploymentKey", "pW0cceCk7YtRT3zdhnuJpMnQWwGZorxbfEwOr");
            Microsoft.CodePush.ReactNative.CodePushConfig.Init(configMap);

            Frame rootFrame = null;

            var content = Window.Current.Content;
            if (content != null)
            {
                rootFrame = content as Frame;
            }

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                if (!e.PrelaunchActivated)
                {
                    if (rootFrame.Content == null)
                    {
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }

                    Window.Current.Content = rootFrame;
                    Window.Current.Activate();
                }
            }
            else
            {
                if (!e.PrelaunchActivated)
                {
                    if (rootFrame.Content == null)
                    {
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    }

                    Window.Current.Activate();
                }
            }
        }
    }
}
