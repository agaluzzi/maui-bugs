namespace maui_bugs;

public class MainPage : ContentPage
{
    public MainPage()
    {
        Padding = 20;

        var button = new Button {Text = "button"};
        var slider = new Slider();

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Children =
            {
                new Button
                {
                    Text = "Test Button Command",
                    Command = new Command(() =>
                    {
                        // This works because ButtonHandler is correctly referencing ButtonHandler.CommandMapper
                        button.Handler!.Invoke(CustomCommand.Key);
                    })
                },
                new Button
                {
                    Text = "Test Slider Command",
                    Command = new Command(() =>
                    {
                        // This does NOT work because SliderHandler is incorrectly referencing
                        // ViewHandler.ViewCommandMapper instead of SliderHandler.CommandMapper
                        slider.Handler!.Invoke(CustomCommand.Key);
                    })
                },
                new BoxView {Color = Colors.LightBlue, HeightRequest = 2, Margin = 20},
                button,
                slider,
            }
        };
    }
}