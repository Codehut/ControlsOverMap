using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ControlsOverMap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var MyPosition = new Geopoint(new BasicGeoposition() { Latitude = 27.6838761, Longitude = 85.33530139 });
            var MyCustomPin = createPin();
            MyMap.Children.Add(MyCustomPin);
            MapControl.SetLocation(MyCustomPin, MyPosition);
            MapControl.SetNormalizedAnchorPoint(MyCustomPin, new Point(0.0, 1.0));
            await MyMap.TrySetViewAsync(MyPosition, 15, 0, 0, MapAnimationKind.Bow);
        }

        private DependencyObject createPin()
        {
            //Creating a Grid element.
            var myGrid = new Grid();
            myGrid.Height = 140;
            myGrid.Width = 210;
            myGrid.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/box.png")) };

            //adding stackpanel
            var mystack = new StackPanel();
            var img = new Image();
            img.Height = 25;
            img.Width = 35;
            img.Stretch = Stretch.UniformToFill;
            img.Source = new BitmapImage(new Uri("ms-appx:///Assets/plane1.png"));
            img.HorizontalAlignment = HorizontalAlignment.Center;
            mystack.Children.Add(img);


            var flightcs = new TextBlock()
            {
                FontSize = 15,
                Foreground = new SolidColorBrush(Colors.Red),
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "G9-345"
            };
            mystack.Children.Add(flightcs);


            var ngrid = new Grid();
            ngrid.Margin = new Thickness(5, 0, 5, 0);
            ngrid.RowDefinitions.Add(new RowDefinition());
            ngrid.RowDefinitions.Add(new RowDefinition());
            ngrid.ColumnDefinitions.Add(new ColumnDefinition());
            ngrid.ColumnDefinitions.Add(new ColumnDefinition());

            var alttb = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Text = "Altitude" };
            alttb.SetValue(Grid.RowProperty, 0);
            alttb.SetValue(Grid.ColumnProperty, 0);
            ngrid.Children.Add(alttb);

            var alttb1 = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Text="15000 ft" };
            alttb1.SetValue(Grid.RowProperty, 0);
            alttb1.SetValue(Grid.ColumnProperty, 1);
            ngrid.Children.Add(alttb1);

            var sptb = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Text = "Speed" };
            sptb.SetValue(Grid.RowProperty, 1);
            sptb.SetValue(Grid.ColumnProperty, 0);
            ngrid.Children.Add(sptb);

            var sptb1 = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Text="500 Knt" };
            sptb1.SetValue(Grid.RowProperty, 1);
            sptb1.SetValue(Grid.ColumnProperty, 1);
            ngrid.Children.Add(sptb1);

            mystack.Children.Add(ngrid);
            var nstack = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(5, 5, 5, 0) };
            var ntb = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Text = "2017-07-07" };
            nstack.Children.Add(ntb);

            var ntb1 = new TextBlock() { FontSize = 15, Foreground = new SolidColorBrush(Colors.Black), Margin = new Thickness(20, 0, 0, 0), Text = "9:00:00 AM" };
            nstack.Children.Add(ntb1);

            mystack.Children.Add(nstack);
            myGrid.Children.Add(mystack);
            return myGrid;
        }
    }
}
