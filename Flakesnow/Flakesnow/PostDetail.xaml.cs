using Flakesnow.Model;
using SQLite;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flakesnow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        Post selectedPost;

        public PostDetail(Post selectedPost)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            this.selectedPost = selectedPost;

            TitleEntry.Text = selectedPost.Title;
            DescriptionEditor.Text = selectedPost.Description;
            DatePicker.Date = Convert.ToDateTime(selectedPost.Date);
            TimePicker.Time = TimeSpan.Parse(selectedPost.Time);
            Console.WriteLine(selectedPost.Date + " + " + selectedPost.Time);



            if (selectedPost.IsCounter)
            {
                CounterLayout.IsVisible = true;
            }
            else
            {
                ReminderLayout.IsVisible = true;
            }
            

        }

        protected override bool OnBackButtonPressed()
        {
            ShowCancelAlert();
            return true;
        }

        void OnSaveClicked(object sender, EventArgs args)
        {
            selectedPost.Title = TitleEntry.Text;
            selectedPost.Description = DescriptionEditor.Text;
            selectedPost.Date = DatePicker.Date.ToString();
            selectedPost.Time = TimePicker.Time.ToString();

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Post>();
                connection.Update(selectedPost);
            }
            Navigation.PopAsync();
        }

        void OnCancelClicked(object sender, EventArgs args)
        {
            ShowCancelAlert();
        }

        void OnDeleteTapped(object sender, EventArgs args)
        {
            ShowDeleteAlert();
        }

        public async Task<bool> ShowCancelAlert()
        {
            var temp = await DisplayAlert("Cancel", "Do you want to cancel?", "Yes", "No");
            if (temp)
            {
                await Navigation.PopAsync();
            }
            return temp;
        }


        public async Task<bool> ShowDeleteAlert()
        {
            var temp = await DisplayAlert("Delete", "Do you want to delete?", "Yes", "No");
            if (temp)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                {
                    connection.CreateTable<Post>();
                    connection.Delete(selectedPost);
                }
                await Navigation.PopAsync();
            }
            return temp;
        }
    }
}