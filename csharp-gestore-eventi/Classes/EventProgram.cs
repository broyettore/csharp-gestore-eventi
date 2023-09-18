using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<Event> Events { get; private set; }

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
            foreach (Event e in Events)
            {
                Console.WriteLine(e);
            }
        }

        // gets event of a particular date
        public List<Event> GetEventFromDate(DateTime date)
        {
            List<Event> eventsOfDate = new();

            foreach (Event e in Events)
            {
                if (e.EventDate.Date == date.Date)
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

        public static string? GetProgamName()
        {
            Console.Write("How would you like to name your program of events: ");
            return Console.ReadLine();
        }

        public static int GetProgamNumOfEvents()
        {
            Console.Write("How many events would you like to insert in your program: ");
            int eventsNumber;
            while (int.TryParse(Console.ReadLine(), out eventsNumber) == false)
            {
                Console.WriteLine("Please insert a valid number");
            }
            return eventsNumber;
        }
        public static int GetProgamNumOfConferences()
        {
            Console.Write("How many conferences would you like to insert in your program: ");
            int eventsNumber;
            while (int.TryParse(Console.ReadLine(), out eventsNumber) == false)
            {
                Console.WriteLine("Please insert a valid number");
            }
            return eventsNumber;
        }

        public static Event CreateEvent(int eventsNumber)
        {
            // asks user event name
            Console.Write($"How would you like to name your event {eventsNumber}: ");
            string? eventName = Console.ReadLine();

            // asks user event date
            Console.Write($"When should the event {eventsNumber} take place (example: 10 january 2020): ");
            DateTime parsedDate;

            // loop unitl date is written correctly
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
            {
                Console.Write("Date is written wrong: ");
            }

            // asks user max capacity of the event
            Console.Write($"What should be the max capacity of your event {eventsNumber}: ");
            int totalSeats;

            while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
            {
                Console.WriteLine("Please insert a number: ");
            }

            Console.WriteLine(); // empty line


            // Create and store the events in the array
            return new Event(eventName, parsedDate, totalSeats);
        }
        public static Conference CreateConference(int eventsNumber)
        {
            // asks user event name
            Console.Write($"How would you like to name your conference {eventsNumber}: ");
            string? eventName = Console.ReadLine();

            // asks user event date
            Console.Write($"When should the conference {eventsNumber} take place (example: 10 january 2020): ");
            DateTime parsedDate;

            // loop unitl date is written correctly
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
            {
                Console.Write("Date is written wrong: ");
            }

            // asks user max capacity of the event
            Console.Write($"What should the max capacity of your conference be {eventsNumber}: ");
            int totalSeats;

            while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
            {
                Console.WriteLine("Please insert a number: ");
            }

            // asks user speaker's name
            Console.Write($"Who will be the speaker at your conference {eventsNumber}: ");
            string? eventSpeakerName = Console.ReadLine();

            // asks user conference price
            Console.Write($"How much should your conference cost {eventsNumber}: ");
            int eventPrice = int.Parse(Console.ReadLine());

            Console.WriteLine(); // empty line

            // Create and store the events in the array
            return new Conference(eventName, parsedDate, totalSeats, eventSpeakerName, eventPrice);
        }

        public static void AddSeatBooking(Event e)
        {
            //asks user if and how many seats should be booked until he is satisfied               
            Console.Write("Would you like to book some seats (yes / no): ");
            string? bookingAnswer = Console.ReadLine();

            if (bookingAnswer == "yes")
            {
                Console.Write("How many seats should be booked: ");
                int seatToBook = int.Parse(Console.ReadLine());

                int seatsBooked = e.BookSeats(seatToBook);
                int seatsAvailable = e.GetEventMaxCapacity() - seatsBooked;

                Console.WriteLine(); // empty line

                Console.WriteLine($"This is the number of seats booked in event {e.EventTitle}: {seatsBooked}");
                Console.WriteLine($"This is the number of seats available in event {e.EventTitle}: {seatsAvailable} \n");
            }
            else
            {
                Console.WriteLine("Ok then thank you ! \n");
            }
        }

        public static void CancelSeatBooking(Event e)
        {
            // asks user if and how many seats booking he wants to cancel until he is satisfied

            Console.Write("Would you like to cancel some seats bookings (yes / no): ");
            string cancelBookingAnswer = Console.ReadLine();

            if (cancelBookingAnswer == "yes")
            {
                Console.Write("How many seats booking should be cancelled: ");
                int seatToCancel = int.Parse(Console.ReadLine());

                int seatsBooked = e.CancelSeatBooking(seatToCancel);
                int seatsAvailable = e.GetEventMaxCapacity() - seatsBooked;

                Console.WriteLine(); // empty line

                Console.WriteLine($"This is the number of seats booked (updated) in event {e.EventTitle}: {seatsBooked}");
                Console.WriteLine($"This is the number of seats available in event (updated) {e.EventTitle}: {seatsAvailable} \n");
            }
            else
            {
                Console.WriteLine("Ok then thank you ! \n");
            }
        }

        public static void PrintEventSummary(EventProgram program)
        {
            int numberOfEvents = program.GetTotalEvents();

            // Prints your event
            Console.WriteLine($"This is the total number of programmed events: {numberOfEvents}");
            Console.WriteLine(); // empty line

            Console.WriteLine("These are the events listed: \t");
            EventProgram.PrintEventList(program.Events);

            Console.WriteLine(); // empty line

            Console.Write("Insert a date to see the events of that date (example: 18 september 2023): ");
            DateTime inputDate;
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate) == false)
            {
                Console.Write("Date is written wrong: ");
            }

            Console.WriteLine($"these are the events taking place on {inputDate} : \t");
            foreach (var e in program.GetEventFromDate(inputDate))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(); // empty line

            Console.WriteLine("This is the program for this month including events and conferences: \n\t");
            program.PrintEventDateTitle();
        }

    }
}
