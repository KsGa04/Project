using System;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace Project
{
    public partial class App : Application
    {
        public const string DBFILENAME = "CookingBook.db";
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Authorization());
            //MainPage = new Index();
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);

            using (var db = new CookingBookContext(dbPath))
            {
                db.Database.EnsureDeleted();
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
                App.CurrentUser.CurrentUserId = 0;
                if (db.Administrators.Count() == 0)
                {
                    db.Administrators.Add(new Administrator { Mail = "test", Password = "test" });
                    db.SaveChanges();
                }
            }
            MainPage = new Index();
        }
        public static class CurrentUser
        {
            public static int CurrentUserId { get; set; }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
