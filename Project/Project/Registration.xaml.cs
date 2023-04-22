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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void reg_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Add("mail", mail.Text);
            App.Current.Properties.Add("pass", pass.Text);
            Navigation.PushAsync(new Authorization());
        }

        
    }
}