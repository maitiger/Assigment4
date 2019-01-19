using ClientApp.Enity;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Mark : Page
    {
        public Mark()
        {
            this.InitializeComponent();
        }
              public string Name
        {
            get;
            set;
        }
 
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<Articles> ArticlerList = new List<Articles>();
            ArticlerList.Add(new Articles()
            {
                Name = "Windows 10 UWP"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Coding4FunToolkit"
            });
            ArticlerList.Add(new Articles()
            {
                Name = "Hamburger Menu"
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
        private void search_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            List<Articles> ArticlerList = new List<Articles>();
            if (ArticlerList != null)
            {
                SearchlistBox.ItemsSource = ArticlerList.Where(a => a.Name.ToUpper().Contains(search.QueryText.ToUpper()));
            }
        }
    }
}
