using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryFlyout : ContentPage
    {
        public ListView ListView;

        public AddCategoryFlyout()
        {
            InitializeComponent();

            BindingContext = new AddCategoryFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class AddCategoryFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AddCategoryFlyoutMenuItem> MenuItems { get; set; }

            public AddCategoryFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AddCategoryFlyoutMenuItem>(new[]
                {
                    new AddCategoryFlyoutMenuItem { Id = 0, Title = "Добавить категорию", TargetType=typeof(AddCategory) },
                    new AddCategoryFlyoutMenuItem { Id = 1, Title = "Добавить блюдо", TargetType=typeof(AddMeals) },
                    new AddCategoryFlyoutMenuItem { Id = 2, Title = "Добавить модератора", TargetType=typeof(AddModerator) },
                    new AddCategoryFlyoutMenuItem { Id = 3, Title = "Просмотреть модераторов" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}