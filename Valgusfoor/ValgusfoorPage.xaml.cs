
using Microsoft.Maui.Controls.Shapes;

namespace Valgusfoor;

public partial class ValgusfoorPage : ContentPage
{
	Ellipse punane, roheline, kollane;
    Label statusLabel;
    bool status = false; // false tähendab, et valgusfoor on väljas.

    HorizontalStackLayout hsl;
    List<string> nupud = new List<string>()
    {
        "Sisse",
        "Välja"
    };
    VerticalStackLayout vsl;



    public ValgusfoorPage()
	{
        statusLabel = new Label
        {
            Text = "Vali valgus!",
            FontFamily = "Socafe",
            FontSize = 28,
            TextColor = Colors.Black,
        };

        punane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Gray),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        kollane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Gray),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        roheline = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Colors.Gray),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };


        hsl = new HorizontalStackLayout
        {
            Spacing = 20,
            HorizontalOptions = LayoutOptions.Center
        };
        for (int j = 0; j < nupud.Count; j++)
        {
            Button nupp = new Button
            {
                Text = nupud[j],
                FontSize = 28,
                FontFamily = "Socafe",
                TextColor = Colors.Chocolate,
                BackgroundColor = Colors.Beige,
                CornerRadius = 10,
                HeightRequest = 50,
                ZIndex = j
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children =
            {
                punane,
                kollane,
                roheline,
                hsl
            },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }

    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PopAsync();
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
        }
    }

}
