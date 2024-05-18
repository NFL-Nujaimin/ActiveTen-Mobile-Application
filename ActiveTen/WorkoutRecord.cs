using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveTen
{
    public class WorkoutRecord
    {
        public string WorkoutName { get; set; }
        public string DateRecorded { get; set; }
        public double Weight { get; set; }
        public double HeartRate { get; set; }
        public double CalortiesBurned { get; set; }
    }
}
