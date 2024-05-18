using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace ActiveTen;

public partial class Record : ContentPage
{
    public ObservableCollection<WorkoutRecord> Records { get; set; } = new ObservableCollection<WorkoutRecord>();
    FirebaseHelper firebaseHelper = new FirebaseHelper();

    public Record()
    {
        InitializeComponent();
        InitializeData();
        BindingContext = this;
    }

    private async void InitializeData()
    {
        var records = await firebaseHelper.GetAllWorkoutRecord();
        foreach (var record in records)
        {
            Records.Add(record);
        }
    }
}
