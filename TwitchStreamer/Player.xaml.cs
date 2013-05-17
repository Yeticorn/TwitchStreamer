using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using SM.Media;
using SM.Media.Playlists;
using SM.Media.Segments;
using SM.Media.Utility;

namespace TwitchStreamer
{
    public partial class Player : PhoneApplicationPage
    {
        // Constructor
        public Player()
        {
            InitializeComponent();
        }

    }
}