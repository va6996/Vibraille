using System;
using System.Collections.Generic;
using Windows.Phone.Devices.Notification;
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
using Windows.Phone.UI.Input;

namespace VirationTest
{

    public sealed partial class MainPage : Page
    {
        string theString;
        private int[] readVal;
        private int stringPosition;
        private int[] charIntValues;
        VibrationDevice vibrationDevice = VibrationDevice.GetDefault();
        

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            //stringPosition = -1;
            //theString = App.Message;
            //updateValues();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            theString = App.Message;
            stringPosition = -1;
            updateValues();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void Hold(object sender, RoutedEventArgs e)
        {
            Button s =(Button) sender;
            string buttonName = s.Name;
            //buttonName = sender.GetType().Name.
            int position =buttonPosition(buttonName);
           // textBlock.Text = buttonName;
            vibrateLength(position);

            if (isPageRead())
                updateValues();

        }

        public bool isPageRead()
        {
            for (int i = 0; i < 6; i++)
                if (readVal[i] == 0)
                    return false;
            return true;
        }
        public int buttonPosition(string button)
        {
            switch (button)
            {
                case "Button1":
                    return 0;
                case "Button2":
                    return 1;
                case "Button3":
                    return 2;
                case "Button4":
                    return 3;
                case "Button5":
                    return 4;
                case "Button6":
                    return 5;
                default:    //unnecessary but VS gives error!
                    return 99;
            }
        }
        public Button revButton(int pos)
        {
            switch (pos)
            {
                case 0:
                    return Button1;
                case 1:
                    return Button2;
                case 2:
                    return Button3;
                case 3:
                    return Button4;
                case 4:
                    return Button5;
                case 5:
                    return Button6;
                default:
                    return new Button();     
            }
        }

        public int[] charToValues(char c)
        { 
            switch (c)
            {
                case 'a':
                    return new int[] { 1, 0, 0, 0, 0, 0 };
                case 'b':
                    return new int[] { 1, 0, 1, 0, 0, 0 };
                case 'c':
                    return new int[] { 1, 1, 0, 0, 0, 0 };
                case 'd':
                    return new int[] { 1, 1, 0, 1, 0, 0 };
                case 'e':
                    return new int[] { 1, 0, 0, 1, 0, 0 };
                case 'f':
                    return new int[] { 1, 1, 1, 0, 0, 0 };
                case 'g':
                    return new int[] { 1, 1, 1, 1, 0, 0 };
                case 'h':
                    return new int[] { 1, 0, 1, 1, 0, 0 };
                case 'i':
                    return new int[] { 0, 1, 1, 0, 0, 0 };
                case 'j':
                    return new int[] { 0, 1, 1, 1, 0, 0 };
                case 'k':
                    return new int[] { 1, 0, 0, 0, 1, 0 };
                case 'l':
                    return new int[] { 1, 0, 1, 0, 1, 0 };
                case 'm':
                    return new int[] { 1, 1, 0, 0, 1, 0 };
                case 'n':
                    return new int[] { 1, 1, 0, 1, 1, 0 };
                case 'o':
                    return new int[] { 1, 0, 0, 1, 1, 0 };
                case 'p':
                    return new int[] { 1, 1, 1, 0, 1, 0 };
                case 'q':
                    return new int[] { 1, 1, 1, 1, 1, 0 };
                case 'r':
                    return new int[] { 1, 0, 1, 1, 1, 0 };
                case 's':
                    return new int[] { 0, 1, 1, 0, 1, 0 };
                case 't':
                    return new int[] { 0, 1, 1, 1, 1, 0 };
                case 'u':
                    return new int[] { 1, 0, 0, 0, 1, 1 };
                case 'v':
                    return new int[] { 1, 0, 1, 0, 1, 1 };
                case 'w':
                    return new int[] { 0, 1, 1, 1, 0, 1 };
                case 'x':
                    return new int[] { 1, 1, 0, 0, 1, 1 };
                case 'y':
                    return new int[] { 1, 1, 0, 1, 1, 1 };
                case 'z':
                    return new int[] { 1, 0, 0, 1, 1, 1 };
            }
            return new int[] { 0, 0, 0, 0, 0, 0 };
        }
        public void vibrateLength(int position)
        {
            Button button = revButton(position); 
            //if (readVal[position] == 1)
            if (charIntValues[position] == 1)
            {
                vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(250));
                readVal[position] = 1;
                button.Visibility = Visibility.Collapsed;

            }

            else
            {
                vibrationDevice.Vibrate(TimeSpan.FromMilliseconds(100));
                readVal[position] = 1;
                button.Visibility = Visibility.Collapsed;
            }
        }
        public void updateValues()
        {
            if (theString.Length == ++stringPosition)
            {
                Frame.GoBack();
                return;
            }
            //    stringPosition = 0;
            charIntValues=charToValues(theString[stringPosition]);
            readVal = new int[] { 0, 0, 0, 0, 0, 0 };
            updateLayout();
        }
        public void updateLayout()
        {
            Button button;
            
            textBlock.Text = theString;
            for(int i = 0; i < 6; i++)
            {
                
                button = revButton(i);
                button.Visibility = Visibility.Visible;
                if (charIntValues[i] == 1)
                    button.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                else
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Orange);

            }
        }

        private void Button1_DragOver(object sender, DragEventArgs e)
        {
            Button s = (Button)sender;
            string buttonName = s.Name;
            //buttonName = sender.GetType().Name.
            int position = buttonPosition(buttonName);
            // textBlock.Text = buttonName;
            vibrateLength(position);

            if (isPageRead())
                updateValues();

        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //remove the handler before you leave!
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {

            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }
    }
}
