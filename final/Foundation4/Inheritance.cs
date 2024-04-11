using System;

namespace InheritanceEventPlanning
{
    class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Address Address { get; set; }

        public Event(string title, string description, DateTime date, string time, Address address)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
            Address = address;
        }

        public virtual string GetStandardDetails()
        {
            return $"Event: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
        }

        public virtual string GetFullDetails()
        {
            return GetStandardDetails();
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

        public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            Speaker = speaker;
            Capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"Event: Lecture\n{base.GetStandardDetails()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Lecture\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class Reception : Event
    {
        public string RSVP { get; set; }

        public Reception(string title, string description, DateTime date, string time, Address address, string rsvp)
            : base(title, description, date, time, address)
        {
            RSVP = rsvp;
        }

        public override string GetFullDetails()
        {
            return $"Event: Reception\n{base.GetStandardDetails()}\nRSVP: {RSVP}";
        }

        public override string GetShortDescription()
        {
            return $"Event Type: Reception\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
        }
    }

    class OutdoorGathering : Event
    {
        public string WeatherForecast { get; set; }

        public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            WeatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"Event: Outdoor Gathering\n{base.GetStandardDetails()}\nWeather Forecast: {WeatherForecast}";
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

        public Address(string street, string city, string stateProvince, string country)
        {
            Street = street;
            City = city;
            StateProvince = stateProvince;
            Country = country;
        }

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
            Event event1 = new Lecture("Lecture Title", "Lecture Description", new DateTime(2024, 4, 10), "10:00 AM", address1, "Speaker Name", 100);

            Address address2 = new Address("456 Elm St", "City2", "State2", "Canada");
            Event event2 = new Reception("Reception Title", "Reception Description", new DateTime(2024, 4, 12), "6:00 PM", address2, "rsvp@example.com");

            Address address3 = new Address("789 Oak St", "City3", "State3", "USA");
            Event event3 = new OutdoorGathering("Outdoor Gathering Title", "Outdoor Gathering Description", new DateTime(2024, 4, 15), "2:00 PM", address3, "Sunny");

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
