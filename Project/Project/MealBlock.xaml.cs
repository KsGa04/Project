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
    public partial class MealBlock : Frame
    {
        Meal meal;
        public MealBlock(Meal meal)
        {
            InitializeComponent();
            this.meal = meal;
            MealImage.Source = ImageSource.FromStream(() => new MemoryStream(meal.ImageMeal));
            MealName.Text = meal.NameMeal.ToString();
        }
        private async void TapGestureRecognizer_Tapped_ToGame(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SpecificMeal(meal));
        }
    }
}