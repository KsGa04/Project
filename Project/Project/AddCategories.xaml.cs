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
    public partial class AddCategories : ContentPage
    {
        string dbPath;
        byte[] cookPhoto;
        public AddCategories()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            // выбор фото 
            getPhotoBtn.Clicked += GetPhotoAsync;
            // съемка фото 

            takePhotoBtn.Clicked += TakePhotoAsync;
        }
        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
                cookPhoto = File.ReadAllBytes(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Да", ex.Message, "OK");
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
                cookPhoto = File.ReadAllBytes(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if (Name.Text == "" ||  img.Source == null)
            {
                DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
            else
            {
                using (CookingBookContext db = new CookingBookContext(dbPath))
                {
                    db.Categories.Add(new Category { ImageCategory = cookPhoto, NameCategory = Name.Text });
                    db.SaveChanges();
                }
                DisplayAlert("Успешно", "Успешное добавление категории", "Ок");

            }
        }
    }
}