
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
            FontSize = 28,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start
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
            nupp.Clicked += StatusMuutmine;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children =
            {
                statusLabel,
                punane,
                kollane,
                roheline,
                hsl
            },
            HorizontalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }

    private void StatusMuutmine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            status = true;
            statusLabel.Text = "Valgusfoor on sisse lülitatud";
            punane.Fill = new SolidColorBrush(Colors.Red);
            kollane.Fill = new SolidColorBrush(Colors.Yellow);
            roheline.Fill = new SolidColorBrush(Colors.Green);
        }
        else if (nupp.ZIndex == 1)
        {
            status = false;
            statusLabel.Text = "Valgusfoor on välja lülitatud";
            punane.Fill = new SolidColorBrush(Colors.Gray);
            kollane.Fill = new SolidColorBrush(Colors.Gray);
            roheline.Fill = new SolidColorBrush(Colors.Gray);
        }
    }

}
