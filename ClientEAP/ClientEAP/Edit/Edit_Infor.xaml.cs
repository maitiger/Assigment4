using ClientApp.Enity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientApp.Edit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Edit_Infor : ContentDialog
    {
        private string currentUploadUrl;
        public Edit_Infor()
        {
            this.InitializeComponent();
            Getinfo();
        }
        private async void SaveButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Dictionary<String, String> currentStudent = new Dictionary<string, string>();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("credential.txt");
            var content = await FileIO.ReadTextAsync(file);
            Token tokenResponse = JsonConvert.DeserializeObject<Token>(content);

            HttpClient httpClient = new HttpClient();   
            currentStudent.Add("newEmail", this.Email.Text);
            currentStudent.Add("newName", this.Name.Text);
            currentStudent.Add("newBirthday", this.Birthday.Text);
            currentStudent.Add("newPhone", this.Phone.Text);
            currentStudent.Add("newAddress", this.Address.Text);
            string jsonUser = JsonConvert.SerializeObject(currentStudent);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + tokenResponse.token);
            StringContent stringContent = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            Debug.WriteLine("Thong tin thay doi " + jsonUser);
            var response = httpClient.PostAsync(Service.API_INFORMATION, stringContent);
            var responseText = await response.Result.Content.ReadAsStringAsync();
            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                MessageDialog messageDialog = new MessageDialog("Thay đổi thông tin thành công");
                await messageDialog.ShowAsync();
                //var rootFrame = Window.Current.Content as Frame;
                Debug.WriteLine("Change success!!!");
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Thay đổi thông tin không thành công");
                await messageDialog.ShowAsync();
                Debug.WriteLine("Change fail " + response.Result.StatusCode);
            }
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

        public async void Getinfo()
        {
            string content = await ReadFile("credential.txt");
            Token member_token = JsonConvert.DeserializeObject<Token>(content);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + member_token.token);
            var response = client.GetAsync(Service.API_INFORMATION);
            Debug.WriteLine(response.Result.StatusCode);
            var result = await response.Result.Content.ReadAsStringAsync();
            StudentRoll responseJsonMember = JsonConvert.DeserializeObject<StudentRoll>(result);
            this.Name.Text = responseJsonMember.informations.name;

            if (responseJsonMember.informations.name != null)
            {
                this.name.Text = responseJsonMember.informations.name;
            }

            if (responseJsonMember.informations.email != null)
            {
                this.Email.Text = responseJsonMember.informations.email;
            }

            if (responseJsonMember.informations.address != null)
            {
                this.Address.Text = responseJsonMember.informations.address;
            }
      
        }
        private void ResetButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Phone.Text = string.Empty;
            this.Email.Text = string.Empty;
            this.Address.Text = string.Empty;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
        }
        public async void HttpUploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.  
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string imageUrl = reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private void ChangeAvatar(object sender, KeyRoutedEventArgs e)
        {
            //try
            //{
            //    this.img_avatar.ProfilePicture = new BitmapImage(new Uri(this.Avatar.Text, UriKind.Absolute));
            //}
            //catch
            //{

            //}
        }
    }
}

