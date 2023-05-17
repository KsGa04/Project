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
    public partial class AddModerator : ContentPage
    {
        string dbPath;
        public AddModerator()
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
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if (Post.Text == "" || Pass.Text == "" || Nik.Text == "" || Categ.SelectedIndex == -1)
            {
                DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
            else
            {
                using (CookingBookContext db = new CookingBookContext(dbPath))
                {
                    db.Moderators.Add(new Moderator { Mail = Post.Text, Password = Pass.Text, NikName = Nik.Text, DateOfBirth = datebirth.Date, CategoryId = Categ.SelectedIndex + 1 });
                    db.SaveChanges();
                }
                DisplayAlert("Успешно", "Успешное добавление модератора", "Ок");

            }
        }
    }
}