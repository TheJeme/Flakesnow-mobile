using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            NavigationPage.SetHasBackButton(this, false);
        }

        void OnSettingsClicked(object sender, EventArgs args)
        {

        }

        void OnCreateNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CreateNewReminderPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Process.GetCurrentProcess().CloseMainWindow();
            Process.GetCurrentProcess().Close();
            return true;
        }
    }
}
