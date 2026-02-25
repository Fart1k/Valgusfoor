
using Microsoft.Maui.Controls.Shapes;
using System.Net.WebSockets;

namespace Valgusfoor;

public partial class ValgusfoorPage : ContentPage
{
	Ellipse punane, roheline, kollane;
    Label statusLabel;
    Button punaneBtn, kollaneBtn, rohelineBtn;
    Grid punaneEllipseContainer, kollaneEllipseContainer, rohelineEllipseContainer;
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
        // Punane
        punaneEllipseContainer = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
            
        };

        punaneBtn = new Button
        {
            BackgroundColor = Colors.Transparent,
            BorderWidth = 0,
            WidthRequest = 200,
            HeightRequest = 200,
            IsEnabled = status
        };

        punaneBtn.Clicked += (sender, e) =>
        {
            if (!status)
            {
                return;
            }
            statusLabel.Text = "Seisa";
            punane.Fill = Colors.Red;
            kollane.Fill = Colors.Gray;
            roheline.Fill = Colors.Gray;
        };

        punane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = Colors.Gray,
            Stroke = Colors.Gray,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        Label punaneLabel = new Label
        {
            Text = "Punane",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };

        

        punaneEllipseContainer.Children.Add(punane);
        punaneEllipseContainer.Children.Add(punaneLabel);
        punaneEllipseContainer.Children.Add(punaneBtn);
        // Kollane
        kollaneEllipseContainer = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };


        kollaneBtn = new Button
        {
            BackgroundColor = Colors.Transparent,
            BorderWidth = 0,
            WidthRequest = 200,
            HeightRequest = 200,
            IsEnabled = status
        };

        kollaneBtn.Clicked += (sender, e) =>
        {
            if (!status)
            {
                return;
            }
            statusLabel.Text = "Oota";
            punane.Fill = Colors.Gray;
            kollane.Fill = Colors.Yellow;
            roheline.Fill = Colors.Gray;

        };


        kollane = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = Colors.Gray,
            Stroke = Colors.Gray,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            
        };

        Label kollaneLabel = new Label
        {
            Text = "Kollane",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };

        kollaneEllipseContainer.Children.Add(kollane);
        kollaneEllipseContainer.Children.Add(kollaneLabel);
        kollaneEllipseContainer.Children.Add(kollaneBtn);

        // Roheline

        rohelineEllipseContainer = new Grid
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        rohelineBtn = new Button
        {
            BackgroundColor = Colors.Transparent,
            BorderWidth = 0,
            WidthRequest = 200,
            HeightRequest = 200,
            IsEnabled = status
        };

        rohelineBtn.Clicked += (sender, e) =>
        {
            if (!status)
            {
                return;
            }
            statusLabel.Text = "Mine";
            punane.Fill = Colors.Gray;
            kollane.Fill = Colors.Gray;
            roheline.Fill = Colors.Green;
        };

        roheline = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = Colors.Gray,
            Stroke = Colors.Gray,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        Label rohelineLabel = new Label
        {
            Text = "Roheline",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = Colors.Black,
            FontAttributes = FontAttributes.Bold
        };

        rohelineEllipseContainer.Children.Add(roheline);
        rohelineEllipseContainer.Children.Add(rohelineLabel);
        rohelineEllipseContainer.Children.Add(rohelineBtn);

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
                punaneEllipseContainer,
                kollaneEllipseContainer,
                rohelineEllipseContainer,
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
            punane.Fill = Colors.Red;
            kollane.Fill = Colors.Yellow;
            roheline.Fill = Colors.Green;
            punaneBtn.IsEnabled = status;
            kollaneBtn.IsEnabled = status;
            rohelineBtn.IsEnabled = status;
        }
        else if (nupp.ZIndex == 1)
        {
            status = false;
            statusLabel.Text = "Valgusfoor on välja lülitatud";
            punane.Fill = Colors.Gray;
            kollane.Fill = Colors.Gray;
            roheline.Fill = Colors.Gray;
            punaneBtn.IsEnabled = status;
            kollaneBtn.IsEnabled = status;
            rohelineBtn.IsEnabled = status;
        }
    }
}