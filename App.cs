using Microsoft.Maui.Handlers;

namespace maui_bugs;

public class App : Application
{
    public App()
    {
        CustomCommand.Setup();
        MainPage = new MainPage();
    }
}