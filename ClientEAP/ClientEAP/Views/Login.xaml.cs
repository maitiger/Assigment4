using Client_APP_asm.Ennity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Client_APP_asm.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private Login currentLogin;
        private Server api_Login;
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        public Login()
        {
            this.InitializeComponent();
            this.currentLogin = new Login();
            this.api_Login = new Server();

        }
        public async void checkLogin()
        {
            StorageFile data = await storageFolder.GetFileAsync("UserLogin.txt");
            string stringdata = await FileIO.ReadTextAsync(data);
            if (stringdata != "")
            {
                Acsess access = JsonConvert.DeserializeObject<Acsess>(stringdata);
                string formatDateTime = access.expireAt.Remove(19);
                formatDateTime = formatDateTime.Replace("T", " ");
                DateTime ExpiredTime = DateTime.ParseExact(formatDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                if (ExpiredTime > DateTime.Now)
                {
                    this.Frame.Navigate(typeof(MainPage));
                }
            }

        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void loGin_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Email.Text, "[@]") && Regex.IsMatch(Email.Text, "[.]") && Password.Password != null)
            {
                
                currentLogin.Email = this.Email;
                currentLogin.Password = this.Password;
                string jsonString = JsonConvert.SerializeObject(currentLogin);

                HttpClient httpClient = new HttpClient();
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(new Uri(Server.API_Login), jsonContent);
                var contents = await response.Result.Content.ReadAsStringAsync();
                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    StorageFile sampleFile = await storageFolder.CreateFileAsync("UserLogin.txt", CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteTextAsync(sampleFile, contents);
                    this.Frame.Navigate(typeof(MainPage));
                }
            }
            
            this.Nontification.Text = "* Email or Password illegal!";
            this.Nontification.Visibility = Visibility.Visible;
        }
    }
}
