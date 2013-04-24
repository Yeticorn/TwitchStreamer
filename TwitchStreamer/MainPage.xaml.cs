using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using TwitchStreamer.Resources;
using TwitchRest.Api;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace TwitchStreamer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            if( !App.ViewModel.IsDataLoaded )
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            // If selected item is null (no selection) do nothing
            //if (MainLongListSelector.SelectedItem == null)
            //    return;

            // Navigate to the new page
            //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            //MainLongListSelector.SelectedItem = null;
        }

        private void PageLoaded( object sender, System.Windows.RoutedEventArgs e )
        {
            RestFactory.GetTopGames( RenderTopGames, ErrorTopGames );
        }

        private void RenderTopGames( TopGames topgames )
        {
            SolidColorBrush backgroundborderbrush = new SolidColorBrush();
            backgroundborderbrush.Color = Color.FromArgb(255, 45, 50, 65);
            SolidColorBrush titlefontbrush = new SolidColorBrush();
            titlefontbrush.Color = Color.FromArgb(255, 180, 190, 200);
            SolidColorBrush livefontbrush = new SolidColorBrush();
            livefontbrush.Color = Color.FromArgb(255, 100, 110, 127);
            SolidColorBrush scrollbackgroundbrush = new SolidColorBrush();
            scrollbackgroundbrush.Color = Color.FromArgb(255, 83, 91, 107);

            //topgames.ToString();
            //var gameListGrid = (Grid)this.FindName("gamelist");
            StackPanel hPanel;
            StackPanel vPanel;
            Image logo;
            Button button;
            TextBlock tTitle;
            TextBlock tLivech;
            TextBlock tViewers;
            Border border;
            int cnt = 0;

            foreach (var game in topgames.Top)
            {
                //gamelist.RowDefinitions.Add(new RowDefinition
                //{
                //    Height = new System.Windows.GridLength(80)
                //});
                border = new Border();
                tTitle = new TextBlock();
                tLivech = new TextBlock();
                tViewers = new TextBlock();
                button = new Button();
                vPanel = new StackPanel();
                hPanel = new StackPanel();
                logo = new Image();
                logo.Source = new BitmapImage(new Uri(game.Game.Logo.Medium, UriKind.Absolute));
                logo.Margin = new System.Windows.Thickness(0, 0, 10, 0);
                tTitle.Text = game.Game.Name;
                tTitle.Foreground = titlefontbrush;
                tTitle.FontSize = 24;
                tLivech.Text = game.Channels.ToString() + " Live Channels";
                tLivech.Foreground = livefontbrush;
                tLivech.FontSize = 18;
                tViewers.Text = game.Viewers.ToString();
                tViewers.Foreground = titlefontbrush;
                tViewers.FontSize = 20;

                Grid.SetRow(border, cnt);
                
                button.Content = hPanel;
                button.BorderThickness = new System.Windows.Thickness(0);
                hPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                hPanel.Children.Add(logo);
                hPanel.Children.Add(vPanel);

                vPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                vPanel.Width = 320;
                vPanel.Children.Add(tTitle);
                vPanel.Children.Add(tLivech);
                vPanel.Children.Add(tViewers);

                border.Child = button;
                border.Background = backgroundborderbrush;
                border.BorderThickness = new System.Windows.Thickness(0, 1, 0, 0);
                stackpanel.Children.Add(border);
                scrollviewer.Content = stackpanel;
                scrollviewer.Height = 500;
                scrollviewer.Background = scrollbackgroundbrush;
                cnt++;
            }
        }

        private void ErrorTopGames( string errorMessage )
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }

    public class Channel
    {
        public String Title { get; set; }
        public String User { get; set; }
        public String Viewercount { get; set; }
        public String Preview { get; set; }

        public Channel( String title, String user, String viewercount, String preview )
        {
            this.Title = title;
            this.User = user;
            this.Viewercount = viewercount;
            this.Preview = preview;
        }
    }

    public class Channels : ObservableCollection<Channel>
    {
        public Channels()
        {
            Add( new Channel( "Ex1 title", "Ex1 user", "Ex1 1000", "600x480" ) );
            Add( new Channel( "Ex2 title", "Ex2 user", "Ex2 1000", "600x480" ) );
        }
    }
}