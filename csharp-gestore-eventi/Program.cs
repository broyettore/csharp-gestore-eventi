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

            Console.Write("How would you like to name your program of events: ");
            string programName = Console.ReadLine();

            Console.WriteLine(); // empty line

            Console.Write("How many events would you like to insert in your program: ");
            int eventsNumber;

            while (int.TryParse(Console.ReadLine(), out eventsNumber) == false)
            {
                Console.WriteLine("Please insert a number");
            }

            Console.WriteLine(); // empty line         

            // Program instance created
            EventProgram newProgram = new EventProgram(programName);

            // your created events
            Event[] myEvents = new Event[eventsNumber];




            for (int i = 0; i < eventsNumber; i++)
            {
                try
                {
                    // asks user event name
                    Console.Write($"How would you like to name your event {i + 1}: ");
                    string eventName = Console.ReadLine();

                    // asks user event date
                    Console.Write($"When should the event {i + 1} take place (example: 10 january 2020): ");
                    DateTime parsedDate;

                    // loop unitl date is written correctly
                    while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
                    {
                        Console.Write("Date is written wrong: ");
                    }

                    // asks user max capacity of the event
                    Console.Write($"What should be the max capacity of your event {i + 1}: ");
                    int totalSeats;

                    while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
                    {
                        Console.WriteLine("Please insert a number: ");
                    }

                    Console.WriteLine(); // empty line


                    // Create and store the events in the array
                    myEvents[i] = new Event(eventName, parsedDate, totalSeats);



                    // Adding events to the program
                    newProgram.AddEvent(myEvents[i]);

                    //asks user if and how many seats should be booked until he is satisfied               
                    Console.Write("Would you like to book some seats (yes / no): ");
                    string bookingAnswer = Console.ReadLine();

                    if (bookingAnswer == "yes")
                    {
                        Console.Write("How many seats should be booked: ");
                        int seatToBook = int.Parse(Console.ReadLine());

                        int seatsBooked = myEvents[i].bookSeats(seatToBook);
                        int seatsAvailable = myEvents[i].GetEventMaxCapacity() - seatsBooked;

                        Console.WriteLine(); // empty line

                        Console.WriteLine($"This is the number of seats booked in event {myEvents[i].eventTitle}: {seatsBooked}");
                        Console.WriteLine($"This is the number of seats available in event {myEvents[i].eventTitle}: {seatsAvailable} \n");
                    }
                    else
                    {
                        Console.WriteLine("Ok then thank you ! \n");
                    }

                    // asks user if and how many seats booking he wants to cancel until he is satisfied

                    Console.Write("Would you like to cancel some seats bookings (yes / no): ");
                    string cancelBookingAnswer = Console.ReadLine();

                    if (cancelBookingAnswer == "yes")
                    {
                        Console.Write("How many seats booking should be cancelled: ");
                        int seatToCancel = int.Parse(Console.ReadLine());

                        int seatsBooked = myEvents[i].cancelSeatBooking(seatToCancel);
                        int seatsAvailable = myEvents[i].GetEventMaxCapacity() - seatsBooked;

                        Console.WriteLine(); // empty line

                        Console.WriteLine($"This is the number of seats booked (updated) in event {myEvents[i].eventTitle}: {seatsBooked}");
                        Console.WriteLine($"This is the number of seats available in event (updated) {myEvents[i].eventTitle}: {seatsAvailable} \n");
                    }
                    else
                    {
                        Console.WriteLine("Ok then thank you ! \n");
                    }

                }
                catch (Exception ex) // if an exception is caugth it loops into asking event[i] info until insertions are correct
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Reinsert event { i + 1} informations please");
                    Console.WriteLine(); // empty line
                    i--;
                }
            }

            int numberOfEvents = newProgram.GetTotalEvents();

            // Prints your event
            Console.WriteLine($"This is the total number of programmed events: {numberOfEvents}");
            Console.WriteLine(); // empty line

            Console.WriteLine("These are the events listed: \t");
            EventProgram.PrintEventList(newProgram.Events);

            Console.WriteLine(); // empty line

            Console.Write("Insert a date to see the events of that date (example: 18 september 2023): ");
            DateTime inputDate;
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate) == false)
            {
                Console.Write("Date is written wrong: ");
            }

            Console.WriteLine($"these are the events taking place on {inputDate} : \t");
            foreach (var e in newProgram.GetEventFromDate(inputDate))
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(); // empty line

            Console.WriteLine("This is the program for this month: \t");
            newProgram.PrintEventDateTitle();
        }
    }
}