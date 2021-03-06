﻿using Flakesnow.Model;
using SQLite;
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
			NavigationPage.SetHasBackButton(this, false);
		}

		void OnSaveClicked(object sender, EventArgs args)
		{
			Post post = new Post()
			{
				Title = TitleEntry.Text,
				Description = DescriptionEditor.Text,
				Date = Datepicker.Date.ToString(),
				Time = Timepicker.Time.ToString(),
				IsCounter = CounterLayout.IsVisible ? true : false,
			};

			using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
			{
				connection.CreateTable<Post>();
				int rows = connection.Insert(post);
			}
		   

			Navigation.PushAsync(new MainPage());
		}

		void OnCancelClicked(object sender, EventArgs args)
		{
			ShowAlert();
		}

		protected override bool OnBackButtonPressed()
		{
			ShowAlert();
			return true;
		}

		public async Task<bool> ShowAlert()
		{
			var temp = await DisplayAlert("Cancel", "Do you want to cancel?", "Yes", "No");
			if (temp)
				await Navigation.PopAsync();
			return temp;
		}



		void OnReminderTapped(object sender, EventArgs args)
		{
			ReminderFrame.BackgroundColor = Color.White;
			CounterFrame.BackgroundColor = Color.LightGray;

			ReminderLayout.IsVisible = true;
			CounterLayout.IsVisible = false;
			TitleLayout.IsVisible = true;

		}

		void OnCounterTapped(object sender, EventArgs args)
		{
			ReminderFrame.BackgroundColor = Color.LightGray;
			CounterFrame.BackgroundColor = Color.White;

			ReminderLayout.IsVisible = false;
			CounterLayout.IsVisible = true;
			TitleLayout.IsVisible = true;
		}
	}
}