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
    public partial class BlockModerator : Frame
    {
        Moderator moderator;
        public BlockModerator(Moderator moderator)
        {
            InitializeComponent();
            this.moderator = moderator;
            Post.Text = moderator.Mail.ToString();
            IdModer.Text = moderator.ModeratorId.ToString();
            Pass.Text = moderator.Password.ToString();
            Nik.Text = moderator.NikName.ToString();
            Data.Text = moderator.DateOfBirth.ToString();
            IdCategory.Text = moderator.CategoryId.ToString();
        }
        private async void TapGestureRecognizer_Tapped_ToGame(object sender, EventArgs e)
        {
            //int idCateg = category.CategoryId;
            //await Navigation.PushModalAsync(new AllMeals(idCateg));
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {

        }
    }
}