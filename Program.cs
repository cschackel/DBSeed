using System;
using System.Linq;
using System.Collections.Generic;


namespace ModasSeedData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // first create Locations list
            List<Location> Locations = new List<Location>()
            {
                //new Location { LocationId = 1, Name = "Front Door"},

                new Location { LocationId = 1, Name = "Snake Pit"},
                new Location { LocationId = 2, Name = "Spike Trap"},
                new Location { LocationId = 3, Name = "Cookie Jar"}


                // TODO: Add locations
            };
            // create date object containing current date/time
            DateTime localDate = DateTime.Now;
            // TODO: subtract 6 months from date

            DateTime eventDate = localDate.AddMonths(-6);

            // eventDate = ???
            // TODO: instantiate Random class
            Random rnd = new Random();
            // Random rnd = ???
            // TODO: create list to store events (Events)

            LinkedList<Event> events = new LinkedList<Event>();
            int IDCounter = 1;

            while(eventDate < localDate)
            {
                //Console.WriteLine("Generating for " + eventDate);
                int numOfEvents = rnd.Next(0, 6);

                List<Event> newEvents = new List<Event>();

                for(int i = 0; i < numOfEvents; i++)
                {
                    Event newEvent = new Event();
                    newEvent.Location = Locations.ElementAt(rnd.Next(0, 3));
                    int hour = rnd.Next(0, 24);
                    int minute = rnd.Next(0, 60);
                    int second = rnd.Next(0, 60);

                    DateTime newDateTime = new DateTime(eventDate.Year,eventDate.Month,eventDate.Day,hour,minute,second);

                    newEvent.TimeStamp = newDateTime;
                    newEvents.Add(newEvent);
                    newEvents.Sort((x, y) => DateTime.Compare(x.TimeStamp, y.TimeStamp));
                }

                foreach( Event e in newEvents)
                {
                    e.EventId = IDCounter++;
                    events.AddLast(e);
                }

                eventDate = eventDate.AddDays(1);
            }

            foreach(Event e in events)
            {
                Console.WriteLine(e.ToString());
            }

            // loop for each day in the range from 6 months ago to today
            //while (eventDate < localDate)
            //{
            // TODO: random between 0 and 5 determines the number of events to occur on a given day
            // TODO: a sorted list will be used to store daily events sorted by date/time - each time an event is added, the list is re-sorted
            // TODO: for loop to generate times for each event
            // TODO: random between 0 and 23 for hour of the day
            // TODO: random between 0 and 59 for minute of the day
            // TODO: random between 0 and 59 for seconds of the day
            // TODO: random location (use Locations)
            // TODO: create date/time for event
            // TODO: create event from date/time and location
            // TODO: add daily event to sorted list
            // TODO: loop thru sorted list for daily events
            // add daily event to Events
            // TODO: add 1 day to eventDate
            //}
            // TODO: loop thru Events
            // TODO: display event at console
        }
    }

 

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public string ToString()
        {
            string output = "{\n";
            output += $"Location ID: {LocationId}\n";
            output += $"Name: {Name}\n";
            output += "}";
            return output;
        }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }

        public String ToString()
        {
            String output = "{\n";
            output += $"Event ID: {EventId}\n";
            output += $"DateTime: {TimeStamp}\n";
            output += $"Flagged: {Flagged}\n";
            output += $"Location: {Location.ToString()}\n";
            output += "}";
            return output;
        }
    }
}
