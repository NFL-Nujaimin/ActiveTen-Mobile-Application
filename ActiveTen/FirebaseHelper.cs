using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;

namespace ActiveTen
{
    internal class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://activeten-149dc-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public async Task AddRecord(string name,string date, double weight, double heartRate, double caloriesBurned)
        {
            await firebase
                .Child("WorkoutRecord")
                .PostAsync(new WorkoutRecord() { WorkoutName = name, DateRecorded = date, Weight = weight, HeartRate = heartRate, CalortiesBurned = caloriesBurned });
        }
        public async Task<List<WorkoutRecord>> GetAllWorkoutRecord()
        {
            return (await firebase
                .Child("WorkoutRecord")
                .OnceAsync<WorkoutRecord>()).Select(item => new WorkoutRecord
                {
                    WorkoutName = item.Object.WorkoutName,
                    DateRecorded = item.Object.DateRecorded,
                    Weight = item.Object.Weight,
                    HeartRate = item.Object.HeartRate,
                    CalortiesBurned = item.Object.CalortiesBurned
                }).ToList();
        }
    }
}
