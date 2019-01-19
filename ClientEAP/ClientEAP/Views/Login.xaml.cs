using ClientApp.Enity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
     
        My_Students Students;    
        private static Students currentStudent;

        public Login()

        {


            Students = new My_Students();
           

            this.InitializeComponent();
        }

        public async static Task<HttpResponseMessage> Sing_In(string email, string password)
        {
            Dictionary<String, String> memberLogin = new Dictionary<string, string>();
            memberLogin.Add("email", email);
            memberLogin.Add("password", password);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(memberLogin), System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(Enity.Service.API_Login, content);
            Debug.WriteLine(response.Result.StatusCode);
            return response.Result;
        }
        public async static Task Lo_gin(string email, string password)
        {
            var tokenJson = await Sing_In(email, password).Result.Content.ReadAsStringAsync();
            Crendential tokenResponse = JsonConvert.DeserializeObject<Crendential>(tokenJson);
            string jsonUser = JsonConvert.SerializeObject(tokenResponse);
            try
            {
                await WriteFile("credential.txt", jsonUser);
                Debug.WriteLine("Success: " + jsonUser);
            }
            catch
            {
                Debug.WriteLine("Fail: " + jsonUser);
            }
        }
        public async static Task WriteFile(string file_name, string text)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync(file_name,
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, text);
        }
        public async static Task<string> ReadFile(string file_name)
        {
            Windows.Storage.StorageFolder storageFolder =
                        Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync(file_name);
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            return text;
        }
        public async static Task<string> GetToken()
        {
            string token;
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            if (await localfolder.TryGetItemAsync("credential.txt") != null)
            {
                string text = await ReadFile("credential.txt");
                if (text == "")
                {
                    token = "";
                }
                else
                {
                    Crendential credential = JsonConvert.DeserializeObject<Crendential>(text);
                    token = credential.accessToken;
                }
            }
            else
            {
                token = "";
            }

            return token;
        }
        public async static Task<HttpResponseMessage> GetData(string server_url, string scheme, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
            var response = httpClient.GetAsync(server_url);
            return response.Result;
        }
        private async void loGin_Click(object sender, RoutedEventArgs e)
        {
            var txt_email = Email.Text;
            var txt_password = Password.Password;
            var httpReponse = Sing_In(txt_email, txt_password);
            var x = httpReponse.Result.StatusCode;
            if (x == System.Net.HttpStatusCode.OK)
            {
                await Lo_gin(txt_email, txt_password);
                var Frame = Window.Current.Content as Frame;
                Frame.Navigate(typeof(MainPage));
                Debug.WriteLine(httpReponse.Result.StatusCode);
            }
            else
            {
                Debug.WriteLine(x);
            }
        }
        public static async void DoLogin()
        {
            var token = await GetToken();
            if (token != "")
            {
                var httpResponseMessage = GetData(Service.API_INFORMATION, "Basic", token);
                //Debug.WriteLine(httpResponseMessage.Result.StatusCode);
                if (httpResponseMessage.Result.StatusCode == HttpStatusCode.OK)
                {
                    var rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(MainPage));
                }
                else
                {
                    Debug.WriteLine("don't token");
                }
            }
          




            //    if (response.StatusCode == System.Net.HttpStatusCode.Created)
            //    {
            //        Debug.WriteLine("Success");
            //        Debug.WriteLine(contents);
            //        Token currentToken = JsonConvert.DeserializeObject<Token>(contents);
            //        StorageFolder storageFolder = ApplicationData.Current.LocalFolder; // luu file token
            //        StorageFile storageFile = await storageFolder.CreateFileAsync("token.txt", CreationCollisionOption.ReplaceExisting);
            //        await FileIO.WriteTextAsync(storageFile, contents);
            //        var rootFrame = Window.Current.Content as Frame;
            //        rootFrame.Navigate(typeof(MainPage));


            //    }
            //    else
            //    {
            //        //thông báo lỗi 
            //        Error error = JsonConvert.DeserializeObject<Error>(contents);

            //        if (error.error.Count > 0)
            //        {
            //            foreach (var key in error.error.Keys)
            //            {
            //                var objectBykey = this.FindName(key);
            //                var value = error.error[key];
            //                if (objectBykey != null)
            //                {
            //                    TextBlock textBlock = objectBykey as TextBlock;
            //                    textBlock.Text = "* " + value;
            //                }
            //                if (error.error.Count < 0)
            //                {
            //                    Debug.WriteLine("hihi");
            //                }
            //            }
            //        }

            //    }
            //}
            //private async void DeleteFileToken()
            //{
            //    StorageFile filed = await ApplicationData.Current.LocalFolder.GetFileAsync("Token.txt");
            //    if (filed != null)
            //    {
            //        await filed.DeleteAsync();

            //    }
            //}
            ////check token
            //public static async void DoLogin()
            //{
            //     currentStudent = new Students();
            //    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //    if(await storageFolder.TryGetItemAsync("token.txt") != null)
            //    {
            //        StorageFile storageFile = await storageFolder.GetFileAsync("token.txt");
            //        var tokenContent = await FileIO.ReadBufferAsync(storageFile);
            //        Token token = JsonConvert.DeserializeObject<Token>(tokenContent);

            //        HttpClient httpClient = new HttpClient();
            //        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic" + token.token);
            //        var responsee = httpClient.GetAsync(Enity.Service.API_Login).Result;
            //        Debug.WriteLine(await responsee.Content.ReadAsStringAsync());
            //        var user = await responsee.Content.ReadAsStringAsync();
            //        Students studentJson = JsonConvert.DeserializeObject<Students>(responsee);
            //        currentStudent.name = studentJson.name;
            //        currentStudent.Class = studentJson.Class;
            //        currentStudent.email = studentJson.email;
            //        currentStudent.address = studentJson.address;
            //        currentStudent.avatar = studentJson.avatar;
            //        currentStudent.gender = studentJson.gender;
            //        currentStudent.birthday = studentJson.birthday;
            //        currentStudent.status = studentJson.status;
            //        currentStudent.password = studentJson.password;
            //        var rootFrame = Window.Current.Content as Frame;
            //        rootFrame.Navigate(typeof(MainPage));


            //        Debug.WriteLine("Login Success");
            //    }
            //    else
            //    {
            //        Debug.WriteLine("Please check agian");
            //    }
            //}

        }
       
    }
}
    

