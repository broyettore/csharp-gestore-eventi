using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes
{
    public class EventProgram
    {
        // ATTRIBUTES
        public string Title { get; private set; }
        public List<Event> Events {  get; private set; }

        // CONSTRUCT
        public EventProgram(string title)
        {
            Title = title;
            Events = new List<Event>();
        }

        // METHODS

        // total events in the list
        public int GetTotalEvents()
        {
            return Events.Count;
        }

        // add event to the event list
        public void AddEvent(Event e) 
        { 
            Events.Add(e);
        }

        // Empty a list of events
        public void EmptyEventList()
        {
            Events.Clear();
        }

        // show event date - title
        public void PrintEventDateTitle()
        {
            Console.WriteLine($"{this.Title}: \t");
            foreach(Event e in Events)
            {              
                Console.WriteLine($"{e.eventDate} - {e.eventTitle}");
            }
        }

        // gets event of a particular date
        public List<Event> GetEventFromDate(DateTime date)
        {
            List<Event> eventsOfDate = new List<Event>();

            foreach (Event e in Events)
            {
                if(e.eventDate.Date == date.Date)
                    eventsOfDate.Add(e);
            }

            return eventsOfDate;
        }

        // STATIC METHODS
        public static void PrintEventList(List<Event> events)
        {
            foreach (Event e in events)
            {
                Console.WriteLine(e);
            }
        }
        

        
    }
}
