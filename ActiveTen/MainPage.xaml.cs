using ActiveTen.Models;

namespace ActiveTen
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Workout selectedWorkout)
            {
                await Navigation.PushAsync(new WorkoutDetails(selectedWorkout));
            }
        }
    }

}

