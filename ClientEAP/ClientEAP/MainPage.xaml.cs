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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string CurrentTag = "";
        public static long currentMemberId = 1538727452278;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (CurrentTag == radio.Tag.ToString())
            {
                return;
            }
            switch (radio.Tag.ToString())
            {
                case "MyAccount Students":
                    CurrentTag = "MyAccount Students";
                    this.MyFrame.Navigate(typeof(Views.My_Students));
                    break;
                case "Register":
                    CurrentTag = "Log out";
                    this.MyFrame.Navigate(typeof(Views.My_Students));
                    break;
                case "Login":
                    CurrentTag = "Login";
                    this.MyFrame.Navigate(typeof(Views.Login));
                    break;
                default:
                    break;
                case "Home":
                    CurrentTag = "Home";
                    this.Frame.Navigate(typeof(MainPage));
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SplitVia.IsPaneOpen = !this.SplitVia.IsPaneOpen;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
