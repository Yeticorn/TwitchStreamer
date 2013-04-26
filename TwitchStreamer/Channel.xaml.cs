using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TwitchRest.Api;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace TwitchStreamer
{
    public partial class Channel : PhoneApplicationPage
    {
        public Channel()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            base.OnNavigatedTo( e );

            var game = NavigationContext.QueryString["game"];
            gameName.Text = game.ToString();

            RestFactory.GetStreams( game, StreamsSuccess, StreamsFailed );
        }

        private void StreamsSuccess( StreamsResponse response )
        {
            SolidColorBrush backgroundborderbrush = new SolidColorBrush();
            backgroundborderbrush.Color = Color.FromArgb(255, 45, 50, 65);
            SolidColorBrush titlefontbrush = new SolidColorBrush();
            titlefontbrush.Color = Color.FromArgb(255, 180, 190, 200);
            SolidColorBrush livefontbrush = new SolidColorBrush();
            livefontbrush.Color = Color.FromArgb(255, 100, 110, 127);
            SolidColorBrush scrollbackgroundbrush = new SolidColorBrush();
            scrollbackgroundbrush.Color = Color.FromArgb(255, 83, 91, 107);

            StackPanel hPanel;
            StackPanel vPanel;
            Image img;
            TextBlock tStatus;
            TextBlock tName;
            TextBlock tViewers;
            Button button;
            Border border;

            foreach( var stream in response.Streams )
            {
                tStatus = new TextBlock();
                tStatus.Text = stream.Channel.Status;
                tStatus.Foreground = titlefontbrush;
                tStatus.FontSize = 24;

                tName = new TextBlock();
                tName.Text = "on " + stream.Channel.Name;
                tName.Foreground = livefontbrush;
                tName.FontSize = 18;

                tViewers = new TextBlock();
                tViewers.Text = "" + stream.Viewers;
                tViewers.Foreground = titlefontbrush;
                tViewers.FontSize = 20;

                img = new Image();
                img.Source = new BitmapImage( new Uri( stream.Preview.Medium ) );
                img.Height = 75;
                img.Width = 120;
                img.Margin = new System.Windows.Thickness(0, 0, 10, 0);

                vPanel = new StackPanel();
                vPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                vPanel.Children.Add( tStatus );
                vPanel.Children.Add( tName );
                vPanel.Children.Add( tViewers );

                hPanel = new StackPanel();
                hPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                hPanel.Children.Add( img );
                hPanel.Children.Add( vPanel );

                button = new Button();
                button.Content = hPanel;
                button.BorderThickness = new System.Windows.Thickness(0);
                button.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                //handle video here
                //button.Click;

                border = new Border();
                border.Child = button;
                border.Background = backgroundborderbrush;
                border.BorderThickness = new System.Windows.Thickness(0, 1, 0, 0);

                streams.Children.Add( border );
            }
            scrollviewer.Background = scrollbackgroundbrush;
        }

        private void StreamsFailed( string errorMessage )
        {
            throw new NotImplementedException( "Error handling not implemented yet" );
        }
    }
}