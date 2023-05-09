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
    public partial class CategoryBlock : Frame
    {
        Category category;
        public CategoryBlock(Category category)
        {
            InitializeComponent();

            this.category = category;

            CategoryImage.Source = ImageSource.FromStream(() => new MemoryStream(category.ImageCategory));
            CategoryName.Text = category.NameCategory.ToString();
        }
        private async void TapGestureRecognizer_Tapped_ToGame(object sender, EventArgs e)
        {
            int idCateg = category.CategoryId;
            await Navigation.PushModalAsync(new AllMeals(idCateg));
        }
    }
}