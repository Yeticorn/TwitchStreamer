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

            RestFactory.GetStreams( game, StreamsSuccess, StreamsFailed );
        }

        private void StreamsSuccess( StreamsResponse response )
        {
            StackPanel hPanel;
            StackPanel vPanel;
            Image img;

            foreach( var stream in response.Streams )
            {
                img = new Image();
                img.Source = new BitmapImage( new Uri( stream.Preview.Medium ) );

                vPanel = new StackPanel();
                vPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                
                vPanel.Children.Add( new TextBlock { Text = stream.Name } );
                vPanel.Children.Add( new TextBlock { Text = "on " + stream.Channel.Name } );
                vPanel.Children.Add( new TextBlock { Text = "" + stream.Viewers } );

                hPanel = new StackPanel();
                hPanel.Children.Add( img );
                hPanel.Children.Add( vPanel );

                streams.Children.Add( hPanel );
            }
        }

        private void StreamsFailed( string errorMessage )
        {
            throw new NotImplementedException( "Error handling not implemented yet" );
        }
    }
}