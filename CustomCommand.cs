using Microsoft.Maui.Handlers;

namespace maui_bugs;

public static class CustomCommand
{
    public const string Key = "_TEST_";

    public static void Setup()
    {
        // Register command callback functions, which would normally do platform-specific things...

        ViewHandler.ViewCommandMapper.Add(
            key: Key,
            action: (handler, button, args) => ShowMessage("View command invoked!", "This is NOT expected ❌"));

        ButtonHandler.CommandMapper.Add(
            key: Key,
            action: (handler, button, args) => ShowMessage("Button command invoked!", "This is expected ✅"));

        SliderHandler.CommandMapper.Add(
            key: Key,
            action: (handler, slider, args) => ShowMessage("Slider command invoked!", "This is expected ✅"));
    }

    private static void ShowMessage(string title, string message)
    {
        Application.Current!.MainPage!.DisplayAlert(title: title, message: message, cancel: "Close");
    }
}