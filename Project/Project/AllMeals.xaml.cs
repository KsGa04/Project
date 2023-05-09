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
    public partial class AllMeals : ContentPage
    {
        string dbPath;
        int id;
        public AllMeals(int CategID)
        {
            Title = "AllMeals";
            InitializeComponent();
            id = CategID;
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            FillMain();
        }
        public void FillMain()
        {
            MainPlace.Children.Clear();
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                foreach (var category in db.Meals.Where(x => x.CategoryId == id))
                {
                    MealBlock block = new MealBlock(category);
                    MainPlace.Children.Add(block);
                }
            }

        }
    }
}