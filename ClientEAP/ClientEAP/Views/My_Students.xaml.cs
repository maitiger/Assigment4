using ClientApp.Enity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ClientApp.Edit;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class My_Students : Page
    {


        Students students = new Students();
        public My_Students()
        {
            this.InitializeComponent();

            LoadMyAccount();

        }

        private async void edit_Click(object sender, RoutedEventArgs e)
        {
            var edit = new Edit_Infor();
            await edit.ShowAsync();
            // this.Myframe.Navigate(typeof(MainPage));
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

        private async void LoadMyAccount()
        {
            string content = await ReadFile("credential.txt");

            Token member_token = JsonConvert.DeserializeObject<Token>(content);

            StudentRoll responseJsonMember = await Enity.Login.GetInformation(member_token.token);
    
            this.txt_name.Text = responseJsonMember.informations.name;

            if (responseJsonMember.informations.name != null)
            {
                this.Name.Text = responseJsonMember.informations.name;
            }

            if (responseJsonMember.informations.email != null)
            {
                this.txt_Email.Text = responseJsonMember.informations.email;
            }

            if (responseJsonMember.informations.address != null)
            {
                this.txt_address.Text = responseJsonMember.informations.address;
            }

            this.txt_birthday.Text = responseJsonMember.informations.birthday.ToString("dd/MM/yyyy");

        }


       

    }
}

