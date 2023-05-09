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

        }
    }
}