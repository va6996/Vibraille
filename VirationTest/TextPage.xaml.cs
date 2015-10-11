using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace VirationTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TextPage : Page
    {
        public TextPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void sumbitText(object sender, RoutedEventArgs e)
        {
            App.Message = txtName.Text.ToLower();
            //NavigationCacheMode = NavigationCacheMode.Disabled;
           // App.Current..Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            Frame.Navigate(typeof(MainPage));
            //txtName.Text = null;
        }
    }
}
