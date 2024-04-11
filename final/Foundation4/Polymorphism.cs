using System;
using System.Collections.Generic;

namespace PolymorphismExerciseTracking
{
    class Activity
    {
        public DateTime Date { get; set; }
        public int LengthInMinutes { get; set; }

        public Activity(DateTime date, int length)
        {
            Date = date;
            LengthInMinutes = length;
        }

        public virtual double GetDistance()
        {
            return 0;
        }

        public virtual double GetSpeed()
        {
            return 0;
        }

        public virtual double GetPace()
        {
            return 0;
        }

        public virtual string GetSummary()
        {
            return $"{Date.ToShortDateString()} - {GetType().Name} ({LengthInMinutes} min)";
        }
    }

    class Running : Activity
    {
        public double Distance { get; set; }

        public Running(DateTime date, int length, double distance)
            : base(date, length)
        {
            Distance = distance;
        }

        public override double GetDistance()
        {
            return Distance;
        }

        public override double GetSpeed()
        {
            return Distance / (LengthInMinutes / 60.0);
        }

        public override double GetPace()
        {
            return LengthInMinutes / Distance;
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
        }
    }

    class Cycling : Activity
    {
        public double Speed { get; set; }

        public Cycling(DateTime date, int length, double speed)
            : base(date, length)
        {
            Speed = speed;
        }

        public override double GetSpeed()
        {
            return Speed;
        }

        public override double GetPace()
        {
            return 60.0 / Speed;
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} - Speed: {Speed} mph, Pace: {GetPace()} min per mile";
        }
    }

    class Swimming : Activity
    {
        public int Laps { get; set; }

        public Swimming(DateTime date, int length, int laps)
            : base(date, length)
        {
            Laps = laps;
        }

        public override double GetDistance()
        {
            return Laps * 50 / 1000; // Distance in kilometers
        }

        public override double GetSpeed()
        {
            return GetDistance() / (LengthInMinutes / 60.0);
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running(new DateTime(2024, 4, 10), 30, 3.0));
            activities.Add(new Cycling(new DateTime(
