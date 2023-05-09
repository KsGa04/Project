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
    public partial class CatalogCook : ContentPage
    {
        string dbPath;
        public CatalogCook()
        {
            Title = "CatalogBook";
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            FillMain();
        }
        public void FillMain()
        {
            MainPlace.Children.Clear();
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                foreach (var category in db.Categories)
                {
                    CategoryBlock block = new CategoryBlock(category);
                    MainPlace.Children.Add(block);
                }
            }

        }
    }
}