using CommunityToolkit.Maui;
using FreelanceRu.Pages;
using FreelanceRu.Pages.Popup;
using FreelanceRu.ViewModels;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace FreelanceRu
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Montserrat-ExtraLightItalic.ttf", "OpenSansRegular");
                    fonts.AddFont("Montserrat-ExtraLightItalic.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIconsSharp-Regular.otf", "MI");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "IconFontTypes");
                    fonts.AddFont("Montserrat-ExtraLightItalic.ttf", "Mont");
                })
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID
                    events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                    static void MakeStatusBarTranslucent(Android.App.Activity activity)
                    {
                        activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                        activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                        activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                    }
#endif
                });
            builder.UseMaterialComponents();
            builder.UseMauiCommunityToolkit();
            builder.Services.AddSingleton<OrdersPage>();
            builder.Services.AddSingleton<OrdersViewModel>();
            builder.Services.AddSingleton<NewsPage>();
            builder.Services.AddSingleton<NewsViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<ProfileViewModel>();
            builder.Services.AddTransient<ListChatPage>();
            builder.Services.AddTransient<ListChatViewModel>();
            builder.Services.AddTransient<ChatPage>();
            builder.Services.AddTransient<ChatViewModel>();
            builder.Services.AddSingleton<StockPage>();
            builder.Services.AddSingleton<StockViewModel>();
            builder.Services.AddTransient<UserInfoPagePopup>();
            builder.Services.AddTransient<UserInfoCheckPopupViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
