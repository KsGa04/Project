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
    public partial class AddCategory : FlyoutPage
    {
        public AddCategory()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
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
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AddCategoryFlyoutMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}