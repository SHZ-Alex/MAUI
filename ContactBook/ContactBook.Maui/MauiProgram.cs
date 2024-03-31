using CommunityToolkit.Maui;
using ContactBook.DataProvider.Repository;
using ContactBook.Maui.ViewModels;
using ContactBook.Maui.Views;
using Contacts.BLL.BLL.ViewContactBll;
using Contacts.BLL.Repository;
using Microsoft.Extensions.Logging;

namespace ContactBook.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<IViewContactBll, ViewContactBll>();

        builder.Services.AddSingleton<ContactsViewModel>();
        builder.Services.AddSingleton<ContactViewModel>();

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<EditContactPage>();
        builder.Services.AddSingleton<AddContactPage>();

        return builder.Build();
    }
}