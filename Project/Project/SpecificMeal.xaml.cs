using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecificMeal : ContentPage
    {
        Meal meal;
        public SpecificMeal(Meal meal)
        {
            InitializeComponent();
            this.meal = meal;
            img.Source = ImageSource.FromStream(() => new MemoryStream(meal.ImageMeal));
            Name.Text = meal.NameMeal.ToString();
            Desc.Text = meal.DescriptionMeal.ToString();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                recipeList.ItemsSource = db.Recipes.ToList();
            }

        }

        private async void AddRecipe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddRecipe());
        }

        private async void recipeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Recipe selectedPhone = e.SelectedItem as Recipe;
            if (selectedPhone != null)
            {
                // Снимаем выделение
                recipeList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                //await Navigation.PushAsync(new PhonePage(selectedPhone));
            }

        }
    }
}