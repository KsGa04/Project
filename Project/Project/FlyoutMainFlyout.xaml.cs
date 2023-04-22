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
    public partial class FlyoutMainFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMainFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMainFlyoutViewModel();
            ListView = MenuItemsListView;
            Navigation.PopAsync(false);
        }

        private class FlyoutMainFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMainFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMainFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMainFlyoutMenuItem>(new[]
                {
                    new FlyoutMainFlyoutMenuItem { Id = 0, Title = "Главная страница", TargetType=typeof(FlyoutMain) },
                    new FlyoutMainFlyoutMenuItem { Id = 1, Title = "Личный кабинет", TargetType=typeof(PrivateAccount) },
                    new FlyoutMainFlyoutMenuItem { Id = 2, Title = "Каталог блюд" },
                    new FlyoutMainFlyoutMenuItem { Id = 3, Title = "Мои рецепты" },
                    new FlyoutMainFlyoutMenuItem { Id = 4, Title = "Выйти", TargetType=typeof(Authorization) },
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