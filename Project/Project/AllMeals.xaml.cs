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
        public AllMeals()
        {
            Title = "AllMeals";
            InitializeComponent();
            backBtn.Clicked += GoToBack;
            Content = new StackLayout { Children = { backBtn, stackLabel } };
        }
        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            stackLabel.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack)
            {
                stackLabel.Text += p.Title + "\n";
            }
        }
        private async void GoToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((CatalogCook)navPage.CurrentPage).DisplayStack();
        }
    }
}