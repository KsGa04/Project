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
    public partial class Registration : ContentPage
    {
        string dbPath;
        public Registration()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }
        private async void reg_Clicked(object sender, EventArgs e)
        {
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                if (db.Users.Where(x => x.Mail == mail.Text).Any() || db.Users.Where(x => x.Password == pass.Text).Any())
                {
                    await DisplayAlert("Ошибка", "Такой пользователь уже зарегестрирован", "OK");
                }
                else
                {
                    User client = new User();
                    client.Mail = mail.Text;
                    client.Password = pass.Text;
                    db.Add(client);
                    db.SaveChanges();
                    await Navigation.PushAsync(new Authorization());
                }
            }
        }

        
    }
}