using Client_APP_asm.Ennity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Client_APP_asm
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
        private void AutoSuggestBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            List<ListSearch> ArticlerList = new List<ListSearch>();
            ArticlerList.Add(new Articles()
            {
                Name = "Ngo Ly Cuong"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Nguyen Ngoc Anh"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Alex"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Range Selector"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Community Toolkit"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Play Media File"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "MVVM Light"

            });
            SearchlistBox.ItemsSource = ArticlerList;

        }

        private class Articles : ListSearch
        {
            public string Name { get; set; }
        }
        private void search_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            List<ListSearch> ArticlerList = new List<ListSearch>();
            if (ArticlerList != null)
            {
                SearchlistBox.ItemsSource = ArticlerList.Where(a => a.Name.ToUpper().Contains(search.QueryText.ToUpper()));
            }
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
                case "Home":
                    CurrentTag = "Home";
                    this.MyFrame.Navigate(typeof(MainPage));
                    break;               
                case "Edit":
                    CurrentTag = "Edit";
                    this.MyFrame.Navigate(typeof(Views.Login));
                    break;
                case "My_Student":
                    CurrentTag = "My_Student";
                    this.MyFrame.Navigate(typeof(MainPage));
                    break;                         
                case "Log_out":
                    CurrentTag = "Log_out";
                    this.Frame.Navigate(typeof(MainPage));
                    break;
                case "List_Class":
                    {
                        CurrentTag = "List_Class";
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    break;
            }
        }
        private async void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = " Log Out",
                Content = "Can you want to log out? ",
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancel"
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                await storageFolder.CreateFileAsync("UserData.txt", CreationCollisionOption.ReplaceExisting);
                await storageFolder.CreateFileAsync("UserLogin.txt", CreationCollisionOption.ReplaceExisting);
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                Console.WriteLine("Fail");
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
