using csharp_gestore_eventi.Classes;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Event Handler 2.0 \n ");

            string programName = EventProgram.GetProgamName();

            Console.WriteLine(); // empty line

            int eventsNumber = EventProgram.GetProgamNumOfEvents();
             
            Console.WriteLine(); // empty line         

            // Program instance created
            EventProgram newProgram = new EventProgram(programName);

            // your created events
            Event[] myEvents = new Event[eventsNumber];

            for (int i = 0; i < eventsNumber; i++)
            {
                try
                {
                    // Creates new Event
                    Event newEvent = EventProgram.createEvent(i + 1);
                    myEvents[i] = newEvent;
                    // Adding events to the program
                    newProgram.AddEvent(newEvent);
                    EventProgram.addSeatBooking(newEvent);
                    EventProgram.cancelSeatBooking(newEvent);

                }
                catch (Exception ex) // if an exception is caugth it loops into asking event[i] info until insertions are correct
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Reinsert event { i + 1} informations please");
                    Console.WriteLine(); // empty line
                    i--;
                }
            }

            // Print all info related to the events in the program
            EventProgram.PrintEventSummary(newProgram);
        }
    }
}