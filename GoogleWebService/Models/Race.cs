using System;

namespace GoogleWebService.Models
{
    public class Race
    {
        public string Name { get; set; }
        public DateTime RaceDate { get; set; } 
        public TimeSpan? SwimTime { get; set; }
        public TimeSpan? T1Time { get; set; }
        public TimeSpan? BikeTime { get; set; }
        public TimeSpan? T2Time { get; set; }
        public TimeSpan? RunTime { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public double SwimDistance { get; set; }
        public double BikeDistance { get; set; }
        public double RunDistance { get; set; }
        public string CourseDescription { get; set; }
        public string BikeDescription { get; set; }
        public string SwimDescription { get; set; }
        public string Notes { get; set; }
        public string RaceClass { get; set; }
        public bool Estimated { get; set; }

        public double TotalDistance { get { return SwimDistance + BikeDistance + RunDistance; } }
        public double SwimVelocity
        {
            get
            {
                if (SwimTime != null)
                {
                    return SwimDistance / (SwimTime ?? TimeSpan.Zero).TotalHours;
                }
                return 0.0;
            }
            set
            {
                if (SwimTime == null)
                {
                    SwimTime = TimeSpan.FromHours(SwimDistance / value);
                }
            }
        }

        public double BikeVelocity
        {
            get
            {
                if (BikeTime != null)
                {
                    return BikeDistance / (BikeTime ?? TimeSpan.Zero).TotalHours;
                }
                return 0.0;
            }
            set
            {
                if (BikeTime == null)
                {
                    BikeTime = TimeSpan.FromHours(BikeDistance / value);
                }
            }
        }

        public double RunVelocity
        {
            get
            {
                if (RunTime != null)
                {
                    return RunDistance / (RunTime ?? TimeSpan.Zero).TotalHours;
                }
                return 0.0;
            }
            set
            {
                if (RunTime == null)
                {
                    RunTime = TimeSpan.FromHours(RunDistance / value);
                }
            }
        }

        public string RaceDisplay => $"{Name} : {RaceDate.Month}/{RaceDate.Year}";
    }
}