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
    public partial class AddMeals : ContentPage
    {
        string dbPath;
        byte[] cookPhoto;
        public AddMeals()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                foreach (var d in db.Categories)
                {
                    Categ.Items.Add(d.NameCategory);

                }
            }
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
            if (Name.Text == "" || img.Source == null || Description.Text == "" || Categ.SelectedIndex == -1)
            {
                DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
            else
            {
                using (CookingBookContext db = new CookingBookContext(dbPath))
                {
                    db.Meals.Add(new Meal { ImageMeal = cookPhoto, NameMeal = Name.Text, DescriptionMeal = Description.Text, CategoryId = Categ.SelectedIndex + 1 });
                    db.SaveChanges();
                }
                DisplayAlert("Успешно", "Успешное добавление категории", "Ок");

            }
        }
    }
}