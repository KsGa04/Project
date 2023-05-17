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
        int Id;
        string dbPath;
        public PrivateAccount()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            //getPhotoBtn.Clicked += GetPhotoAsync;

            //takePhotoBtn.Clicked += TakePhotoAsync;
            
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                

                User user = db.Users.FirstOrDefault(x => x.UserId == App.CurrentUser.CurrentUserId);
                nik.Text = user.NikName;
                post.Text = user.Mail;
                pass.Text = user.Password;
                if (user.DateOfBirth != null)
                {
                    datebirth.Date = (DateTime)user.DateOfBirth;
                }
            }

        }
        //async void GetPhotoAsync(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // выбираем фото 
        //        var photo = await MediaPicker.PickPhotoAsync();
        //        // загружаем в ImageView 
        //        img.Source = ImageSource.FromFile(photo.FullPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
        //    }
        //}
        //async void TakePhotoAsync(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
        //        {
        //            Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
        //        });
        //        // для примера сохраняем файл в локальном хранилище 
        //        var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
        //        using (var stream = await photo.OpenReadAsync())
        //        using (var newStream = File.OpenWrite(newFile))
        //            await stream.CopyToAsync(newStream);
        //        // загружаем в ImageView 
        //        img.Source = ImageSource.FromFile(photo.FullPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
        //    }
        //}

        private void Save_Clicked(object sender, EventArgs e)
        {
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                User user = db.Users.FirstOrDefault(x => x.UserId == App.CurrentUser.CurrentUserId);
                user.NikName = nik.Text;
                user.Mail = post.Text;
                user.Password = pass.Text;
                user.DateOfBirth = datebirth.Date;
            }
            DisplayAlert("Успешно", "Успешное изменение данных", "Ок");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddRecipe());
        }
    }
}