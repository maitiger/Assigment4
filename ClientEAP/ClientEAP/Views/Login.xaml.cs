using ClientApp.Enity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

namespace ClientApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        Token currentToken;
        My_Students Students;
        private string CurrentTag = "";
        public Login()

        {
            currentToken = new Token();
            CheckToken();
            Students = new My_Students();
            this.InitializeComponent();
        }
        public async void CheckToken()
        {
            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("Token.txt");
                currentToken.token = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                if (currentToken.token != null)
                {
                    logout.Visibility = Visibility.Visible;
                    login.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private async void loGin_Click(object sender, RoutedEventArgs e)
        {
            string email = this.Email.Text;
            string password = this.Password.Password;
            Dictionary<String, String> studentLogin = new Dictionary<string, string>();
            studentLogin.Add("Email", email);
            studentLogin.Add("Password", password);
            HttpClient httpClient = new HttpClient();

            string jsonStudent = JsonConvert.SerializeObject(studentLogin);
            Debug.WriteLine(jsonStudent);

            var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(Enity.Service.API_Login, content);
            var contents = await response.Result.Content.ReadAsStringAsync();
            currentToken = JsonConvert.DeserializeObject<Token>(contents);
            Debug.WriteLine(currentToken.token);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.Created)
            {

            }
            else
            {
                //thông báo lỗi 
                 Error error = JsonConvert.DeserializeObject<Error>(contents);

                if (error.error.Count > 0)
                {
                    foreach (var key in error.error.Keys)
                    {
                        var objectBykey = this.FindName(key);
                        var value = error.error[key];
                        if (objectBykey != null)
                        {

                            TextBlock textblock = objectBykey as TextBlock;
                            textblock.Text = "* " + value;
                            textblock.Visibility = Visibility.Visible;
                        }

                        Debug.WriteLine(contents);

                    }
                }
            }

        }
        private async void DeleteFileToken()
        {
            StorageFile filed = await ApplicationData.Current.LocalFolder.GetFileAsync("Token.txt");
            if (filed != null)
            {
                await filed.DeleteAsync();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage));
        }
        private void Go_LoadInfor(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Go_UploadMusic(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Go_Music(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Go_Rigister(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
