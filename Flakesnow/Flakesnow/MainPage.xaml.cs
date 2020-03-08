using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Flakesnow
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnSettingsClicked(object sender, EventArgs args)
        {
            DisplayAlert("Hi", "hi", "canhel");
        }

        void OnCreateNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CreateNewReminderPage());
        }
    }
}
