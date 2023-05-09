using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        bool loaded = false;
        public MainPage()
        {
            InitializeComponent();
            
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (loaded == false)
        //    {
        //        DisplayStack();
        //        loaded = true;
        //    }
        //}
        //protected internal void DisplayStack()
        //{

        //}
        //private async void GoToForward(object sender, EventArgs e)
        //{
        //    CatalogCook page = new CatalogCook();
        //    await Navigation.PushAsync(page);
        //    page.DisplayStack();
        //}
    }
}
