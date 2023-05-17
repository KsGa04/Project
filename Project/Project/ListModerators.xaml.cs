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
    public partial class ListModerators : ContentPage
    {
        string dbPath;
        public ListModerators()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            FillMain();
        }
        public void FillMain()
        {
            MainPlace.Children.Clear();
            using (CookingBookContext db = new CookingBookContext(dbPath))
            {
                foreach (var moderator in db.Moderators)
                {
                    BlockModerator block = new BlockModerator(moderator);
                    MainPlace.Children.Add(block);
                }
            }

        }
    }
}