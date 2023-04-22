using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivateAccount : ContentPage
    {
        public PrivateAccount()
        {
            InitializeComponent();
            getPhotoBtn.Clicked += GetPhotoAsync;
            // съемка фото 

            takePhotoBtn.Clicked += TakePhotoAsync;
            object name = "";
            object password = "";
            App.Current.Properties.TryGetValue("mail", out name);
            App.Current.Properties.TryGetValue("pass", out password);
            post.Text = (string)name;
            pass.Text = (string)password;
            

        }
        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото 
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView 
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                // для примера сохраняем файл в локальном хранилище 
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);
                // загружаем в ImageView 
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}