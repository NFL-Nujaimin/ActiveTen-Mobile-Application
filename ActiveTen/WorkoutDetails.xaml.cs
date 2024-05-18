using ActiveTen.Models;

namespace ActiveTen;

public partial class WorkoutDetails : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
    public WorkoutDetails(Workout workout)
    {
        InitializeComponent();
        if (workout == null)
        {
            throw new ArgumentNullException(nameof(workout), "Workout is null.");
        }
        BindingContext = workout;
    }
    async void OnWorkoutClicked(object sender, EventArgs args)
    {
        if (BindingContext is Workout workout && !string.IsNullOrWhiteSpace(workout.VideoUrl))
        {
            await Browser.OpenAsync(workout.VideoUrl, BrowserLaunchMode.SystemPreferred);
        }
        else
        {
            await DisplayAlert("Error", "No video URL available for this workout.", "OK");
        }
    }
    void onDatePickerSelected(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate.ToString();
    }
    async void OnComplete(object sender, EventArgs e)
    {
        if (double.TryParse(inputWeight.Text, out double weight) && double.TryParse(inputHearRate.Text, out double heartRate))
        {
            if (weight <= 0 || heartRate <= 0)
            {
                DisplayAlert("Error", "Your eight and heart rate must be greater than 0", "OK");
                return;
            }

            double duration = 10;
            double caloriesBurned = CalculateCaloriesBurned(weight, heartRate, duration);
            string date = selectDate.Date.ToString("dd/MM/yyyy");

            if (BindingContext is Workout workout)
            {
                await firebaseHelper.AddRecord(workout.Name, date, weight, heartRate, caloriesBurned);
                await DisplayAlert("Success", "Workout record has been saved.", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", "Please enter valid weight and heart rate values.", "OK");
        }
    }
    private double CalculateCaloriesBurned(double weight, double heartRate, double duration)
    {
        double caloriesBurnedPerMinute = (heartRate * 0.6309 + weight * 0.1988 - 55.0969) * duration / 4.184;
        return Math.Round(caloriesBurnedPerMinute * duration, 3);
    }
    void OnInputTextChanged(object sender, TextChangedEventArgs e)
    {
        completeButton.IsEnabled = !string.IsNullOrWhiteSpace(inputWeight.Text) && !string.IsNullOrWhiteSpace(inputHearRate.Text);
    }

}