using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flakesnow
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNewReminderPage : ContentPage
	{
		public CreateNewReminderPage ()
		{
			InitializeComponent ();
		}

        void OnSaveClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new MainPage());
		}


		void OnReminderTapped(object sender, EventArgs args)
		{
			ReminderFrame.BackgroundColor = Color.White;
			CounterFrame.BackgroundColor = Color.LightGray;

			ReminderLayout.IsVisible = true;
			CounterLayout.IsVisible = false;
		}

		void OnCounterTapped(object sender, EventArgs args)
		{
			ReminderFrame.BackgroundColor = Color.LightGray;
			CounterFrame.BackgroundColor = Color.White;

			ReminderLayout.IsVisible = false;
			CounterLayout.IsVisible = true;
		}
	}
}