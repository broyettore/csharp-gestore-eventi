using csharp_gestore_eventi.Classes;
using System.Globalization;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Event Handler 2.0 \n ");

            // asks user event name
            Console.WriteLine("How would you like to name your event");
            string eventName = Console.ReadLine();

            Console.WriteLine(); // empty line

            // asks user event date
            Console.WriteLine("When should the event take place (example: 10 january 2020 10:30)");
            DateTime parsedDate;

            // loop unitl date is written correctly
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
            {
                Console.WriteLine("Date is written wrong");
            }


            Console.WriteLine(); // empty line

            // asks user max capacity of the event
            Console.WriteLine("What should be the max capacity of your event");
            int totalSeats;

            while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
            {
                Console.WriteLine("Please insert a number");
            }

            Console.WriteLine(); // empty line

            try
            {
                // event instance created
                Event myEvent = new(eventName, parsedDate, totalSeats);
                

                //asks user if and how many seats should be booked
                while (true)
                {
                    Console.WriteLine("Would you like to book some seats (yes / no)");
                    string bookingAnswer = Console.ReadLine();

                    Console.WriteLine(); // empty line

                    if (bookingAnswer == "yes")
                    {
                        Console.WriteLine("How many seats should be booked");
                        int seatToBook = int.Parse(Console.ReadLine());                      

                        int seatsBooked = myEvent.bookSeats(seatToBook);
                        int seatsAvailable = myEvent.GetEventMaxCapacity() - seatsBooked;

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

                // asks user if and how many seats booking he wants to cancel
                while (true)
                {
                    Console.WriteLine("Would you like to cancel some seats bookings (yes / no)");
                    string cancelBookingAnswer = Console.ReadLine();

                    Console.WriteLine(); // empty line

                    if (cancelBookingAnswer == "yes")
                    {
                        Console.WriteLine("How many seats booking should be cancelled");
                        int seatToCancel = int.Parse(Console.ReadLine());
                      
                        int seatsBooked = myEvent.cancelSeatBooking(seatToCancel);
                        int seatsAvailable = myEvent.GetEventMaxCapacity() - seatsBooked;

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

                // Prints your event
                Console.WriteLine(myEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}