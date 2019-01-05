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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class My_Students : Page
    {
        public ObservableCollection<Students> listStudent = new ObservableCollection<Students>();
        Token currenttoken;
        public My_Students()
        {
            this.InitializeComponent();
            currenttoken = new Token();
            //LoadListClass();
            //LoadMyAccount();





            //this.listStudent.Add(new Students() { name = "Name" });
            //this.listStudent.Add(new Students() { Class = "Class" });
            //this.listStudent.Add(new Students() { email = "Email" });
            //this.listStudent.Add(new Students() { address = "Address" });
            //this.listStudent.Add(new Students() { avatar = "Avatar" });
            //this.listStudent.Add(new Students() { });
            //this.listStudent.Add(new Students()
            //this.listStudent.Add(new Students() { birthday = "Birthday" });
            //this.listStudent.Add(new Students() { createAt = "CreateAt" });
            //this.listStudent.Add(new Students() { updateAt = "UpdateAt" });
            this.InitializeComponent();
        }
        //private async void LoadListClass()
        //{
        //    try
        //    {
        //        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        //        Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("Token.txt");
        //        currenttoken.token = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        //        HttpClient httpClient = new HttpClient();
        //        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic" + currenttoken.token);
        //        Debug.WriteLine(currenttoken.token);
        //        string responese = await httpClient.GetStringAsync(Enity.Service.API_INFORMATION);
        //        Students students = new Students();
        //        students = JsonConvert.DeserializeObject<Students>(responese);
        //        Debug.WriteLine(responese);






        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}
        //private async void LoadMyAccount()
        //{
        //    Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        //    Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("Token.txt");
        //    currenttoken.token = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic" + currenttoken.token);
        //    Debug.WriteLine(currenttoken.token);
        //    string responese = await httpClient.GetStringAsync(Enity.Service.API_INFORMATION);
        //    Students students = new Students();
        //    students = JsonConvert.DeserializeObject<Students>(responese);
        //    Debug.WriteLine(responese);

        //}

    }
}
