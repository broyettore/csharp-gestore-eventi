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

            // asks user event name
            Console.Write("How would you like to name your event: ");
            string eventName = Console.ReadLine();

            Console.WriteLine(); // empty line

            // asks user event date
            Console.Write("When should the event take place (example: 10 january 2020 10:30): ");
            DateTime parsedDate;

            // loop unitl date is written correctly
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
            {
                Console.Write("Date is written wrong");
            }


            Console.WriteLine(); // empty line

            // asks user max capacity of the event
            Console.Write("What should be the max capacity of your event: ");
            int totalSeats;

            while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
            {
                Console.WriteLine("Please insert a number");
            }

            Console.WriteLine(); // empty line

            try
            {
                // Program instance created
                EventProgram newProgram = new EventProgram("September Program");

                // your created events
                Event myEvent1 = new(eventName, parsedDate, totalSeats);
                Event myEvent2 = new("Art Expo", DateTime.Now.AddDays(2), 360);
                Event myEvent3 = new("Manga Expo", DateTime.Now, 50);
                Event myEvent4 = new("LaraCon", DateTime.Now.AddDays(4), 2500);

                // adding events to the program
                newProgram.AddEvent(myEvent1);
                newProgram.AddEvent(myEvent2);
                newProgram.AddEvent(myEvent3);
                newProgram.AddEvent(myEvent4);



                //asks user if and how many seats should be booked until he is satisfied
                while (true)
                {
                    Console.Write("Would you like to book some seats (yes / no): ");
                    string bookingAnswer = Console.ReadLine();

                    Console.WriteLine(); // empty line

                    if (bookingAnswer == "yes")
                    {
                        Console.Write("How many seats should be booked: ");
                        int seatToBook = int.Parse(Console.ReadLine());                      

                        int seatsBooked = myEvent1.bookSeats(seatToBook);
                        int seatsAvailable = myEvent1.GetEventMaxCapacity() - seatsBooked;

                        Console.WriteLine(); // empty line

                        Console.WriteLine($"This is the number of seats booked: {seatsBooked}");
                        Console.WriteLine($"This is the number of seats available: {seatsAvailable} \n");
                    }
                    else
                    {
                        Console.WriteLine("Ok then thank you ! \n");
                        break;
                    }
                }

                // asks user if and how many seats booking he wants to cancel until he is satisfied
                while (true)
                {
                    Console.Write("Would you like to cancel some seats bookings (yes / no): ");
                    string cancelBookingAnswer = Console.ReadLine();

                    Console.WriteLine(); // empty line

                    if (cancelBookingAnswer == "yes")
                    {
                        Console.Write("How many seats booking should be cancelled: ");
                        int seatToCancel = int.Parse(Console.ReadLine());
                      
                        int seatsBooked = myEvent1.cancelSeatBooking(seatToCancel);
                        int seatsAvailable = myEvent1.GetEventMaxCapacity() - seatsBooked;

                        Console.WriteLine(); // empty line

                        Console.WriteLine($"This is the number of seats booked now: {seatsBooked}");
                        Console.WriteLine($"This is the number of seats available: {seatsAvailable} \n");
                    }
                    else
                    {
                        Console.WriteLine("Ok then thank you ! \n");
                        break;
                    }
                }

                int numberOfEvents = newProgram.GetTotalEvents();

                // Prints your event
                Console.WriteLine($"This is the total number of programmed events: {numberOfEvents}");
                Console.WriteLine(); // empty line

                Console.WriteLine("These are the events listed: \t");
                EventProgram.PrintEventList(newProgram.Events);

                Console.WriteLine(); // empty line

                Console.WriteLine("These are the events corresponding a specific date: \t");
                foreach (var e in newProgram.GetEventFromDate(DateTime.Now))
                {
                    Console.WriteLine(e);
                }             
                Console.WriteLine(); // empty line

                Console.WriteLine("This is the program for this month: \t");
                newProgram.PrintEventDateTitle();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}