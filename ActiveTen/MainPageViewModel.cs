using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ActiveTen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ActiveTen
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<TitleValue> Items { get; set; } = new ObservableCollection<TitleValue>();
        private ObservableCollection<Workout> _workouts = new ObservableCollection<Workout>();

        public ObservableCollection<Workout> Workouts
        {
            get => _workouts;
            set => SetProperty(ref _workouts, value);
        }

        [ObservableProperty]
        private bool _isLoading;


        private TitleValue _currentItem;
        public TitleValue CurrentItem
        {
            get => _currentItem;
            set
            {
                if (_currentItem != value && SetProperty(ref _currentItem, value))
                {
                    UpdateWorkouts();
                }
            }
        }

        [ObservableProperty]
        private bool _isDisplayPicker;

        public MainPageViewModel()
        {
            CurrentItem = new TitleValue() { Title = "Select Workout Plans", Value = "" };
            UpdateWorkouts();
        }

        [RelayCommand]
        public async void OpenPicker()
        {
            IsLoading = true;

            await Task.Delay(1000);

            Items.Clear();
            Items.Add(new TitleValue { Title = "Yoga", Value = "Yoga" });
            Items.Add(new TitleValue { Title = "Core Training", Value = "Core Training" });
            Items.Add(new TitleValue { Title = "Strength Training", Value = "Strength Training" });
            Items.Add(new TitleValue { Title = "Pilates", Value = "Pilates" });
            Items.Add(new TitleValue { Title = "HIIT", Value = "HIIT" });

            IsLoading = false;

            IsDisplayPicker = true;

        }

        [RelayCommand]
        public void UpdateWorkouts()
        {
            if (CurrentItem == null || string.IsNullOrEmpty(CurrentItem.Value))
            {
                Workouts.Clear();
                return;
            }

            switch (CurrentItem.Value)
            {
                case "Yoga":
                    Workouts = new ObservableCollection<Workout>(GetYogasList());
                    break;
                case "Core Training":
                    Workouts = new ObservableCollection<Workout>(GetCoreTrainingList());
                    break;
                case "Strength Training":
                    Workouts = new ObservableCollection<Workout>(GetStrengthList());
                    break;
                case "Pilates":
                    Workouts = new ObservableCollection<Workout>(GetPilatesList());
                    break;
                case "HIIT":
                    Workouts = new ObservableCollection<Workout>(GetHIITList());
                    break;
                default:
                    Workouts.Clear();
                    break;
            }
        }

        private List<Workout> GetYogasList()
        {
            return new List<Workout>
            {
                new Workout {Name = "Yoga Stretch", Description = "Yoga stretch for beginners", Duration = "10 Minutes", ImageUrl = "yoga1.png", VideoUrl = "https://www.youtube.com/embed/omh5JBndc14"},
                new Workout {Name = "Morning Yoga", Description = "Morning yoga for beginners", Duration = "10 Minutes", ImageUrl = "yoga2.png", VideoUrl = "https://www.youtube.com/embed/CyHs9v7F9gE"},
                new Workout {Name = "Yoga Full Body", Description = "Yoga full body for beginners", Duration = "10 Minutes", ImageUrl = "yoga3.png", VideoUrl = "https://www.youtube.com/embed/50mtAKIMoSM"},
                new Workout {Name = "Yoga Flexibility", Description = "Yoga flexibility for beginners", Duration = "10 Minutes", ImageUrl = "yoga4.png", VideoUrl = "https://www.youtube.com/embed/y-Z4thG1Pjs"},
                new Workout {Name = "Chair Yoga", Description = "Chair yoga for beginners", Duration = "10 Minutes", ImageUrl = "yoga5.png", VideoUrl = "https://www.youtube.com/embed/tWxKPB1uApU"}
            };
        }

        private List<Workout> GetCoreTrainingList()
        {
            return new List<Workout>
            {
                new Workout {Name = "Beginner Core Workout", Description = "Core Workout for beginners", Duration = "10 Minutes", ImageUrl = "core1.png", VideoUrl = "https://www.youtube.com/embed/b_TTLmmQmXU"},
                new Workout {Name = "Core Strengthening Workout", Description = "Core Strengthening Workout for beginners", Duration = "10 Minutes", ImageUrl = "core2.png", VideoUrl = "https://www.youtube.com/embed/iTM98dTBHAA"},
                new Workout {Name = "Deep Core Workout", Description = "Deep Core Workout for beginners", Duration = "10 Minutes", ImageUrl = "core3.png", VideoUrl = "https://www.youtube.com/embed/-Q_lgxUMD6c"},
                new Workout {Name = "Seated Ab Workout", Description = "Seated Ab Workout for beginners", Duration = "10 Minutes", ImageUrl = "core4.png", VideoUrl = "https://www.youtube.com/embed/Crczoow45uM"},
                new Workout {Name = "Intense Ab Workout", Description = "Intense Ab Workout for beginners", Duration = "10 Minutes", ImageUrl = "core5.png", VideoUrl = "https://www.youtube.com/embed/D0K-U0pFj4k"}
            };
        }

        private List<Workout> GetStrengthList()
        {
            return new List<Workout>
            {
                new Workout {Name = "Micro Strength Workout", Description = "Micro Strength Workout for beginners", Duration = "10 Minutes", ImageUrl = "strength1.png", VideoUrl = "https://www.youtube.com/embed/xeQ2i7GwIvo"},
                new Workout {Name = "Upper Body Workout", Description = "Upper Body Strength Workout for beginners", Duration = "10 Minutes", ImageUrl = "strength2.png", VideoUrl = "https://www.youtube.com/embed/XNgP5HsjcbE"},
                new Workout {Name = "Full Body Workout", Description = "Full Body Strength Workout for beginners", Duration = "10 Minutes", ImageUrl = "strength3.png", VideoUrl = "https://www.youtube.com/embed/u1My2n961KM"},
                new Workout {Name = "Morning Strength Workout", Description = "Morning Strength for beginners", Duration = "10 Minutes", ImageUrl = "strength4.png", VideoUrl = "https://www.youtube.com/embed/3sEeVJEXTfY"},
                new Workout {Name = "Cardio Strength Workout", Description = "Cardio Strength for beginners", Duration = "10 Minutes", ImageUrl = "strength5.png", VideoUrl = "https://www.youtube.com/embed/jkflYKfLucY"}
            };
        }

        private List<Workout> GetPilatesList()
        {
            return new List<Workout>
            {
                new Workout {Name = "Full Body Pilates", Description = "Full Body Pilates for beginners", Duration = "10 Minutes", ImageUrl = "pilates1.png", VideoUrl = "https://www.youtube.com/embed/auIMP3LzZiU"},
                new Workout {Name = "Gentle Pilates", Description = "Gentle Pilates for beginners", Duration = "10 Minutes", ImageUrl = "pilates2.png", VideoUrl = "https://www.youtube.com/embed/izLw13GhJGM"},
                new Workout {Name = "Tiny Waist Pilates", Description = "Tiny Waist Pilates for beginners", Duration = "10 Minutes", ImageUrl = "pilates3.png", VideoUrl = "https://www.youtube.com/embed/HDbsd5En_uw"},
                new Workout {Name = "Tone Arms Pilates", Description = "Tone Arms Pilates for beginners", Duration = "10 Minutes", ImageUrl = "pilates4.png", VideoUrl = "https://www.youtube.com/embed/tcK0pU8wDN8"},
                new Workout {Name = "Power Pilates", Description = "Power Pilates for beginners", Duration = "10 Minutes", ImageUrl = "pilates5.png", VideoUrl = "https://www.youtube.com/embed/zbYBtHfBGxg"}
            };
        }

        private List<Workout> GetHIITList()
        {
            return new List<Workout>
            {
                new Workout {Name = "Intense HIIT", Description = "Intense HIIT for beginners", Duration = "10 Minutes", ImageUrl = "hiit1.png", VideoUrl = "https://www.youtube.com/embed/_yNHzgXUHqY"},
                new Workout {Name = "Weight Loss HIIT", Description = "Weight Loss HIIT for beginners", Duration = "10 Minutes", ImageUrl = "hiit2.png", VideoUrl = "https://www.youtube.com/embed/j5SHMJ6mUoA"},
                new Workout {Name = "Fat Melting HIIT", Description = "Fat Melting for beginners", Duration = "10 Minutes", ImageUrl = "hiit3.png", VideoUrl = "https://www.youtube.com/embed/uTo2m16eJqI"},
                new Workout {Name = "Cardio X HIIT", Description = "Cardio X HIIT for beginners", Duration = "10 Minutes", ImageUrl = "hiit4.png", VideoUrl = "https://www.youtube.com/embed/ZhEq_OGAJVQ"},
                new Workout {Name = "Full Body HIIT", Description = "Full Body HIIT for beginners", Duration = "10 Minutes", ImageUrl = "hiit5.png", VideoUrl = "https://www.youtube.com/embed/KHCOf_zmBgA"}
            };
        }
    }
}