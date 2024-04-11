using System;

namespace EventPlanningInheritance
{
    class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Address Address { get; set; }

        public virtual string GetFullDetails()
        {
            return $"Event: {GetType().Name}\nTitle: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
        }

        public virtual string GetShortDescription()
        {
            return $"Event Type: Standard\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class Lecture : Event
    {
        public string Speaker { get; set; }
        public int Capacity { get; set; }

        public override string GetFullDetails()
        {
            return $"Event: Lecture\n{base.GetFullDetails()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Lecture\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class Reception : Event
    {
        public string RSVP { get; set; }

        public override string GetFullDetails()
        {
            return $"Event: Reception\n{base.GetFullDetails()}\nRSVP: {RSVP}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Reception\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class OutdoorGathering : Event
    {
        public string WeatherForecast { get; set; }

        public override string GetFullDetails()
        {
            return $"Event: Outdoor Gathering\n{base.GetFullDetails()}\nWeather Forecast: {WeatherForecast}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Outdoor Gathering\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {StateProvince}, {Country}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "City1", "State1", "USA");
            Event event1 = new Lecture("Lecture Title", "Description", new DateTime(2024, 4, 10), "10:00 AM", address1) { Speaker = "Speaker Name", Capacity = 100 };

            Address address2 = new Address("456 Elm St", "City2", "State2", "USA");
            Event event2 = new Reception("Reception Title", "Description", new DateTime(2024, 4, 11), "7:00 PM", address2) { RSVP = "RSVP Email" };

            Address address3 = new Address("789 Oak St", "City3", "State3", "USA");
            Event event3 = new OutdoorGathering("Outdoor Gathering Title", "Description", new DateTime(2024, 4, 12), "2:00 PM", address3) { WeatherForecast = "Sunny" };

            Console.WriteLine(event1.GetFullDetails());
            Console.WriteLine(event1.GetShortDescription());
            Console.WriteLine();

            Console.WriteLine(event2.GetFullDetails());
            Console.WriteLine(event2.GetShortDescription());
            Console.WriteLine();

            Console.WriteLine(event3.GetFullDetails());
            Console.WriteLine(event3.GetShortDescription());
        }
    }
}
