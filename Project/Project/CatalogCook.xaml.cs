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
        public CatalogCook()
        {
            Title = "CatalogBook";
            InitializeComponent();
            forwardBtn.Clicked += GoToForward;
            backBtn.Clicked += GoToBack;
            Content = new StackLayout { Children = { forwardBtn, backBtn, stackLabel } };
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
        private async void GoToForward(object sender, EventArgs e)
        {
            AllMeals page = new AllMeals();
            await Navigation.PushAsync(page);
            page.DisplayStack();
        }

        // Переход обратно на MainPage 
        private async void GoToBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            ((MainPage)navPage.CurrentPage).DisplayStack();
        }
    }
}