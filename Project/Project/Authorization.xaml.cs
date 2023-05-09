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
        string dbPath;
        public Authorization()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);


        }

        private async void Reg_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        private async void autho_Clicked(object sender, EventArgs e)
        {
            //using (CookingBookContext db = new CookingBookContext(dbPath))
            //{
            //    if (db.Administrators.Where(x => x.Mail == mail.Text && x.Password == pass.Text).Any() )
            //    {
            //        //Client client = db.Clients.Where(x => x.Login == Login.Text && x.Password == Password.Text).First();
            //        //App.CurrentUser.CurrentUserId = client.ClientId;
            //        await Shell.Current.GoToAsync($"//{nameof(AddCategories)}");
            //    }

            //    else if (db.Users.Where(x => x.Mail == mail.Text && x.Password == pass.Text && x.RoleId == 1).Any())
            //        await Shell.Current.GoToAsync($"//{nameof(GameAdd)}");

            //    else if (db.Employees.Where(x => x.Login == Login.Text && x.Password == Password.Text && x.RoleId == 3).Any())
            //        await Shell.Current.GoToAsync($"//{nameof(Stat)}");
            //}
            if (picker.SelectedIndex == 0)
            {
                using (CookingBookContext db = new CookingBookContext(dbPath))
                {
                    if (db.Users.Where(x => x.Mail == mail.Text && x.Password == pass.Text).Any())
                    {
                        User client = db.Users.Where(x => x.Mail == mail.Text && x.Password == pass.Text).First();
                        App.CurrentUser.CurrentUserId = client.UserId;
                        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                    }
                }
            }
            else if (picker.SelectedIndex == 2)
            {
                using (CookingBookContext db = new CookingBookContext(dbPath))
                {
                    if (db.Administrators.Where(x => x.Mail == mail.Text && x.Password == pass.Text).Any())
                    {
                        //Client client = db.Clients.Where(x => x.Login == Login.Text && x.Password == Password.Text).First();
                        //App.CurrentUser.CurrentUserId = client.ClientId;
                        await Shell.Current.GoToAsync($"//{nameof(AddCategories)}");
                    }
                }
            }
            //object name = "";
            //object password = "";
            //App.Current.Properties.TryGetValue("mail", out name);
            //App.Current.Properties.TryGetValue("pass", out password);

            //if (picker.SelectedIndex == 0)
            //{
            //    if (mail.Text == (string)name)
            //    {
            //        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            //    }
            //    else
            //    {
            //        DisplayAlert("Сообщение", "Неверный логин", "Ок");
            //    }
            //}
            //else if (picker.SelectedIndex == 2)
            //{
            //    if (mail.Text == (string)name)
            //    {
            //        await Shell.Current.GoToAsync($"//{nameof(AddCategories)}");
            //    }
            //    else
            //    {
            //        DisplayAlert("Сообщение", "Неверный логин", "Ок");
            //    }
            //}
            //else
            //{
            //    DisplayAlert("Сообщение", "Выберите роль", "Ок");
            //}
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