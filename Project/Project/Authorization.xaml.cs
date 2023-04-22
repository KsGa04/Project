using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        public Authorization()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            
            

        }

        private async void Reg_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        private async void autho_Clicked(object sender, EventArgs e)
        {
            object name = "";
            object password = "";
            App.Current.Properties.TryGetValue("mail", out name);
            App.Current.Properties.TryGetValue("pass", out password);
            if (picker.SelectedIndex == 0)
            {
                if (mail.Text == (string)name)
                {
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                }
            }
            else if (picker.SelectedIndex == 2)
            {
                if (mail.Text == (string)name)
                {
                    await Shell.Current.GoToAsync($"//{nameof(AddCategories)}");
                }
            }
            //switch (picker.SelectedIndex)
            //{
            //    case 0:
            //        await Navigation.PushAsync(new FlyoutMain());
            //        break;
            //    case 1:
            //        ;
            //        break;
            //    case 2:
            //        await Navigation.PushAsync(new AddCategory());
            //        break;
            //    default:
            //        DisplayAlert("Ошибка", "Выберите роль", "Ок");
            //        break;
            //}
            //if(picker.SelectedIndex == 2)
            //{
            //    await Navigation.PushAsync(new AddCategory());
            //}
            //else if(picker.SelectedIndex ==0)
            //{
            //    await Navigation.PushAsync(new FlyoutMain());
            //}
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}