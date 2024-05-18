using System;
using Microsoft.Maui.Controls;

namespace ActiveTen;

public partial class ProgressTracking : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
    public ProgressTracking()
    {
        InitializeComponent();
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        // Fetch workout records from the database
        var records = await firebaseHelper.GetAllWorkoutRecord();

        // Calculate total workouts
        int totalWorkouts = records.Count;

        // Calculate total calories burned
        double totalCaloriesBurned = records.Sum(record => record.CalortiesBurned);

        // Calculate average calories burned
        double averageCalories = totalWorkouts > 0 ? totalCaloriesBurned / totalWorkouts : 0;

        // Calculate total time spent (assuming each workout is 10 minutes)
        int totalTimeSpent = totalWorkouts * 10;

        // Bind data to UI elements
        TotalWorkoutsLabel.Text = $"{totalWorkouts} Workouts";
        CaloriesBurnedLabel.Text = $"{totalCaloriesBurned:F3} kcal";
        AverageCaloriesLabel.Text = $"Your average is {averageCalories:F3} kcal";
        TotalTimeSpentLabel.Text = $"{totalTimeSpent} Minutes";
    }
}

