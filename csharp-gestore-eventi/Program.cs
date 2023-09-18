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

            string? programName = EventProgram.GetProgamName();
            Console.WriteLine(); // empty line

            int eventsNumber = EventProgram.GetProgamNumOfEvents();         
            Console.WriteLine(); // empty line         

            // Program instance created
            EventProgram newProgram = new(programName);

            // your created events
            Event[] myEvents = new Event[eventsNumber];

            for (int i = 0; i < eventsNumber; i++)
            {
                try
                {
                    // Creates new Event
                    Event newEvent = EventProgram.CreateEvent(i + 1);
                    myEvents[i] = newEvent;
                    // Adding events to the program
                    newProgram.AddEvent(newEvent);
                    EventProgram.AddSeatBooking(newEvent);
                    EventProgram.CancelSeatBooking(newEvent);

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
            Console.WriteLine(); // Empty Line

            Console.WriteLine("---- BONUS ----");
            Console.WriteLine("Let's also add a conference");
            Console.WriteLine(); // Empty Line

            int conferencesNumber = EventProgram.GetProgamNumOfConferences();
            Console.WriteLine(); // empty line

            Conference[] myConferences = new Conference[eventsNumber];

            for (int i = 0; i < conferencesNumber; i++)
            {
                try
                {
                    // Creates new Event
                    Conference newConference = EventProgram.CreateConference(i + 1);
                    myConferences[i] = newConference;
                    // Adding events to the program
                    newProgram.AddEvent(newConference);
                    EventProgram.AddSeatBooking(newConference);
                    EventProgram.CancelSeatBooking(newConference);

                }
                catch (Exception ex) // if an exception is caugth it loops into asking event[i] info until insertions are correct
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Reinsert event {i + 1} informations please");
                    Console.WriteLine(); // empty line
                    i--;
                }
            }

            // Print all info related to the events in the program
            EventProgram.PrintEventSummary(newProgram);
        }
    }
}