using Flakesnow.Model;
using SQLite;
using System;
using System.Diagnostics;
using System.Linq;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                var posts = connection.Table<Post>().ToList();
                ListViewLayout.ItemsSource = posts;
            }
        }

        void OnChangeOrderClicked(object sender, EventArgs args)
        {

        }

        void OnInfoClicked(object sender, EventArgs args)
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

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = ListViewLayout.SelectedItem as Post;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetail(selectedPost));
            }
        }
    }
}
